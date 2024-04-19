using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner.DataFetcher
{
    internal static class FoodCategoriesTree
    {
        private static FoodCategoryView rootCategory;

        public static void BuildTree()
        {
            rootCategory = DataAccess.GetFoodCategoriesTree();
        }

        public static FoodCategoryView GetCategoryByID(string categoryID)
        {
            return FindCategoryInTreeRecursive(rootCategory);

            FoodCategoryView FindCategoryInTreeRecursive(FoodCategoryView category)
            {
                if (category.CategoryID == categoryID)
                {
                    return category;
                }
                else
                {
                    foreach (var subCategory in category.SubCategories)
                    {
                        var result = FindCategoryInTreeRecursive(subCategory);
                        if (result != null)
                        {
                            return result;
                        }
                    }
                }
                return null;
            }
        }

        public static void PrintTree()
        {
            Console.WriteLine("Food Category Tree:");
            PrintFoodCategory(rootCategory, 0);

            void PrintFoodCategory(FoodCategoryView category, int depth)
            {
                Console.WriteLine(new string(' ', depth * 2) + category.Name);
                foreach (var subCategory in category.SubCategories)
                {
                    PrintFoodCategory(subCategory, depth + 1);
                }
            }
        }
    }
}
