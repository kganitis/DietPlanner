using DietPlanner.View;
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
        public static Patient GetPatientByID(string patientID)
        {
            Patient patient = null;

            try
            {
                SQLiteConnection connection = DBConnectionManager.GetConnection();

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

                    patient = new Patient()
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
                    MessageBox.Show("Δεν βρέθηκαν δεδομένα για τον ασθενή " + patientID, "Μήνυμα", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnectionManager.CloseConnection();
            }

            return patient;
        }

        /*
         * Connects to the DB,
         * READS patient preferences data for the given patientID,
         * fetches the dietary entity instances,
         * and adds them to the appropriate list,
         * then returns the lists in a table.
         */
        public static List<DietaryEntity>[] GetAllPreferencesByPatientID(string patientID)
        {
            List<DietaryEntity> foodsPreferred = new List<DietaryEntity>();
            List<DietaryEntity> foodsAvoided = new List<DietaryEntity>();

            try
            {
                SQLiteConnection connection = DBConnectionManager.GetConnection();

                string query = @"SELECT Patient_id, Dietary_entity_id, Rule
                                FROM Patient_Preferences
                                WHERE Patient_id = @patientID";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientID", patientID);
                
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string id = reader["Dietary_entity_id"].ToString();
                    int rule = Convert.ToInt32(reader["Rule"]);

                    // Add dietary entity to the appropriate list based on the rule
                    if (rule == 1)
                    {
                        foodsPreferred.Add(DietaryEntityData.GetDietaryEntityByID(id));
                    }
                    else if (rule == 0)
                    {
                        foodsAvoided.Add(DietaryEntityData.GetDietaryEntityByID(id));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnectionManager.CloseConnection();
            }

            return new List<DietaryEntity>[] { foodsAvoided, foodsPreferred };
        }

        /*
         * Connects to the DB,
         * READS ALL food category data,
         * creates instances of food categories
         * and connects them in a tree structure,
         * then returns the tree.
         */
        public static FoodCategory GetFoodCategoryTree()
        {
            FoodCategory rootCategory = null;

            try
            {
                SQLiteConnection connection = DBConnectionManager.GetConnection();

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

                    FoodCategory category = new FoodCategory(categoryId, name);
                    AddToTree(rootCategory, category, parentId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnectionManager.CloseConnection();
            }

            return rootCategory;

            void AddToTree(FoodCategory parent, FoodCategory category, string parentId)
            {
                if (String.IsNullOrEmpty(parentId))
                {
                    rootCategory = new FoodCategory(category.ID, category.Name);
                }

                if (parent == null) { return; }

                if (parent.ID == parentId)
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
         * READS ALL food data,
         * creates instances of foods
         * and adds them to a list,
         * then returns the list.
         */
        public static List<Food> GetAllFoodData()
        {
            List<Food> allFoodsList = new List<Food>();

            try
            {
                SQLiteConnection connection = DBConnectionManager.GetConnection();

                // Retrieve food data from the database
                string query = "SELECT * FROM Food ORDER BY Name;";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                // Parse the data, create instances of foods and add them to the list
                while (reader.Read())
                {
                    string foodId = reader["Food_id"].ToString();
                    string name = reader["Name"].ToString();
                    string unit = reader["Unit"].ToString();
                    int quantity = Int32.Parse(reader["Quantity"].ToString());
                    string categoryID = reader["Category_id"].ToString();
                    float calories = Convert.ToSingle(reader["Calories"].ToString());
                    float proteins = Convert.ToSingle(reader["Proteins"].ToString());
                    float carbs = Convert.ToSingle(reader["Carbs"].ToString());
                    float sugars = Convert.ToSingle(reader["Sugars"].ToString());
                    float fiber = Convert.ToSingle(reader["Fiber"].ToString());
                    float fats = Convert.ToSingle(reader["Fats"].ToString());

                    Food food = new Food()
                    {
                        ID = foodId,
                        Name = name,
                        Unit = unit,
                        Quantity = quantity,
                        Category = DietaryEntityData.GetCategoryByID(categoryID),
                        Calories = calories,
                        Protein = proteins,
                        Carbs = carbs,
                        Sugars = sugars,
                        Fiber = fiber,
                        Fats = fats,
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
                DBConnectionManager.CloseConnection();
            }

            return allFoodsList;
        }

        /*
         * Connects to the DB,
         * READS ALL meal data,
         * creates instances of meals
         * and adds them to a list,
         * then returns the list.
         */
        public static List<Meal> GetAllMealData()
        {
            List<Meal> allMealsList = new List<Meal>();

            try
            {
                SQLiteConnection connection = DBConnectionManager.GetConnection();

                // Retrieve meal data from the database
                string query = "SELECT * FROM Meal ORDER BY Name;";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                // Parse the data, create instances of meals and add them to the list
                while (reader.Read())
                {
                    string mealId = reader["Meal_id"].ToString();
                    string name = reader["Name"].ToString();
                    string typeId = reader["Type_id"].ToString();

                    Meal meal = new Meal()
                    {
                        ID = mealId,
                        Name = name,
                        Type = DietaryEntityData.GetMealTypeByID(typeId)
                    };

                    allMealsList.Add(meal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnectionManager.CloseConnection();
            }

            return allMealsList;
        }

        /*
         * Connects to the DB,
         * READS ALL meal types data,
         * creates instances of meal types
         * and adds them to a list,
         * then returns the list.
         */
        public static List<MealType> GetAllMealTypeData()
        {
            List<MealType> allMealTypesList = new List<MealType>();

            try
            {
                SQLiteConnection connection = DBConnectionManager.GetConnection();

                // Retrieve meal type data from the database
                string query = "SELECT * FROM Meal_Type;";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                // Parse the data, create instances of meal types and add them to the list
                while (reader.Read())
                {
                    string typeId = reader["Type_id"].ToString();
                    string name = reader["Name"].ToString();

                    MealType mealType = new MealType()
                    {
                        ID = typeId,
                        Name = name
                    };

                    allMealTypesList.Add(mealType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnectionManager.CloseConnection();
            }

            return allMealTypesList;
        }

        /*
         * Connects to the DB,
         * finds the maximum patient ID
         * and returns the next available ID
         * incrementing the maximum by 1
         */
        public static string GetNextAvailablePatientID()
        {
            string nextAvailableId = "p0000";

            try
            {
                SQLiteConnection connection = DBConnectionManager.GetConnection();

                // Get the maximum patient_id value
                string query = "SELECT MAX(CAST(SUBSTR(Patient_id, 2) AS INTEGER)) FROM Patient";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                object maxIdResult = command.ExecuteScalar();

                // Get the next value, or start from "p0000" if there are no records yet
                int newIdNumber = maxIdResult == DBNull.Value ? 0 : Convert.ToInt32(maxIdResult) + 1;

                // Format the new id
                nextAvailableId = "p" + newIdNumber.ToString("D4"); // D4 ensures 4 digits, padding with leading zeros if necessary
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnectionManager.CloseConnection();
            }

            return nextAvailableId;
        }

        /*
         * Connects to the DB,
         * inserts into Patient table the data of the given patient
         */
        public static void SavePatientData(Patient patient)
        {
            try
            {
                SQLiteConnection connection = DBConnectionManager.GetConnection();

                string query = "INSERT INTO Patient(Patient_id, Name, Gender, Phone_number, Date_of_birth, Height, Weight, Activity_level, Goal) " +
                            "VALUES (@patientId, @name, @gender, @phone, @date, @height, @weight, @activity, @goal)";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientId", patient.PatientID);
                command.Parameters.AddWithValue("@name", patient.Name);
                command.Parameters.AddWithValue("@gender", patient.Gender);
                command.Parameters.AddWithValue("@phone", patient.PhoneNumber);
                command.Parameters.AddWithValue("@date", patient.DateOfBirthStr);
                command.Parameters.AddWithValue("@height", patient.Height);
                command.Parameters.AddWithValue("@weight", patient.Weight);
                command.Parameters.AddWithValue("@activity", patient.ActivityLevel);
                command.Parameters.AddWithValue("@goal", patient.Goal);

                command.ExecuteNonQuery();

                MessageBox.Show("Ο ασθενής καταχωρήθηκε με επιτυχία");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnectionManager.CloseConnection();
            }
        }

        /*
         * Connects to the DB,
         * inserts into Patient_Preferences table the preferred foods for the given patient
         */
        public static void SavePreferredFoodsForPatient(Patient patient)
        {
            try
            {
                SQLiteConnection connection = DBConnectionManager.GetConnection();

                foreach (var entity in patient.PreferredFoods)
                {
                    string query = "INSERT INTO Patient_Preferences (Patient_id, Dietary_entity_id, Rule) VALUES (@patientId, @dietaryEntityId, @rule)";

                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", patient.PatientID);
                    command.Parameters.AddWithValue("@dietaryEntityId", entity.ID);
                    command.Parameters.AddWithValue("@rule", 1);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnectionManager.CloseConnection();
            }
        }

        /*
         * Connects to the DB,
         * inserts into Patient_Preferences table the avoided foods for the given patient
         */
        public static void SaveFoodsAvoidedForPatient(Patient patient)
        {
            try
            {
                SQLiteConnection connection = DBConnectionManager.GetConnection();

                foreach (var entity in patient.FoodsToAvoid)
                {
                    string query = "INSERT INTO Patient_Preferences (Patient_id, Dietary_entity_id, Rule) VALUES (@patientId, @dietaryEntityId, @rule)";

                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", patient.PatientID);
                    command.Parameters.AddWithValue("@dietaryEntityId", entity.ID);
                    command.Parameters.AddWithValue("@rule", 0);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnectionManager.CloseConnection();
            }
        }
    }
}
