using DietPlanner.Model;
using DietPlanner.Service;
using System.Collections.Generic;

namespace DietPlanner.Controller
{
    internal class DietaryEntityController
    {
        public FoodCategory GetFoodCategoryTree()
        {
            return DietaryEntityServiceImp.Instance().GetFoodCategoryTree();
        }

        public List<Food> GetAllFoodsList()
        {
            return DietaryEntityServiceImp.Instance().GetAllFoodsList();
        }

        public List<Meal> GetAllMealsList()
        {
            return DietaryEntityServiceImp.Instance().GetAllMealsList();
        }

        public List<MealType> GetAllMealTypesList()
        {
            return DietaryEntityServiceImp.Instance().GetAllMealTypesList();
        }
    }
}
