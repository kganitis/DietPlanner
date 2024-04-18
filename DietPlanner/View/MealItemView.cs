using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class MealItemView
    {
        private MealView meal;
        private float quantity;
        private int timeOfDay;

        public MealItemView() { }

        public MealItemView(MealView meal, float quantity, int timeOfDay)
        {
            this.meal = meal;
            this.quantity = quantity;
            this.timeOfDay = timeOfDay;
        }
                
        internal MealView Meal { get => meal; set => meal = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public int TimeOfDay { get => timeOfDay; set => timeOfDay = value; }
    }
}
