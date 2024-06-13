using System.Collections.Generic;
using System.Linq;

namespace DietPlanner.Model
{
    internal class Meal : DietaryEntity
    {
        private MealType type;
        private Dictionary<Food, float> ingredients = new Dictionary<Food, float>();

        internal MealType Type { get => type; set => type = value; }
        internal Dictionary<Food, float> Ingredients { get => ingredients; set => ingredients = value; }
        internal float Calories => Ingredients.Sum(ingredient => ingredient.Key.Calories * ingredient.Value);
    }
}
