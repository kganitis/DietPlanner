using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.DTO
{
    internal class PlanDTO
    {
        private string planID;
        private List<MealItem> mealPlan = new List<MealItem>();
        private int mealsPerDay;

        public PlanDTO() { }

        public PlanDTO(string planID, List<MealItem> mealPlan, int mealsPerDay)
        {
            PlanID = planID;
            MealPlan = mealPlan;
            MealsPerDay = mealsPerDay;
        }

        public string PlanID { get => planID; set => planID = value; }
        internal List<MealItem> MealPlan { get => mealPlan; set => mealPlan = value; }
        public int MealsPerDay { get => mealsPerDay; set => mealsPerDay = value; }
    }
}
