
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
