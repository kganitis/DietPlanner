using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.View
{
    internal class MealItem
    {
        private Meal meal;
        private float quantity;
        private int day;
        private int timeOfDay;

        public MealItem() { }

        public MealItem(Meal meal, float quantity, int day, int timeOfDay)
        {
            this.meal = meal;
            this.quantity = quantity;
            this.day = day;
            this.timeOfDay = timeOfDay;
        }
                
        internal Meal Meal { get => meal; set => meal = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public int Day { get => day; set => day = value; }
        public int TimeOfDay { get => timeOfDay; set => timeOfDay = value; }
        public float Calories => meal.Calories * quantity;
        public Dictionary<Food, float> Ingredients =>
            meal?.Ingredients.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value * Quantity) 
            ?? new Dictionary<Food, float>();
        
    }
}
