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
        private ListBox foodsListBoxToFill;

        public FormPreferences()
        {
            InitializeComponent();
        }

        public FormPreferences(ListBox foodsListBoxToFill)
        {
            InitializeComponent();
            RetreiveData();
            this.foodsListBoxToFill = foodsListBoxToFill;
        }

        private void RetreiveData()
        {
            
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();

            foreach (string item in listBoxCategories.SelectedItems)
            {
                selectedItems.Add(item);
            }
            foreach (string item in listBoxFoods.SelectedItems)
            {
                selectedItems.Add(item);
            }
            foreach (string item in listBoxMeals.SelectedItems)
            {
                selectedItems.Add(item);
            }
            foreach (string item in listBoxMealTypes.SelectedItems)
            {
                selectedItems.Add(item);
            }

            if (foodsListBoxToFill != null)
            {
                foreach (string item in selectedItems)
                {
                    foodsListBoxToFill.Items.Add(item);
                }
            }

            this.Close();
        }
    }
}
