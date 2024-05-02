using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DietPlanner.DAO
{
    internal static class DataAccess
    {
        /*
         * Connects to the DB,
         * READS patient data corresponding to the given patientID,
         * creates a Patient instance,
         * READS patient preferences data for the given patientID,
         * fetches the dietary entity instances,
         * and adds them to the appropriate patient's preferenece list,
         * then returns the patient instance.
         */
        public static Patient GetPatientByID(string patientID)
        {
            Patient patient = null;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                string query = "SELECT * FROM Patient WHERE Patient_id = @patientID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientID", patientID);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Retrieve patient data from the Patient table
                    string name = reader["Name"].ToString();
                    string gender = reader["Gender"].ToString();
                    string phoneNumber = reader["Phone_number"].ToString();

                    string dateOfBirth = reader["Date_of_birth"].ToString();
                    DateTime.TryParseExact(dateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);

                    float height = Convert.ToSingle(reader["Height"]);
                    float weight = Convert.ToSingle(reader["Weight"]);
                    float activityLevel = Convert.ToSingle(reader["Activity_level"]);
                    int goal = int.Parse(reader["Goal"].ToString());

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

                    // Retrieve patient preferences from the Patient_Preferences table
                    query = @"SELECT Patient_id, Dietary_entity_id, Rule
                                FROM Patient_Preferences
                                WHERE Patient_id = @patientID";

                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientID", patientID);

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string id = reader["Dietary_entity_id"].ToString();
                        int rule = Convert.ToInt32(reader["Rule"]);

                        // Add dietary entity to the appropriate list based on the rule
                        if (rule == 1)
                        {
                            patient.PreferredFoods.Add(DietaryEntityData.GetDietaryEntityByID(id));
                        }
                        else if (rule == 0)
                        {
                            patient.FoodsToAvoid.Add(DietaryEntityData.GetDietaryEntityByID(id));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Δεν βρέθηκαν δεδομένα για τον ασθενή: " + patientID, "Μήνυμα", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBUtil.CloseConnection();
            }

            return patient;
        }

        /*
         * Connects to the DB,
         * READS patient data corresponding to the given patientID,
         * creates a Patient instance,
         * READS patient preferences data for the given patientID,
         * fetches the dietary entity instances,
         * and adds them to the appropriate patient's preferenece list,
         * then returns the patient instance.
         */
        public static Patient GetPatientByNameAndPhone(string name, string phoneNumber)
        {
            Patient patient = null;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                string query = "SELECT * FROM Patient WHERE Name LIKE @name AND Phone_number = @phoneNumber";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@name", "%" + name + "%");
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Retrieve patient data from the Patient table
                    string patientID = reader["Patient_id"].ToString();
                    name = reader["Name"].ToString();
                    string gender = reader["Gender"].ToString();
                    phoneNumber = reader["Phone_number"].ToString();

                    string dateOfBirth = reader["Date_of_birth"].ToString();
                    DateTime.TryParseExact(dateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);

                    float height = Convert.ToSingle(reader["Height"]);
                    float weight = Convert.ToSingle(reader["Weight"]);
                    float activityLevel = Convert.ToSingle(reader["Activity_level"]);
                    int goal = int.Parse(reader["Goal"].ToString());

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

                    // Retrieve patient preferences from the Patient_Preferences table
                    query = @"SELECT Patient_id, Dietary_entity_id, Rule
                                FROM Patient_Preferences
                                WHERE Patient_id = @patientID";

                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientID", patientID);

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string entityID = reader["Dietary_entity_id"].ToString();
                        int rule = Convert.ToInt32(reader["Rule"]);

                        // Add dietary entity to the appropriate list based on the rule
                        if (rule == 1)
                        {
                            patient.PreferredFoods.Add(DietaryEntityData.GetDietaryEntityByID(entityID));
                        }
                        else if (rule == 0)
                        {
                            patient.FoodsToAvoid.Add(DietaryEntityData.GetDietaryEntityByID(entityID));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Δεν βρέθηκαν δεδομένα ασθενή με τα στοιχεία που δώσατε.", "Μήνυμα", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBUtil.CloseConnection();
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
        public static FoodCategory GetFoodCategoryTree()
        {
            FoodCategory rootCategory = null;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

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
                DBUtil.CloseConnection();
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
                SQLiteConnection connection = DBUtil.GetConnection();

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
                DBUtil.CloseConnection();
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
                SQLiteConnection connection = DBUtil.GetConnection();

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

                // Retrieve meal ingredients data from the database
                query = "SELECT * FROM Meal_Ingredients;";
                command = new SQLiteCommand(query, connection);
                reader = command.ExecuteReader();

                // Parse the data, get the food instances and add them to the meals' ingredients dict
                while (reader.Read())
                {
                    string mealId = reader["Meal_id"].ToString();
                    string foodId = reader["Food_id"].ToString();
                    float quantity = Convert.ToSingle(reader["Quantity"].ToString());

                    Meal meal = allMealsList.FirstOrDefault(m => m.ID == mealId);
                    Food food = DietaryEntityData.GetFoodByID(foodId);
                    meal.Ingredients.Add(food, quantity);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBUtil.CloseConnection();
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
                SQLiteConnection connection = DBUtil.GetConnection();

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
                DBUtil.CloseConnection();
            }

            return allMealTypesList;
        }

        /*
         * Connects to the DB,
         * inserts into Patient table the data of the given patient,
         * or updates them if the given patient is found,
         * by deleting them first, then re-inserting them.
         */
        public static bool SavePatientData(Patient patient)
        {
            string query = String.Empty;
            SQLiteCommand command;
            bool success = false;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();
                
                // Generate a new ID if needed
                if (String.IsNullOrEmpty(patient.PatientID))
                {
                    // Get the maximum patient_id value
                    query = "SELECT MAX(CAST(SUBSTR(Patient_id, 2) AS INTEGER)) FROM Patient";
                    command = new SQLiteCommand(query, connection);
                    object maxIdResult = command.ExecuteScalar();

                    // Get the next value, or start from "p0000" if there are no records yet
                    int newIdNumber = maxIdResult == DBNull.Value ? 0 : Convert.ToInt32(maxIdResult) + 1;

                    // Format the new patientID
                    patient.PatientID = "p" + newIdNumber.ToString("D4"); // D4 ensures 4 digits, padding with leading zeros if necessary
                }

                // First delete the given patient's data, if found
                query = "DELETE FROM Patient WHERE Patient_id = @patientId";

                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientId", patient.PatientID);

                command.ExecuteNonQuery();

                // Insert patient's data (essentially updating them if previously deleted)
                query = "INSERT INTO Patient(Patient_id, Name, Gender, Phone_number, Date_of_birth, Height, Weight, Activity_level, Goal) " +
                            "VALUES (@patientId, @name, @gender, @phoneNumber, @date, @height, @weight, @activity, @goal)";

                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientId", patient.PatientID);
                command.Parameters.AddWithValue("@name", patient.Name);
                command.Parameters.AddWithValue("@gender", patient.Gender);
                command.Parameters.AddWithValue("@phoneNumber", patient.PhoneNumber);
                command.Parameters.AddWithValue("@date", patient.DateOfBirthStr);
                command.Parameters.AddWithValue("@height", patient.Height);
                command.Parameters.AddWithValue("@weight", patient.Weight);
                command.Parameters.AddWithValue("@activity", patient.ActivityLevel);
                command.Parameters.AddWithValue("@goal", patient.Goal);

                command.ExecuteNonQuery();

                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + query, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally
            {
                DBUtil.CloseConnection();
            }

            return success;
        }

        /*
         * Connects to the DB,
         * inserts into Patient_Preferences table the preferred foods for the given patient
         */
        public static void SavePreferredFoodsForPatient(Patient patient)
        {
            string query = String.Empty;
            SQLiteCommand command;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                // First delete the given patient's data, if found
                query = "DELETE FROM Patient_Preferences WHERE Patient_id = @patientId AND Rule = 1";

                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientId", patient.PatientID);

                command.ExecuteNonQuery();

                foreach (var entity in patient.PreferredFoods)
                {
                    query = "INSERT INTO Patient_Preferences (Patient_id, Dietary_entity_id, Rule) VALUES (@patientId, @dietaryEntityId, @rule)";

                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", patient.PatientID);
                    command.Parameters.AddWithValue("@dietaryEntityId", entity.ID);
                    command.Parameters.AddWithValue("@rule", 1);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + query, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBUtil.CloseConnection();
            }
        }

        /*
         * Connects to the DB,
         * inserts into Patient_Preferences table the avoided foods for the given patient
         */
        public static void SaveFoodsAvoidedForPatient(Patient patient)
        {
            string query = String.Empty;
            SQLiteCommand command;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                // First delete the given patient's data, if found
                query = "DELETE FROM Patient_Preferences WHERE Patient_id = @patientId AND Rule = 0";

                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientId", patient.PatientID);

                command.ExecuteNonQuery();

                foreach (var entity in patient.FoodsToAvoid)
                {
                    query = "INSERT INTO Patient_Preferences (Patient_id, Dietary_entity_id, Rule) VALUES (@patientId, @dietaryEntityId, @rule)";

                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", patient.PatientID);
                    command.Parameters.AddWithValue("@dietaryEntityId", entity.ID);
                    command.Parameters.AddWithValue("@rule", 0);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + query, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBUtil.CloseConnection();
            }
        }

        /*
         * Connects to the DB,
         * READS all plan data for a given patient,
         * creates meal item instances
         * and adds them to the MealPlan list of the plan instance,
         * then returns the plan instance.
         * Returns NULL if no patient is found.
         */
        public static Plan GetPlanForPatient(Patient patient)
        {
            Plan plan = null;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                string query = "SELECT * FROM Plan WHERE Patient_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@id", patient.PatientID);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    plan = new Plan()
                    {
                        Patient = patient
                    };
                }

                while (reader.Read())
                {
                    string mealID = reader["Meal_id"].ToString();
                    float quantity = Convert.ToSingle(reader["Quantity"]);
                    int day = int.Parse(reader["Day"].ToString());
                    int timeOfDay = int.Parse(reader["Time_of_day"].ToString());

                    MealItem mealItem = new MealItem()
                    {
                        Meal = DietaryEntityData.GetMealByID(mealID),
                        Quantity = quantity,
                        Day = day,
                        TimeOfDay = timeOfDay
                    };

                    plan.MealPlan.Add(mealItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBUtil.CloseConnection();
            }

            return plan;
        }

        /*
         * Connects to the DB,
         * inserts into Plan table the data for the given plan
         */
        public static bool SavePlan(Plan plan)
        {
            bool success = false;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                // First clear any existing plan for the patient
                string query = "DELETE FROM Plan WHERE Patient_id = @patientID";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientID", plan.Patient.PatientID);

                command.ExecuteNonQuery();

                // Insert new plan data
                foreach (var mealItem in plan.MealPlan)
                {
                    query = "INSERT INTO Plan (Patient_id, Day, Time_of_day, Meal_id, Quantity) VALUES (@patientID, @day, @time, @mealID, @quantity)";

                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientID", plan.Patient.PatientID);
                    command.Parameters.AddWithValue("@day", mealItem.Day);
                    command.Parameters.AddWithValue("@time", mealItem.TimeOfDay);
                    command.Parameters.AddWithValue("@mealID", mealItem.Meal.ID);
                    command.Parameters.AddWithValue("@quantity", mealItem.Quantity);

                    command.ExecuteNonQuery();

                    success = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally
            {
                DBUtil.CloseConnection();
            }

            return success;
        }
    }
}
