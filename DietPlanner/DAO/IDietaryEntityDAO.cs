using DietPlanner.Model;
using System.Collections.Generic;

namespace DietPlanner.DAO
{
    internal interface IDietaryEntityDAO
    {
        FoodCategory GetFoodCategoryTree();
        List<Food> GetAllFoods();
        List<Meal> GetAllMeals();
        List<MealType> GetAllMealTypes();
    }
}
