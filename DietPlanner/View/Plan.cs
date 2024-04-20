using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.View
{
    internal class Plan
    {
        private string patientID;
        private List<MealItem> mealPlan = new List<MealItem>();
        private int mealsPerDay;

        public Plan() { }

        public Plan(string patientID, List<MealItem> mealPlan, int mealsPerDay)
        {
            PatientID = patientID;
            MealPlan = mealPlan;
            MealsPerDay = mealsPerDay;
        }

        public string PatientID { get => patientID; set => patientID = value; }
        internal List<MealItem> MealPlan { get => mealPlan; set => mealPlan = value; }
        public int MealsPerDay { get => mealsPerDay; set => mealsPerDay = value; }
    }


}
