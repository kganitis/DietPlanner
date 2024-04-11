using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class Food : DietaryEntity
    {
        private string foodID { get; set; }
        private string unit { get; set; }
        private float quantity { get; set; }
        private FoodCategory category { get; set; }
        private float calories { get; set; }
        private float protein { get; set; }
        private float carbs { get; set; }
        private float sugars { get; set; }
        private float fiber { get; set; }
        private float fats { get; set; }
        
    }
}
