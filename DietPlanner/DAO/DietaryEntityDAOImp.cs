using DietPlanner.Model;
using DietPlanner.Service;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner.DAO
{
    internal class DietaryEntityDAOImp : IDietaryEntityDAO
    {
        /*
         * Connects to the DB,
         * READS ALL food category data,
         * creates instances of food categories
         * and connects them in a tree structure,
         * then returns the tree.
         */
        public FoodCategory GetFoodCategoryTree() 
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
        public List<Food> GetAllFoods() 
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
                        Category = DietaryEntityServiceImp.getInstance().GetCategoryByID(categoryID),
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
        public List<Meal> GetAllMeals()
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
                        Type = DietaryEntityServiceImp.getInstance().GetMealTypeByID(typeId)
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
                    Food food = DietaryEntityServiceImp.getInstance().GetFoodByID(foodId);
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
        public List<MealType> GetAllMealTypes()
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

    }
}
