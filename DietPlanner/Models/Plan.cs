using System.Collections.Generic;

namespace DietPlanner.Model
{
    internal class Plan
    {
        private Patient patient;
        private List<MealItem> mealPlan = new List<MealItem>();
        private int mealsPerDay;

        public Plan() { }

        public Plan(Patient patient, List<MealItem> mealPlan, int mealsPerDay)
        {
            Patient = patient;
            MealPlan = mealPlan;
            MealsPerDay = mealsPerDay;
        }

        public Patient Patient { get => patient; set => patient = value; }
        internal List<MealItem> MealPlan { get => mealPlan; set => mealPlan = value; }
        public int MealsPerDay { get => mealsPerDay; set => mealsPerDay = value; }
    }


}
