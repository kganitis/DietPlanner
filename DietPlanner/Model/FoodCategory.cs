using System.Collections.Generic;

namespace DietPlanner.Model
{
    internal class FoodCategory : DietaryEntity
    {
        private FoodCategory parentCategory = null;
        private List<FoodCategory> subCategories = new List<FoodCategory>();

        internal FoodCategory ParentCategory { get => parentCategory; set => parentCategory = value; }
        internal List<FoodCategory> SubCategories { get => subCategories; set => subCategories = value; }
    }
}
