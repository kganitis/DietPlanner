using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner.DataFetcher
{
    internal static class DataAccess
    {
        /*
        * Connects to the DB,
        * READS patient data corresponding to the given patientID,
        * creates a Patient instance,
        * then returns it.
        */
        public static PatientView GetPatient(string patientID)
        {
            PatientView patient = null;

            SQLiteConnection connection = null;
            try
            {
                connection = DBConnectionManager.GetConnection();

                string query = "SELECT * FROM Patient WHERE Patient_id = @patientID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientID", patientID);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Retrieve patient data from the database
                    string name = reader["Name"].ToString();
                    string gender = reader["Gender"].ToString();
                    string phoneNumber = reader["Phone_number"].ToString();

                    string dateOfBirth = reader["Date_of_birth"].ToString();
                    DateTime.TryParseExact(dateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);

                    float height = Convert.ToSingle(reader["Height"]);
                    float weight = Convert.ToSingle(reader["Weight"]);
                    float activityLevel = Convert.ToSingle(reader["Activity_level"]);
                    int goal = Int32.Parse(reader["Goal"].ToString());

                    patient = new PatientView()
                    {
                        PatientID = patientID,
                        Name = name,
                        Gender = gender,
                        PhoneNumber = phoneNumber,
                        DateOfBirth = parsedDate,
                        Height = height,
                        Weight = weight,
                        ActivityLevel = activityLevel,
                        Goal = goal
                    };
                }
                else
                {
                    MessageBox.Show("Δεν βρέθηκαν δεδομένα για τον ασθενή " + patientID, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection?.Close();
            }

            return patient;
        }

        /*
        * Connects to the DB,
        * READS ALL food category data,
        * creates instances of food categories
        * and connects them in a tree structure,
        * then returns the tree.
        */
        public static FoodCategoryView GetFoodCategoriesTree()
        {
            FoodCategoryView rootCategory = null;

            SQLiteConnection connection = null;
            try
            {
                connection = DBConnectionManager.GetConnection();

                // Retrieve food category data from the database
                string query = "SELECT * FROM Food_Category ORDER BY Category_id;";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                // Parse the data, create instances of food categories and connect them in a tree structure
                while (reader.Read())
                {
                    string categoryId = reader["Category_id"].ToString();
                    string name = reader["Name"].ToString();
                    string parentId = reader["Parent"].ToString();

                    FoodCategoryView category = new FoodCategoryView(categoryId, name);
                    AddToTree(rootCategory, category, parentId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection?.Close();
            }

            return rootCategory;

            void AddToTree(FoodCategoryView parent, FoodCategoryView category, string parentId)
            {
                if (String.IsNullOrEmpty(parentId))
                {
                    rootCategory = new FoodCategoryView(category.CategoryID, category.Name);
                }

                if (parent == null) { return; }

                if (parent.CategoryID == parentId)
                {
                    category.ParentCategory = parent;
                    parent.SubCategories.Add(category);
                    return;
                }
                foreach (var child in parent.SubCategories)
                {
                    AddToTree(child, category, parentId);
                }
            }
        }

        /*
        * Connects to the DB,
        * READS food categories preferences corresponding to the given patientID,
        * populates the foodCategoriesPreferred and foodCategoriesAvoided dictionaries,
        * then returns them placed in an Array.
        */
        public static Dictionary<string, FoodCategoryView>[] GetFoodCategoryPreferencesData(string patientID)
        {
            Dictionary<string, FoodCategoryView> foodCategoriesPreferred = new Dictionary<string, FoodCategoryView>();
            Dictionary<string, FoodCategoryView> foodCategoriesAvoided = new Dictionary<string, FoodCategoryView>();

            SQLiteConnection connection = null;
            try
            {
                connection = DBConnectionManager.GetConnection();

                // Fetch food categories preferences from the Patient_Preferences table
                string query = @"SELECT Patient_id, Dietary_entity_id, Rule
                                 FROM Patient_Preferences JOIN Food_Category
                                 ON Dietary_entity_id = Category_id
                                 WHERE Patient_id = @patientID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientID", patientID);
                SQLiteDataReader reader = command.ExecuteReader();

                // Populate the foodCategoriesPreferred and foodCategoriesAvoided dictionaries
                while (reader.Read())
                {
                    string categoryID = reader["Dietary_entity_id"].ToString();
                    int rule = Int32.Parse(reader["Rule"].ToString());

                    // Get the corresponding category from the tree
                    FoodCategoryView category = FoodCategoriesTree.GetCategoryByID(categoryID);

                    if (category != null)
                    {
                        // Decide which dictionary to add the category to based on patient preferences
                        if (rule == 1)
                        {
                            foodCategoriesPreferred.Add(categoryID, category);
                        }
                        else
                        {
                            foodCategoriesAvoided.Add(categoryID, category);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Προέκυψε ένα σφάλμα κατά τη φόρτωση των κατηγοριών τροφίμων: " + ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection?.Close();
            }

            return new Dictionary<string, FoodCategoryView>[] { foodCategoriesAvoided, foodCategoriesPreferred };
        }
    }
}
