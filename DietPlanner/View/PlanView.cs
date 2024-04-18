using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class PlanView
    {
        private string patientID;
        private List<MealItemView> mealPlan = new List<MealItemView>();
        private int mealsPerDay;

        public PlanView() { }

        public PlanView(string patientID, List<MealItemView> mealPlan, int mealsPerDay)
        {
            PatientID = patientID;
            MealPlan = mealPlan;
            MealsPerDay = mealsPerDay;
        }

        public string PatientID { get => patientID; set => patientID = value; }
        internal List<MealItemView> MealPlan { get => mealPlan; set => mealPlan = value; }
        public int MealsPerDay { get => mealsPerDay; set => mealsPerDay = value; }
    }


}
