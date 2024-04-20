using DietPlanner.View;
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
        private static FoodCategory foodCategoryTree;
        private static List<Food> allFoodsList;
        private static List<Meal> allMealsList;
        private static List<MealType> allMealTypesList;

        public static void Initialize()
        {
            foodCategoryTree = DataAccess.GetFoodCategoryTree();
            allFoodsList = DataAccess.GetAllFoodData();
            allMealTypesList = DataAccess.GetAllMealTypeData();
            allMealsList = DataAccess.GetAllMealData();
        }

        public static FoodCategory GetCategoryByID(string ID)
        {
            return FindCategoryInTreeRecursive(foodCategoryTree);

            FoodCategory FindCategoryInTreeRecursive(FoodCategory category)
            {
                if (category.ID == ID)
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

        public static FoodCategory GetCategoryByName(string name)
        {
            return FindCategoryInTreeRecursive(foodCategoryTree);

            FoodCategory FindCategoryInTreeRecursive(FoodCategory category)
            {
                if (category.Name == name)
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

        public static Food GetFoodByID(string ID)
        {
            return allFoodsList.FirstOrDefault(food => food.ID == ID);
        }

        public static Food GetFoodByName(string name)
        {
            return allFoodsList.FirstOrDefault(food => food.Name == name);
        }

        public static Meal GetMealByID(string ID)
        {
            return allMealsList.FirstOrDefault(meal => meal.ID == ID);
        }

        public static Meal GetMealByName(string name)
        {
            return allMealsList.FirstOrDefault(meal => meal.Name == name);
        }

        public static MealType GetMealTypeByID(string ID)
        {
            return allMealTypesList.FirstOrDefault(type => type.ID == ID);
        }

        public static MealType GetMealTypeByName(string name)
        {
            return allMealTypesList.FirstOrDefault(type => type.Name == name);
        }

        public static DietaryEntity GetDietaryEntityByID(string ID)
        {
            FoodCategory category = GetCategoryByID(ID);
            Food food = GetFoodByID(ID);
            Meal meal = GetMealByID(ID);
            MealType mealType = GetMealTypeByID(ID);

            if (category != null) { return category; }
            else if (food != null) { return food; }
            else if (meal != null) { return meal; }
            else if (mealType != null) { return mealType; }
            else { return null; }
        }

        public static DietaryEntity GetDietaryEntityByName(string name)
        {
            FoodCategory category = GetCategoryByName(name);
            Food food = GetFoodByName(name);
            Meal meal = GetMealByName(name);
            MealType mealType = GetMealTypeByName(name);

            if (category != null) { return category; }
            else if (food != null) { return food; }
            else if (meal != null) { return meal; }
            else if (mealType != null) { return mealType; }
            else { return null; }
        }

        public static void PrintTree()
        {
            Console.WriteLine("Food Category Tree:");
            PrintFoodCategory(foodCategoryTree, 0);

            void PrintFoodCategory(FoodCategory category, int depth)
            {
                Console.WriteLine(new string(' ', depth * 2) + category.Name);
                foreach (var subCategory in category.SubCategories)
                {
                    PrintFoodCategory(subCategory, depth + 1);
                }
            }
        }

        public static void PrintList<T>(List<T> list) where T: DietaryEntity
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }

    }
}
