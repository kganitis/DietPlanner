using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
