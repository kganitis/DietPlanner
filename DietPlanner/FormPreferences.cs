using DietPlanner.DataFetcher;
using DietPlanner.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DietPlanner
{
    public partial class FormPreferences : Form
    {
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
            get => treeViewFoodCategories.Nodes[0].Tag as FoodCategory;
            set
            {
                treeViewFoodCategories.Nodes.Clear();
                AddNode(treeViewFoodCategories.Nodes, value);
                SearchAndCheckSelectedNodes(treeViewFoodCategories.Nodes[0]);

                void SearchAndCheckSelectedNodes(TreeNode node)
                {
                    if (SelectedEntities.Contains(node.Tag as FoodCategory))
                    {
                        node.Checked = true;
                        node.Nodes.Cast<TreeNode>().ToList().ForEach(childNode => CheckChildNodes(childNode));
                    }
                    else
                    {
                        node.Nodes.Cast<TreeNode>().ToList().ForEach(childNode => SearchAndCheckSelectedNodes(childNode));
                    }
                }

                void AddNode(TreeNodeCollection nodes, FoodCategory category)
                {
                    if (!ExcludedEntities.Contains(category))
                    {
                        TreeNode node = new TreeNode(category.Name)
                        {
                            Tag = category
                        };

                        nodes.Add(node);

                        category.SubCategories.ForEach(subCategory => AddNode(node.Nodes, subCategory));
                    }
                }
            }
        }

        internal List<FoodCategory> SelectedFoodCategories
        {
            get
            {
                List<FoodCategory> selectedCategories = new List<FoodCategory>();

                void GetCheckedNodes(TreeNodeCollection nodes)
                {
                    foreach (TreeNode node in nodes)
                    {
                        if (node.Checked)
                        {
                            selectedCategories.Add(node.Tag as FoodCategory);
                        }

                        GetCheckedNodes(node.Nodes);
                    }
                }

                GetCheckedNodes(treeViewFoodCategories.Nodes);
                return selectedCategories;
            }
        }

        internal List<Food> AllFoods
        {
            get => listBoxFoods.Items.Cast<Food>().ToList();
            set
            {
                listBoxFoods.Items.Clear();
                value.ForEach(food =>
                {
                    listBoxFoods.Items.Add(food);
                    if (SelectedEntities.Contains(food))
                    {
                        listBoxFoods.SelectedItems.Add(food);
                    }
                });

                ExcludedEntities.OfType<Food>().ToList().ForEach(item =>
                {
                    listBoxFoods.Items.Remove(item);
                });
            }
        }

        internal List<Food> SelectedFoods => listBoxFoods.SelectedItems.Cast<Food>().ToList();

        internal List<Meal> AllMeals
        {
            get => listBoxMeals.Items.Cast<Meal>().ToList();
            set
            {
                listBoxMeals.Items.Clear();
                value.ForEach(meal =>
                {
                    listBoxMeals.Items.Add(meal);
                    if (SelectedEntities.Contains(meal))
                    {
                        listBoxMeals.SelectedItems.Add(meal);
                    }
                });

                ExcludedEntities.OfType<Meal>().ToList().ForEach(item =>
                {
                    listBoxMeals.Items.Remove(item);
                });
            }
        }

        internal List<Meal> SelectedMeals => listBoxMeals.SelectedItems.Cast<Meal>().ToList();

        internal List<MealType> AllMealTypes
        {
            get => listBoxMealTypes.Items.Cast<MealType>().ToList();
            set
            {
                listBoxMealTypes.Items.Clear();
                value = value.Where(mealType => mealType.Name == "Dessert" || mealType.Name == "Cheat Meal").ToList();
                value.ForEach(mealType =>
                {
                    listBoxMealTypes.Items.Add(mealType);
                    if (SelectedEntities.Contains(mealType))
                    {
                        listBoxMealTypes.SelectedItems.Add(mealType);
                    }
                });

                ExcludedEntities.OfType<MealType>().ToList().ForEach(item =>
                {
                    listBoxMealTypes.Items.Remove(item);
                });
            }
        }

        internal List<MealType> SelectedMealTypes => listBoxMealTypes.SelectedItems.Cast<MealType>().ToList();

        internal List<DietaryEntity> SelectedEntities => foodsListBoxToFill.Items.Cast<DietaryEntity>().ToList();

        internal List<DietaryEntity> ExcludedEntities => excludedListBox.Items.Cast<DietaryEntity>().ToList();

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

            var allSelectedItems = SelectedFoodCategories.Cast<object>()
                                    .Concat(SelectedFoods)
                                    .Concat(SelectedMeals)
                                    .Concat(SelectedMealTypes);

            foreach (var item in allSelectedItems)
            {
                foodsListBoxToFill.Items.Add(item);
            }

            Close();
        }

        private void treeViewFoodCategories_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Disable event handling to prevent recursive calls
            treeViewFoodCategories.AfterCheck -= treeViewFoodCategories_AfterCheck;

            CheckChildNodes(e.Node);

            // Re-enable event handling
            treeViewFoodCategories.AfterCheck += treeViewFoodCategories_AfterCheck;
        }

        private void CheckChildNodes(TreeNode parentNode)
        {
            foreach (TreeNode childNode in parentNode.Nodes)
            {
                childNode.Checked = parentNode.Checked;
                CheckChildNodes(childNode);
            }
        }
    }
}
