using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class FoodCategory : DietaryEntity
    {
        private string categoryID;
        private FoodCategory parentCategory;
        private List<FoodCategory> subCategories = new List<FoodCategory>();

        public FoodCategory() { }

        public FoodCategory(string categoryID, FoodCategory parentCategory, List<FoodCategory> subCategories)
        {
            CategoryID = categoryID;
            ParentCategory = parentCategory;
            SubCategories = subCategories;
        }

        public string CategoryID { get => categoryID; set => categoryID = value; }
        internal FoodCategory ParentCategory { get => parentCategory; set => parentCategory = value; }
        internal List<FoodCategory> SubCategories { get => subCategories; set => subCategories = value; }
    }
}
