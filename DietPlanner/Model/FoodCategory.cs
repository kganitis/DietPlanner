using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class FoodCategory : DietaryEntity
    {
        private string categoryID { get; set; }
        private FoodCategory parentCategory { get; set; }
        private List<FoodCategory> subCategories { get; set; }
    }
}
