using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner.DataFetcher
{
    internal static class DietaryEntityData
    {
        private static FoodCategoryView foodCategoryTree;
        private static List<FoodView> allFoodsList;
        private static List<MealView> allMealsList;
        private static List<MealTypeView> allMealTypesList;

        public static void Initialize()
        {
            foodCategoryTree = DataAccess.GetFoodCategoryTree();
            allFoodsList = DataAccess.GetAllFoodData();
            allMealTypesList = DataAccess.GetAllMealTypeData();
            allMealsList = DataAccess.GetAllMealData();
            
            PrintTree();
            PrintList(allFoodsList);
        }

        public static FoodCategoryView GetCategoryByID(string categoryID)
        {
            return FindCategoryInTreeRecursive(foodCategoryTree);

            FoodCategoryView FindCategoryInTreeRecursive(FoodCategoryView category)
            {
                if (category.CategoryID == categoryID)
                {
                    return category;
                }
                else
                {
                    foreach (var subCategory in category.SubCategories)
                    {
                        var result = FindCategoryInTreeRecursive(subCategory);
                        if (result != null)
                        {
                            return result;
                        }
                    }
                }
                return null;
            }
        }

        public static FoodView GetFoodByID(string foodID)
        {
            return allFoodsList.FirstOrDefault(food => food.FoodID == foodID);
        }

        public static MealView GetMealByID(string mealID)
        {
            return allMealsList.FirstOrDefault(meal => meal.MealID == mealID);
        }

        public static MealTypeView GetMealTypeByID(string typeID)
        {
            return allMealTypesList.FirstOrDefault(type => type.TypeID == typeID);
        }

        public static void PrintTree()
        {
            Console.WriteLine("Food Category Tree:");
            PrintFoodCategory(foodCategoryTree, 0);

            void PrintFoodCategory(FoodCategoryView category, int depth)
            {
                Console.WriteLine(new string(' ', depth * 2) + category.Name);
                foreach (var subCategory in category.SubCategories)
                {
                    PrintFoodCategory(subCategory, depth + 1);
                }
            }
        }

        public static void PrintList<T>(List<T> list) where T: DietaryEntityView
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }

    }
}
