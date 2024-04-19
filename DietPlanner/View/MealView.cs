using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class MealView : DietaryEntityView
    {
        private string mealID;
        private MealTypeView type;
        private Dictionary<FoodView, int> ingredients;

        public MealView() { }

        public MealView(string mealID, MealTypeView type, Dictionary<FoodView, int> ingredients)
        {
            MealID = mealID;
            Type = type;
            Ingredients = ingredients;
        }

        public string MealID { get => mealID; set => mealID = value; }
        internal MealTypeView Type { get => type; set => type = value; }
        internal Dictionary<FoodView, int> Ingredients { get => ingredients; set => ingredients = value; }
    }
}
