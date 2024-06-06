using DietPlanner.DAO;
using DietPlanner.Model;
using System.Collections.Generic;
using System.Linq;

namespace DietPlanner.Service
{
    internal sealed class DietaryEntityServiceImp : IDietaryEntityService
    {
        private static DietaryEntityServiceImp instance;
        private static readonly object lockObj = new object();

        private FoodCategory foodCategoryTree;
        private List<Food> allFoodsList;
        private List<Meal> allMealsList;
        private List<MealType> allMealTypesList;
        
        private DietaryEntityServiceImp()
        {
            
        }

        public static DietaryEntityServiceImp Instance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new DietaryEntityServiceImp();
                    }
                }
            }
            return instance;
        }

        public void Initialize()
        {
            DietaryEntityDAOImp dietaryEntityDAOImp = new DietaryEntityDAOImp();

            foodCategoryTree = dietaryEntityDAOImp.GetFoodCategoryTree();
            allFoodsList = dietaryEntityDAOImp.GetAllFoods();
            allMealTypesList = dietaryEntityDAOImp.GetAllMealTypes();
            allMealsList = dietaryEntityDAOImp.GetAllMeals();
        }

        public FoodCategory GetFoodCategoryTree() => foodCategoryTree;

        public List<Food> GetAllFoodsList() => allFoodsList;
        
        public List<Meal> GetAllMealsList() => allMealsList;

        public List<MealType> GetAllMealTypesList() => allMealTypesList;

        public FoodCategory GetCategoryByID(string ID)
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

        public FoodCategory GetCategoryByName(string name)
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

        public Food GetFoodByID(string ID)
        {
            return allFoodsList.FirstOrDefault(food => food.ID == ID);
        }

        public Food GetFoodByName(string name)
        {
            return allFoodsList.FirstOrDefault(food => food.Name == name);
        }

        public Meal GetMealByID(string ID)
        {
            return allMealsList.FirstOrDefault(meal => meal.ID == ID);
        }

        public Meal GetMealByName(string name)
        {
            return allMealsList.FirstOrDefault(meal => meal.Name == name);
        }

        public MealType GetMealTypeByID(string ID)
        {
            return allMealTypesList.FirstOrDefault(type => type.ID == ID);
        }

        public MealType GetMealTypeByName(string name)
        {
            return allMealTypesList.FirstOrDefault(type => type.Name == name);
        }

        public DietaryEntity GetDietaryEntityByID(string ID)
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

        public DietaryEntity GetDietaryEntityByName(string name)
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
    }
}
