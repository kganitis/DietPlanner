using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner
{
    internal class PlanGenerator
    {
        private string connectionString = "Data source=DietPlanner.db;Version=3;";
        private SQLiteConnection connection;

        private int TDEE;
        private FoodCategoryView foodCategoriesTree;
        private Dictionary<string, FoodCategoryView> foodCategoriesAllowed, foodCategoriesPreferred, foodCategoriesAvoided;
        private Dictionary<string, FoodView> foodsAllowed, foodsPreferred, foodsAvoided;
        private Dictionary<string, MealView> mealsAllowed, mealsPreferred, mealsAvoided;
        private Dictionary<string, MealTypeView> mealTypesAllowed, mealTypesPreferred, mealTypesAvoided;

        public PlanGenerator()
        {
            BuildFoodCategoryTree();
            PrintFoodCategoryTree();
        }

        private void BuildFoodCategoryTree()
        {
            try
            {
                using (connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Retrieve food category data from the database
                    string query = "SELECT * FROM Food_Category ORDER BY Category_id;";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    // Parse the data and create instances of food categories
                    while (reader.Read())
                    {
                        string categoryId = reader["Category_id"].ToString();
                        string name = reader["Name"].ToString();
                        string parentId = reader["Parent"].ToString();
                        FoodCategoryView category = new FoodCategoryView(categoryId, name);
                        FindAndAddToParent(foodCategoriesTree, category, parentId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            void FindAndAddToParent(FoodCategoryView parent, FoodCategoryView category, string parentId)
            {
                if (String.IsNullOrEmpty(parentId))
                {
                    foodCategoriesTree = new FoodCategoryView(category.CategoryID, category.Name);
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
                    FindAndAddToParent(child, category, parentId);
                }
            }
        }

        private void PrintFoodCategoryTree()
        {
            Console.WriteLine("Food Category Tree:");
            PrintFoodCategory(foodCategoriesTree, 0);

            void PrintFoodCategory(FoodCategoryView category, int depth)
            {
                // Print the category name with indentation based on depth
                Console.WriteLine(new string(' ', depth * 2) + category.Name);

                // Recursively print subcategories
                foreach (var subCategory in category.SubCategories)
                {
                    PrintFoodCategory(subCategory, depth + 1);
                }
            }
        }

        
    }
}
