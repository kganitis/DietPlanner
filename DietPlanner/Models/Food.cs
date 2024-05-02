
namespace DietPlanner.Model
{
    internal class Food : DietaryEntity
    {
        private string unit;
        private float quantity;
        private FoodCategory category;
        private float calories;
        private float protein;
        private float carbs;
        private float sugars;
        private float fiber;
        private float fats;

        public Food() { }

        public Food(string id, string name, string unit, float quantity, float calories, 
                    float protein, float carbs, float sugars, float fiber,
                    float fats, FoodCategory category)
        {
            ID = id;
            Name = name;
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

        public string Unit { get => unit; set => unit = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public float Calories { get => calories; set => calories = value; }
        public float Protein { get => protein; set => protein = value; }
        public float Carbs { get => carbs; set => carbs = value; }
        public float Sugars { get => sugars; set => sugars = value; }
        public float Fiber { get => fiber; set => fiber = value; }
        public float Fats { get => fats; set => fats = value; }
        internal FoodCategory Category { get => category; set => category = value; }
    }
}
