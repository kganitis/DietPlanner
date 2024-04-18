using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class FoodCategoryView : DietaryEntityView
    {
        private string categoryID;
        private FoodCategoryView parentCategory = null;
        private List<FoodCategoryView> subCategories = new List<FoodCategoryView>();

        public FoodCategoryView() { }

        public FoodCategoryView(string categoryID, string name)
        {
            CategoryID = categoryID;
            Name = name;
        }

        public FoodCategoryView(string categoryID, string name, FoodCategoryView parentCategory, List<FoodCategoryView> subCategories)
        {
            CategoryID = categoryID;
            Name = name;
            ParentCategory = parentCategory;
            SubCategories = subCategories;
        }

        public string CategoryID { get => categoryID; set => categoryID = value; }
        internal FoodCategoryView ParentCategory { get => parentCategory; set => parentCategory = value; }
        internal List<FoodCategoryView> SubCategories { get => subCategories; set => subCategories = value; }
    }
}
