using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.View
{
    internal class Meal : DietaryEntity
    {
        private MealType type;
        private Dictionary<Food, int> ingredients;

        public Meal() { }

        public Meal(string id, string name, MealType type, Dictionary<Food, int> ingredients)
        {
            ID = id;
            Name = name;
            Type = type;
            Ingredients = ingredients;
        }

        internal MealType Type { get => type; set => type = value; }
        internal Dictionary<Food, int> Ingredients { get => ingredients; set => ingredients = value; }
    }
}
