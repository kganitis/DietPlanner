using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class Meal : DietaryEntity
    {
        private MealType type;
        private Dictionary<Food, float> ingredients;

        public Meal() { }

        public Meal(string id, string name, MealType type, Dictionary<Food, float> ingredients)
        {
            ID = id;
            Name = name;
            Type = type;
            Ingredients = ingredients;
        }

        internal MealType Type { get => type; set => type = value; }
        internal Dictionary<Food, float> Ingredients { get => ingredients; set => ingredients = value; }
        internal float Calories => Ingredients.Sum(ingredient => ingredient.Key.Calories * ingredient.Value);
    }
}
