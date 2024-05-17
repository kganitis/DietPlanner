using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
