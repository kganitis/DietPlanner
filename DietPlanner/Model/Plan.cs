using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class Plan
    {
        private string planID { get; set; }
        private List<Meal> mealPlan { get; set; }
        private int mealsPerDay { get; set; }
    }
}
