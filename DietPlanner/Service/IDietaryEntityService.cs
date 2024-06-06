using DietPlanner.Model;

namespace DietPlanner.Service
{
    internal interface IDietaryEntityService
    {
        FoodCategory GetCategoryByID(string ID);
        FoodCategory GetCategoryByName(string name);
        Food GetFoodByID(string ID);
        Food GetFoodByName(string name);
        Meal GetMealByID(string ID);
        Meal GetMealByName(string name);
        MealType GetMealTypeByID(string ID);
        MealType GetMealTypeByName(string name);
        DietaryEntity GetDietaryEntityByID(string ID);
        DietaryEntity GetDietaryEntityByName(string name);
    }
}
