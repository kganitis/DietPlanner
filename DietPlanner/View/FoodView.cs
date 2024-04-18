using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class FoodView : DietaryEntityView
    {
        private string foodID;
        private string unit;
        private float quantity;
        private FoodCategoryView category;
        private float calories;
        private float protein;
        private float carbs;
        private float sugars;
        private float fiber;
        private float fats;

        public FoodView() { }

        public FoodView(string foodID, string unit, float quantity, float calories, 
                    float protein, float carbs, float sugars, float fiber,
                    float fats, FoodCategoryView category)
        {
            FoodID = foodID;
            Unit = unit;
            Quantity = quantity;
            Calories = calories;
            Protein = protein;
            Carbs = carbs;
            Sugars = sugars;
            Fiber = fiber;
            Fats = fats;
            Category = category;
        }

        public string FoodID { get => foodID; set => foodID = value; }
        public string Unit { get => unit; set => unit = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public float Calories { get => calories; set => calories = value; }
        public float Protein { get => protein; set => protein = value; }
        public float Carbs { get => carbs; set => carbs = value; }
        public float Sugars { get => sugars; set => sugars = value; }
        public float Fiber { get => fiber; set => fiber = value; }
        public float Fats { get => fats; set => fats = value; }
        internal FoodCategoryView Category { get => category; set => category = value; }
    }
}
