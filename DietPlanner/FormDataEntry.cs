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
using DietPlanner.DAO.dbutil;
using DietPlanner.DTO;
using DietPlanner.Model;
using DietPlanner.Controller;
using System.Globalization;

namespace DietPlanner
{
    public partial class FormDataEntry : Form
    {
        

        private FormPreferences foodPreferences;


        public ListBox ListBoxPreferred
        {
            get { return listBoxPreferred; }
        }
        public ListBox ListBoxAvoided
        {
            get { return listBoxAvoided; }
        }

        public FormDataEntry()
        {
            InitializeComponent();
        }

        private string GenerateNewPatientId()
        {
            // Connect to the database
            
            {

                SQLiteConnection connection = DBUtil.OpenConnection();

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

        private void OpenFoodPreferencesForm(ListBox foodsListBoxToFill)
        {
            if (foodPreferences == null || foodPreferences.IsDisposed)
            {
                foodPreferences = new FormPreferences(foodsListBoxToFill);
                foodPreferences.Show();
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            string name = usernameTextBox.Text;

            string gender = string.Empty;
            if (maleRadioButton.Checked)
            {
                gender = "M";
            }
            else if (femaleRadioButton.Checked)
            {
                gender = "F";
            }

            string phone = phoneTextBox.Text;
            string birth = birthTextBox.Text;
            string heightStr = heightTextBox.Text;
            string weightStr = weightTextBox.Text;
            string level = activityLevelTextBox.Text;
            string newPatientId = GenerateNewPatientId();
            
            // Check if any of the fields are empty or whitespace
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(birth) ||
                string.IsNullOrWhiteSpace(heightStr) ||
                string.IsNullOrWhiteSpace(weightStr) ||
                string.IsNullOrWhiteSpace(level))
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία!");
                return;
            }

            // Validate height and weight
            float height, weight;
            if (!float.TryParse(heightStr, out height) ||
                !float.TryParse(weightStr, out weight))
            {
                MessageBox.Show("Παρακαλώ εισάγετε μια έγκυρη τιμή για το ύψος και το βάρος.");
                return;
            }

            //Insert a new patient with Service Oriented Architecture (SOA) Impementation

                PatientDTO patientDTO = new PatientDTO();
                patientDTO.PatientID = newPatientId;
                patientDTO.Name = name;
                patientDTO.Gender = gender.Equals("M") ? Gender.male : Gender.female;
                patientDTO.PhoneNumber = phone;
                DateTime birthDate;
                if (DateTime.TryParseExact(birth, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                {
                    patientDTO.DateOfBirth = birthDate;
                } 
                else
                {
                    MessageBox.Show("Invalid birth date format. Please enter the date in the correct format.");
                }
                patientDTO.Height = height;
                patientDTO.Weight = weight;
                patientDTO.ActivityLevel = level;

                PatientInsertController patientInsertController = new PatientInsertController();
                patientInsertController.InsertNewPatient(patientDTO);
                
             
            List<string> foodsPreferred = new List<string>();
            List<string> foodsAvoided = new List<string>();

            foreach (var item in listBoxPreferred.Items)
            {
                foodsPreferred.Add(item.ToString());
            }

            foreach (var item in listBoxAvoided.Items)
            {
                foodsAvoided.Add(item.ToString());
            }
            
            if (foodsPreferred.Count > 0 || foodsAvoided.Count > 0)
            {
                try
                {
                    SQLiteConnection connection = DBUtil.OpenConnection();

                    // Insert items from foodsPreferred with Rule set to Yes
                    foreach (var item in foodsPreferred)
                    {
                        string preferSQL = "INSERT INTO Patient_Preferences (Patient_id, Dietary_entity_id, Rule) VALUES (@patientId, @dietaryEntityId, @rule)";
                        SQLiteCommand command = new SQLiteCommand(preferSQL, connection);
                        command.Parameters.AddWithValue("@patientId", newPatientId); // Assuming newPatientId is the patient_id
                        command.Parameters.AddWithValue("@dietaryEntityId", item);
                        command.Parameters.AddWithValue("@rule", 1);
                        command.ExecuteNonQuery();
                    }

                    // Insert items from foodsAvoided with Rule set to No
                    foreach (var item in foodsAvoided)
                    {
                        string avoidSQl = "INSERT INTO Patient_Preferences (Patient_id, Dietary_entity_id, Rule) VALUES (@patientId, @dietaryEntityId, @rule)";
                        SQLiteCommand command = new SQLiteCommand(avoidSQl, connection);
                        command.Parameters.AddWithValue("@patientId", newPatientId); // Assuming newPatientId is the patient_id
                        command.Parameters.AddWithValue("@dietaryEntityId", item);
                        command.Parameters.AddWithValue("@rule", 0);
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
                    DBUtil.OpenConnection();
                }
            }
        }

        private void btnAddPreferred_Click(object sender, EventArgs e)
        {
            OpenFoodPreferencesForm(listBoxPreferred);
        }

        private void btnRemovePreferred_Click(object sender, EventArgs e)
        {
            for (int i = listBoxPreferred.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int selectedIndex = listBoxPreferred.SelectedIndices[i];
                listBoxPreferred.Items.RemoveAt(selectedIndex);
            }
        }

        private void btnAddAvoided_Click(object sender, EventArgs e)
        {
            OpenFoodPreferencesForm(listBoxAvoided);
        }

        private void btnRemoveAvoided_Click(object sender, EventArgs e)
        {
            for (int i = listBoxAvoided.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int selectedIndex = listBoxAvoided.SelectedIndices[i];
                listBoxAvoided.Items.RemoveAt(selectedIndex);
            }
        }

        
    }
}
