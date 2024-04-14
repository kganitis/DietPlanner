using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class Meal : DietaryEntity
    {
        private int mealID;
        private MealType type;
        private Dictionary<Food, int> ingredients;

        public Meal() { }

        public Meal(int mealID, MealType type, Dictionary<Food, int> ingredients)
        {
            MealID = mealID;
            Type = type;
            Ingredients = ingredients;
        }

        public int MealID { get => mealID; set => mealID = value; }
        internal MealType Type { get => type; set => type = value; }
        internal Dictionary<Food, int> Ingredients { get => ingredients; set => ingredients = value; }
    }
}
