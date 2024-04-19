using DietPlanner.DataFetcher;
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

        private string patientID;
        private PatientView patient;
        private Dictionary<string, FoodCategoryView> foodCategoriesAllowed, foodCategoriesPreferred, foodCategoriesAvoided;
        private Dictionary<string, FoodView> foodsAllowed, foodsPreferred, foodsAvoided;
        private Dictionary<string, MealView> mealsAllowed, mealsPreferred, mealsAvoided;
        private Dictionary<string, MealTypeView> mealTypesAllowed, mealTypesPreferred, mealTypesAvoided;

        public PlanGenerator(string patientID)
        {
            patient = DataAccess.GetPatient(patientID);
            FoodCategoriesTree.BuildTree();
            Dictionary<string, FoodCategoryView>[] foodCategoriesPreferences = DataAccess.GetFoodCategoryPreferencesData(patientID);
            foodCategoriesPreferred = foodCategoriesPreferences[1];
            foodCategoriesAvoided = foodCategoriesPreferences[0];
            PrintDictionary(foodCategoriesPreferred, "Preferred Categories");
            PrintDictionary(foodCategoriesAvoided, "Avoided Categories");
        }

        private void PrintDictionary<T>(Dictionary<string, T> dictionary, string title) where T : DietaryEntityView
        {
            Console.WriteLine($"--- {title} ---");
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value.Name}");
            }
            Console.WriteLine();
        }
    }
}
