using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class Meal : DietaryEntity
    {
        private int mealID { get; set; }
        private MealType type { get; set; }
        public Dictionary<Food, int> ingredients { get; set; }
    }
}
