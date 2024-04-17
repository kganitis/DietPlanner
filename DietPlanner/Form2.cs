using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DietPlanner
{
    public partial class Form2 : Form
    {
        protected String connectionString = "Data source=DietPlanner.db;Version=3;";
        protected SQLiteConnection connection;

        public int ButtonPressed;
        private FoodPreferences foodPreferences;


        public ListBox ListBox1
        {
            get { return listBox1; }
        }
        public ListBox ListBox2
        {
            get { return listBox; }
        }

        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        private string GenerateNewPatientId()
{
            // Connect to the database
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Query to get the maximum patient_id value
                string selectMaxIdSQL = "SELECT MAX(CAST(SUBSTR(Patient_id, 2) AS INTEGER)) FROM Patient";
                SQLiteCommand maxIdCommand = new SQLiteCommand(selectMaxIdSQL, connection);

                // Execute the query to get the maximum id
                object maxIdResult = maxIdCommand.ExecuteScalar();

                // If there are no records yet, start from "p0000"
                int newIdNumber = maxIdResult == DBNull.Value ? 0 : Convert.ToInt32(maxIdResult) + 1;

                // Format the new patient_id
                string newPatientId = "p" + newIdNumber.ToString("D4"); // D4 ensures 4 digits, padding with leading zeros if necessary

                return newPatientId;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name = usernameTextBox.Text;
            // string gender = genderTextBox.Text;
            string gender = maleRadioButton.Checked ? "Male" : "Female";
            string phone = phoneTextBox.Text;
            string birth = birthTextBox.Text;
            string heightStr = heightTextBox.Text;
            string weightStr = weightTextBox.Text;
            string levelStr = levelTextBox.Text;
            string newPatientId = GenerateNewPatientId();
            List<string> listBoxItems = new List<string>();
            List<string> listBox1Items = new List<string>();
            foreach (var item in listBox.Items)
            { 
                listBoxItems.Add(item.ToString());
            }
            foreach (var item in listBox1.Items) 
            {
                listBox1Items.Add(item.ToString());
            }

            // Check if any of the fields are empty or whitespace
            if (!string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrWhiteSpace(gender) &&
                !string.IsNullOrWhiteSpace(phone) &&
                !string.IsNullOrWhiteSpace(birth) &&
                !string.IsNullOrWhiteSpace(heightStr) &&
                !string.IsNullOrWhiteSpace(weightStr) &&
                !string.IsNullOrWhiteSpace(levelStr))
            {
                // Validate height, weight, and level inputs
                float height, weight, level;
                if (float.TryParse(heightStr, out height) &&
                    float.TryParse(weightStr, out weight) &&
                    float.TryParse(levelStr, out level))
                {
                    try
                    {
                        connection = new SQLiteConnection(connectionString);
                        connection.Open();
                        string insertSQL = "INSERT INTO Patient(Patient_id, Name, Gender, Phone_number, Date_of_birth, Height, Weight, Activity_level) " +
                                  "VALUES (@patientId, @name, @gender, @phone, @date, @height, @weight, @activity)";

                        SQLiteCommand command = new SQLiteCommand(insertSQL, connection);
                        command.Parameters.AddWithValue("@patientId", newPatientId);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@date", birth);
                        command.Parameters.AddWithValue("@height", height);
                        command.Parameters.AddWithValue("@weight", weight);
                        command.Parameters.AddWithValue("@activity", level);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Patient added successfully with ID: " + newPatientId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid numeric values for Height, Weight, and Level.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields!");
            }
            if (listBoxItems.Count > 0 || listBox1Items.Count >0) {
                try
                {
                    connection = new SQLiteConnection(connectionString);
                    connection.Open();

                    // Insert items from listBoxItems with Rule set to Yes
                    foreach (var item in listBoxItems)
                    {
                        string preferSQL = "INSERT INTO Patient_Preferences (Patient_id, Dietary_entity_id, Rule) VALUES (@patientId, @dietaryEntityId, @rule)";
                        SQLiteCommand command = new SQLiteCommand(preferSQL, connection);
                        command.Parameters.AddWithValue("@patientId", newPatientId); // Assuming newPatientId is the patient_id
                        command.Parameters.AddWithValue("@dietaryEntityId", item);
                        command.Parameters.AddWithValue("@rule", "Yes");
                        command.ExecuteNonQuery();
                    }

                    // Insert items from listBox1Items with Rule set to No
                    foreach (var item in listBox1Items)
                    {
                        string avoidSQl = "INSERT INTO Patient_Preferences (Patient_id, Dietary_entity_id, Rule) VALUES (@patientId, @dietaryEntityId, @rule)";
                        SQLiteCommand command = new SQLiteCommand(avoidSQl, connection);
                        command.Parameters.AddWithValue("@patientId", newPatientId); // Assuming newPatientId is the patient_id
                        command.Parameters.AddWithValue("@dietaryEntityId", item);
                        command.Parameters.AddWithValue("@rule", "No");
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Patient preferences added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }



            /*
            try
            {
                string selectSQL = "SELECT Name, Phone_number FROM Patient WHERE Name = @Name AND Phone_number = @PhoneNumber";
                SQLiteCommand command = new SQLiteCommand(selectSQL, connection);
                command.Parameters.AddWithValue("@Name", usernameTextBox.Text);
                command.Parameters.AddWithValue("@PhoneNumber", phoneTextBox.Text);

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(0); // Use index 0 for the Name column
                    string phone = reader.GetString(1); // Use index 1 for the Phone_number column
                    if (usernameTextBox.Text.Equals(name) && phoneTextBox.Text.Equals(phone))
                    {
                        MessageBox.Show("Already Exists!!");
                    }
                    else
                    {
                        MessageBox.Show("New Patient!!");
                    }
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
         */
        }
        private void OpenFoodPreferencesForm()
        {
            if (foodPreferences == null || foodPreferences.IsDisposed)
            {
                foodPreferences = new FoodPreferences();
                foodPreferences.Owner = this;
                foodPreferences.ButtonPressedFromForm2 = this.ButtonPressed;
                foodPreferences.ShowBelowForm(this);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ButtonPressed = 1;
            OpenFoodPreferencesForm();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ButtonPressed = 3;
            OpenFoodPreferencesForm();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int selectedIndex = listBox1.SelectedIndices[i];
                // Remove the item at the selected index
                listBox1.Items.RemoveAt(selectedIndex);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            // Iterate through the selected indices in reverse order
            for (int i = listBox.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int selectedIndex = listBox.SelectedIndices[i];
                // Remove the item at the selected index
                listBox.Items.RemoveAt(selectedIndex);
            }

        }

    }
}
