
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
        protected String connectionString = "Data source=DietPlanner.db;Version=3;";
        protected SQLiteConnection connection;
        private ListBox foodsListBoxToFill;
        private List<string> listBoxItems;


        public FormPreferences()
        {
            InitializeComponent();
        }

        public FormPreferences(ListBox foodsListBoxToFill, List<string> listBoxItems)
        {
            InitializeComponent();
            this.foodsListBoxToFill = foodsListBoxToFill;
            this.listBoxItems = listBoxItems;
            RetreiveData();

        }
        private void RetreiveData()
        {

            try
            {
                using (connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string selectCategorySQL = "SELECT Name FROM Food_Category WHERE Name NOT IN ({0})";
                    string selectFoodsSQL = "SELECT Name FROM Food WHERE Name NOT IN ({0})";
                    string selectMealsSQL = "SELECT Name FROM Meal WHERE Name NOT IN ({0})";
                    string selectMealTypeSQL = "SELECT Name FROM Meal_Type WHERE Name NOT IN ({0})";

                    // Convert list of items to a comma-separated string for the SQL query
                    string excludedItemsString = string.Join(",", listBoxItems.Select(item => "'" + item.Replace("'", "''") + "'"));

                    // Format the SQL queries with the excluded items
                    selectCategorySQL = string.Format(selectCategorySQL, excludedItemsString);
                    selectFoodsSQL = string.Format(selectFoodsSQL, excludedItemsString);
                    selectMealsSQL = string.Format(selectMealsSQL, excludedItemsString);
                    selectMealTypeSQL = string.Format(selectMealTypeSQL, excludedItemsString);

                    // Create commands
                    using (SQLiteCommand commandCategory = new SQLiteCommand(selectCategorySQL, connection))
                    using (SQLiteCommand commandFoods = new SQLiteCommand(selectFoodsSQL, connection))
                    using (SQLiteCommand commandMeals = new SQLiteCommand(selectMealsSQL, connection))
                    using (SQLiteCommand commandMealType = new SQLiteCommand(selectMealTypeSQL, connection))
                    {
                        // Execute readers
                        SQLiteDataReader readerCategory = commandCategory.ExecuteReader();
                        SQLiteDataReader readerFoods = commandFoods.ExecuteReader();
                        SQLiteDataReader readerMeals = commandMeals.ExecuteReader();
                        SQLiteDataReader readerMealType = commandMealType.ExecuteReader();

                        DataTable dataTable = new DataTable();
                        dataTable.Load(readerCategory);

                        DataTable dataTableFoods = new DataTable();
                        dataTableFoods.Load(readerFoods);

                        DataTable dataTableMeals = new DataTable();
                        dataTableMeals.Load(readerMeals);

                        DataTable dataTableMealType = new DataTable();
                        dataTableMealType.Load(readerMealType);

                        // Bind the data to the listBoxCategories
                        listBoxCategories.DataSource = dataTable;
                        listBoxCategories.DisplayMember = "Name";

                        listBoxFoods.DataSource = dataTableFoods;
                        listBoxFoods.DisplayMember = "Name";

                        listBoxMeals.DataSource = dataTableMeals;
                        listBoxMeals.DisplayMember = "Name";

                        listBoxMealTypes.DataSource = dataTableMealType;
                        listBoxMealTypes.DisplayMember = "Name";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }


        private void buttonInsert_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();

            // Iterate over the selected items in listBoxCategories
            foreach (DataRowView item in listBoxCategories.SelectedItems)
            {
                // Cast the item to DataRowView and access the "Name" column
                string itemName = item["Name"].ToString();
                selectedItems.Add(itemName);
            }

            // Repeat the same process for other list boxes
            foreach (DataRowView item in listBoxFoods.SelectedItems)
            {
                string itemName = item["Name"].ToString();
                selectedItems.Add(itemName);
            }

            foreach (DataRowView item in listBoxMeals.SelectedItems)
            {
                string itemName = item["Name"].ToString();
                selectedItems.Add(itemName);
            }

            foreach (DataRowView item in listBoxMealTypes.SelectedItems)
            {
                string itemName = item["Name"].ToString();
                selectedItems.Add(itemName);
            }

            // Add selected items to the foodsListBoxToFill
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
