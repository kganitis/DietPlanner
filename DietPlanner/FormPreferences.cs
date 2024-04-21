using DietPlanner.DataFetcher;
using DietPlanner.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner
{
    public partial class FormPreferences : Form
    {
        private List<TreeNode> selectedNodes = new List<TreeNode>();
        private ListBox foodsListBoxToFill;
        private ListBox excludedListBox;

        public FormPreferences(ListBox foodsListBoxToFill, ListBox excludedListBox)
        {
            InitializeComponent();
            this.foodsListBoxToFill = foodsListBoxToFill;
            this.excludedListBox = excludedListBox;
        }

        internal FoodCategory FoodCategoryTree
        {
            get
            {
                return treeViewFoodCategories.Nodes[0].Tag as FoodCategory;
            }
            set
            {
                treeViewFoodCategories.Nodes.Clear();
                AddNode(treeViewFoodCategories.Nodes, value);

                void AddNode(TreeNodeCollection nodes, FoodCategory category)
                {
                    if (ExcludedEntities.Contains(category))
                    {
                        return;
                    }

                    TreeNode node = new TreeNode(category.Name)
                    {
                        Tag = category
                    };

                    nodes.Add(node);
                    if (SelectedEntities.Contains(category))
                    {
                        SelectNode(node);
                    }
                    
                    foreach (var subCategory in category.SubCategories)
                    {
                        AddNode(node.Nodes, subCategory);
                    }
                }
            }
        }

        internal List<FoodCategory> SelectedFoodCategories
        {
            get
            {
                List<FoodCategory> selectedCategories = new List<FoodCategory>();
                foreach (var node in selectedNodes)
                {
                    selectedCategories.Add(node.Tag as FoodCategory);
                }
                return selectedCategories;
            }
        }

        internal List<Food> AllFoods
        {
            get
            {
                List<Food> allFoods = new List<Food>();
                foreach (var item in listBoxFoods.Items)
                {
                    allFoods.Add(item as Food);
                }
                return allFoods;
            }
            set
            {
                listBoxFoods.Items.Clear();
                foreach (var food in DietaryEntityData.GetAllFoodsList())
                {
                    listBoxFoods.Items.Add(food);

                    if (SelectedEntities.Contains(food))
                    {
                        listBoxFoods.SelectedItems.Add(food);
                    }
                }

                foreach (var item in ExcludedEntities)
                {
                    if (item is Food)
                    {
                        listBoxFoods.Items.Remove(item);
                    }
                }
            }
        }

        internal List<Food> SelectedFoods
        {
            get
            {
                List<Food> selectedFoods = new List<Food>();
                foreach (var item in listBoxFoods.SelectedItems)
                {
                    selectedFoods.Add((Food)item);
                }
                return selectedFoods;
            }
        }

        internal List<Meal> AllMeals
        {
            get
            {
                List<Meal> allMeals = new List<Meal>();
                foreach (var item in listBoxMeals.Items)
                {
                    allMeals.Add(item as Meal);
                }
                return allMeals;
            }
            set
            {
                listBoxMeals.Items.Clear();
                foreach (var meal in DietaryEntityData.GetAllMealsList())
                {
                    listBoxMeals.Items.Add(meal);
                    if (SelectedEntities.Contains(meal))
                    {
                        listBoxMeals.SelectedItems.Add(meal);
                    }
                }

                foreach (var item in ExcludedEntities)
                {
                    if (item is Meal)
                    {
                        listBoxMeals.Items.Remove(item);
                    }
                }
            }
        }

        internal List<Meal> SelectedMeals
        {
            get
            {
                List<Meal> selectedMeals = new List<Meal>();
                foreach (var item in listBoxMeals.SelectedItems)
                {
                    selectedMeals.Add((Meal)item);
                }
                return selectedMeals;
            }
        }

        internal List<MealType> AllMealTypes
        {
            get
            {
                List<MealType> allMealTypes = new List<MealType>();
                foreach (var item in listBoxMealTypes.Items)
                {
                    allMealTypes.Add(item as MealType);
                }
                return allMealTypes;
            }
            set
            {
                listBoxMealTypes.Items.Clear();
                MealType dessert = DietaryEntityData.GetMealTypeByName("Dessert");
                MealType cheatMeal = DietaryEntityData.GetMealTypeByName("Cheat Meal");
                foreach (var mealType in new MealType[] { dessert, cheatMeal })
                {
                    listBoxMealTypes.Items.Add(mealType);
                    if (SelectedEntities.Contains(mealType))
                    {
                        listBoxMealTypes.SelectedItems.Add(mealType);
                    }
                }

                foreach (var item in ExcludedEntities)
                {
                    if (item is MealType)
                    {
                        listBoxMealTypes.Items.Remove(item);
                    }
                }
            }
        }

        internal List<MealType> SelectedMealTypes
        {
            get
            {
                List<MealType> selectedMealTypes = new List<MealType>();
                foreach (var item in listBoxMealTypes.SelectedItems)
                {
                    selectedMealTypes.Add((MealType)item);
                }
                return selectedMealTypes;
            }
        }

        internal List<DietaryEntity> SelectedEntities
        {
            get
            {
                List<DietaryEntity> selectedEntities = new List<DietaryEntity>();
                foreach (var item in foodsListBoxToFill.Items)
                {
                    selectedEntities.Add(item as DietaryEntity);
                }
                return selectedEntities;
            }
        }

        internal List<DietaryEntity> ExcludedEntities
        {
            get
            {
                List<DietaryEntity> excludedEntities = new List<DietaryEntity>();
                foreach (var item in excludedListBox.Items)
                {
                    excludedEntities.Add(item as DietaryEntity);
                }
                return excludedEntities;
            }
        }

        private void FormPreferences_Load(object sender, EventArgs e)
        {
            FoodCategoryTree = DietaryEntityData.GetFoodCategoryTree();
            treeViewFoodCategories.ExpandAll();
            AllFoods = DietaryEntityData.GetAllFoodsList();
            AllMeals = DietaryEntityData.GetAllMealsList();
            AllMealTypes = DietaryEntityData.GetAllMealTypesList();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            foodsListBoxToFill.Items.Clear();

            foreach (var category in SelectedFoodCategories)
            {
                foodsListBoxToFill.Items.Add(category);
            }

            foreach (var food in SelectedFoods)
            {
                foodsListBoxToFill.Items.Add(food);
            }

            foreach (var meal in SelectedMeals)
            {
                foodsListBoxToFill.Items.Add(meal);
            }

            foreach (var mealType in SelectedMealTypes)
            {
                foodsListBoxToFill.Items.Add(mealType);
            }

            Close();
        }

        /*
         * This method attempts to add multi-select functionality to treeViewFoodCategories,
         * by keep tracking the selected nodes in a list and manually adjusting their appearance colors.
         * 
         * Known issue:
         *  When clicking on a selected node, it is removed from the selectedNodes list,
         *  BUT it remains visually highlighted by the system because it has been clicked.
         *  It won't be unhighlighted until another node is clicked.
         * 
         * A comprehensive solution to this issue is not trivial.
         * For the purposes of this assignment, we will leave it as it is.
         */
        private void treeViewFoodCategories_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode clickedNode = treeViewFoodCategories.GetNodeAt(e.X, e.Y);
            if (clickedNode != null)
            {
                if (selectedNodes.Contains(clickedNode))
                {
                    DeselectNode(clickedNode);
                }
                else
                {
                    SelectNode(clickedNode);
                }
            }
        }

        private void SelectNode(TreeNode node)
        {
            selectedNodes.Add(node);
            node.BackColor = SystemColors.Highlight;
            node.ForeColor = SystemColors.HighlightText;
        }

        private void DeselectNode(TreeNode node)
        {
            selectedNodes.Remove(node);
            node.BackColor = Color.White;
            node.ForeColor = Color.Black;
        }
    }
}
