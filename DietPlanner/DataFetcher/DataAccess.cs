using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
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
        * 
        * NOTE: It does NOT retrieve or set any food preferences values.
        */
        public static PatientView GetPatientByID(string patientID)
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

        public static Dictionary<string, DietaryEntityView>[] GetAllPreferencesByPatientID(string patientID)
        {
            SQLiteConnection connection = null;
            try
            {
                connection = DBConnectionManager.GetConnection();

                string query = @"SELECT Patient_id, Dietary_entity_id, Dietary_entity_name, Rule
                                FROM Patient_Preferences_Names
                                WHERE Patient_id = @patientID";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientID", patientID);
                
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    int rule = Convert.ToInt32(reader["Rule"]);

                    // Add dietary entity to the appropriate structure based on the rule
                    if (rule == 1)
                    {

                    }
                    else
                    {

                    }
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

            return null;
        }

        /*
        * Connects to the DB,
        * READS ALL food category data,
        * creates instances of food categories
        * and connects them in a tree structure,
        * then returns the tree.
        */
        public static FoodCategoryView GetFoodCategoryTree()
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

        public static List<FoodView> GetAllFoodData()
        {
            List<FoodView> allFoodsList = new List<FoodView>();

            SQLiteConnection connection = null;
            try
            {
                connection = DBConnectionManager.GetConnection();

                // Retrieve food data from the database
                string query = "SELECT * FROM Food ORDER BY Food_id;";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                // Parse the data, create instances of foods and add them to the list
                while (reader.Read())
                {
                    string foodId = reader["Category_id"].ToString();
                    string name = reader["Name"].ToString();
                    string unit = reader["Unit"].ToString();
                    int quantity = Int32.Parse(reader["Quantity"].ToString());
                    string categoryID = reader["Category_id"].ToString();
                    float calories = Convert.ToSingle(reader["Calories"].ToString());
                    // ... more fields

                    FoodView food = new FoodView()
                    {
                        FoodID = foodId,
                        Name = name,
                        Unit = unit,
                        Quantity = quantity,
                        Category = DietaryEntityData.GetCategoryByID(categoryID),
                        Calories = calories
                        // ... more fields
                    };

                    allFoodsList.Add(food);
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

            return allFoodsList;
        }

        public static List<MealView> GetAllMealData()
        {
            List<MealView> allMealsList = new List<MealView>();

            return allMealsList;
        }

        public static List<MealTypeView> GetAllMealTypeData()
        {
            List<MealTypeView> allMealTypesList = new List<MealTypeView>();

            return allMealTypesList;
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
                    FoodCategoryView category = DietaryEntityData.GetCategoryByID(categoryID);

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
