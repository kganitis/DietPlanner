using DietPlanner.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner
{
    public partial class FormPlan : Form
    {
        private Plan plan;
        private TreeView[] treeViewDay;

        Font boldFont;

        internal FormPlan(Plan plan)
        {
            InitializeComponent();
            this.plan = plan;
            treeViewDay = new TreeView[] { treeViewDay1, treeViewDay2, treeViewDay3, treeViewDay4, treeViewDay5, treeViewDay6, treeViewDay7 };
            boldFont = new Font(treeViewDay1.Font, FontStyle.Bold);
        }

        private void PlanForm_Load(object sender, EventArgs e)
        {
            labelPatientName.Text = $"ΟΝΟΜΑ ΑΣΘΕΝΟΥΣ: {plan.Patient.Name}";
            PopulateTreeView();
        }

        private void PopulateTreeView()
        {
            for (int day = 0; day < treeViewDay.Length; day++)
            {
                var mealItemsForDay = plan.MealPlan.Where(item => item.Day == day + 1).ToList();

                var dayTreeView = treeViewDay[day];
                dayTreeView.Nodes.Clear();

                foreach (var mealItem in mealItemsForDay)
                {
                    var mealTypeNode = new TreeNode(mealItem.Meal.Type.Name);
                    var mealNode = new TreeNode(mealItem.Meal.Name);
                    var caloriesNode = new TreeNode((mealItem.Calories).ToString("0.0") + " kcal");
                    var ingredientsNode = new TreeNode("Υλικά");

                    foreach (var ingredient in mealItem.Ingredients)
                    {
                        var ingredientNode = new TreeNode($"{ingredient.Key.Name}: {ingredient.Value * ingredient.Key.Quantity} {ingredient.Key.Unit}");
                        ingredientsNode.Nodes.Add(ingredientNode);
                    }

                    mealTypeNode.Nodes.Add(mealNode);
                    mealTypeNode.Nodes.Add(caloriesNode);
                    mealTypeNode.Nodes.Add(ingredientsNode);

                    mealTypeNode.NodeFont = boldFont;
                    dayTreeView.Nodes.Add(mealTypeNode);
                }

                foreach (var treeView in treeViewDay)
                {
                    AdjustTreeViewNodeWidth(treeView);
                }

                dayTreeView.ExpandAll();
            }
        }

        private void AdjustTreeViewNodeWidth(TreeView treeView)
        {
            const int extraWidth = 1; // Extra width for bold font
            foreach (TreeNode node in treeView.Nodes)
            {
                Graphics g = treeView.CreateGraphics();
                int width = (int)g.MeasureString(node.Text, treeView.Font).Width + extraWidth;
                node.NodeFont = boldFont;
                node.Text = node.Text.Trim(); // Remove trailing spaces
                node.Text = node.Text.PadRight(width, ' '); // Pad with spaces to adjust width
            }
        }


        private void btnSavePlan_Click(object sender, EventArgs e)
        {

        }

        private void btnRegeneratePlan_Click(object sender, EventArgs e)
        {
            Plan newPlan = new PlanGenerator(plan.Patient).Plan;
            FormPlan formPlan = new FormPlan(newPlan);
            Hide();
            formPlan.Show();
            Close();
        }
    }
}
