using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class FoodCategory : DietaryEntity
    {
        private FoodCategory parentCategory = null;
        private List<FoodCategory> subCategories = new List<FoodCategory>();

        public FoodCategory() { }

        public FoodCategory(string id, FoodCategory parentCategory)
        {
            ID = id;
            ParentCategory = parentCategory;           
        }

        internal FoodCategory ParentCategory { get => parentCategory; set => parentCategory = value; }
        internal List<FoodCategory> SubCategories { get => subCategories; set => subCategories = value; }
    }
}
