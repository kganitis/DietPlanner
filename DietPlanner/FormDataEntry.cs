using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner
{
    public partial class FormDataEntry : Form
    {
        protected string connectionString = "Data source=DietPlanner.db;Version=3;";
        protected SQLiteConnection connection;

        private FormPreferences formPreferences;

        public string PatientName
        {
            get { return patientNameTextBox.Text; }
            set { patientNameTextBox.Text = value; }
        }

        #region Getters / Setters

        public string Gender
        {
            get
            {
                if (maleRadioButton.Checked)
                {
                    return "Α";
                }
                else if (femaleRadioButton.Checked)
                {
                    return "Θ";
                }
                else
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε φύλο.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return String.Empty;
                }
            }
            set
            {
                maleRadioButton.Checked = false;
                femaleRadioButton.Checked = false;
                if (value == "Α")
                {
                    maleRadioButton.Checked = true;
                }
                else if (value == "Θ")
                {
                    femaleRadioButton.Checked = true;
                }
            }
        }

        public string PhoneNumber
        {
            get { return phoneTextBox.Text; }
            set { phoneTextBox.Text = value; }
        }

        public string BirthDate
        {
            get { return birthDatePicker.Value.ToString("dd/MM/yyyy"); }
            set
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    birthDatePicker.Value = parsedDate;
                }
                else
                {
                    MessageBox.Show("Μη έγκυρη μορφή ημερομηνίας. Επιτρεπόμενη μορφή: ηη/MM/εεεε.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public int Age
        {
            get
            {
                DateTime birthDate = birthDatePicker.Value;
                DateTime currentDate = DateTime.Today;

                int age = currentDate.Year - birthDate.Year;
                if (birthDate > currentDate.AddYears(-age))
                {
                    age--;
                }
                if (age < 15 || age > 100)
                {
                    MessageBox.Show("Ηλικία: " + age, "Προειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return age;
            }
        }


        public float PatientHeight
        {
            get
            {
                float height;
                if (!float.TryParse(heightTextBox.Text, out height))
                {
                    MessageBox.Show("Παρακαλώ εισάγετε μια έγκυρη τιμή για το ύψος (cm).", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1f;
                }
                return height;
            }
            set
            {
                if (value <= 100 || value >= 250)
                {
                    MessageBox.Show("Το ύψος δεν είναι έγκυρος αριθμός (cm).", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                heightTextBox.Text = value.ToString();
            }
        }

        public float PatientWeight
        {
            get
            {
                float weight;
                if (!float.TryParse(weightTextBox.Text, out weight))
                {
                    MessageBox.Show("Παρακαλώ εισάγετε μια έγκυρη τιμή για το βάρος.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1f;
                }
                return weight;
            }
            set
            {
                if (value <= 100 || value >= 250)
                {
                    MessageBox.Show("Το βάρος δεν είναι έγκυρος αριθμός.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                weightTextBox.Text = value.ToString();
            }
        }

        public float ActivityLevelCoefficient
        {
            get
            {
                float coefficient = 0f;
                if (comboBoxActivityLevel.SelectedItem != null)
                {
                    string selectedValue = comboBoxActivityLevel.SelectedItem.ToString();
                    coefficient = ActivityLevel.GetCoefficient(selectedValue);
                }
                if (coefficient == 0f)
                {
                    MessageBox.Show("Μη έγκυρο επίπεδο δραστηριότητας.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return coefficient;
            }
            set
            {
                string activityLevel = ActivityLevel.GetLevelFromCoefficient(value);
                if (string.IsNullOrEmpty(activityLevel)) return;
                
                foreach (var item in comboBoxActivityLevel.Items)
                {
                    if (item.ToString() == activityLevel)
                    {
                        comboBoxActivityLevel.SelectedItem = item;
                        return;
                    }
                }
                
                MessageBox.Show("Μη έγκυρη τιμή συντελεστή επιπέδου δραστηριότητας.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public double BMR
        {
            /*
             * Harris-Benedict = (13.397m + 4.799h - 5.677a) + 88.362 (MEN)
             * Harris-Benedict = (9.247m + 3.098h - 4.330a) + 447.593 (WOMEN)
             * m is mass in kg, h is height in cm, a is age in years
             */
            get
            {
                if (Gender == String.Empty ||
                PatientHeight == -1f ||
                PatientWeight == -1f ||
                ActivityLevelCoefficient == 0f)
                {
                    return 0f;
                }
                float weightCoeff = 13.397f, heightCoeff = 4.799f, ageCoeff = 5.677f, genderCoeff = 88.632f;
                if (Gender == "Θ") { weightCoeff = 9.247f; heightCoeff = 3.098f; ageCoeff = 4.330f; genderCoeff = 447.593f; }
                return weightCoeff * PatientWeight + heightCoeff * PatientHeight - ageCoeff * Age + genderCoeff;
            }
        }

        public double TDEE => Math.Ceiling(BMR * ActivityLevelCoefficient);

        public int GoalValue
        {
            get
            {
                int value = int.MaxValue;
                if (comboBoxGoal.SelectedItem != null)
                {
                    string selectedValue = comboBoxGoal.SelectedItem.ToString();
                    value = Goal.GetValue(selectedValue);
                }
                if (value == int.MaxValue)
                {
                    MessageBox.Show("Μη έγκυρο επίπεδο δραστηριότητας.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return value;
            }
            set
            {
                string goal = Goal.GetGoalFromValue(value);
                if (string.IsNullOrEmpty(goal)) return;
                
                foreach (var item in comboBoxGoal.Items)
                {
                    if (item.ToString() == goal)
                    {
                        comboBoxGoal.SelectedItem = item;
                        return;
                    }
                }

                MessageBox.Show("Μη έγκυρη τιμή στόχου.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        public FormDataEntry()
        {
            InitializeComponent();
        }

        private void FormDataEntry_Load(object sender, EventArgs e)
        {
            comboBoxActivityLevel.Items.AddRange(ActivityLevel.GetActivityLevels);
            comboBoxGoal.Items.AddRange(Goal.GetGoals);
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

        private void ShowFoodPreferencesForm(ListBox foodsListBoxToFill)
        {
            if (formPreferences == null || formPreferences.IsDisposed)
            {
                formPreferences = new FormPreferences(foodsListBoxToFill);
                formPreferences.Show();
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            // Check if any of the fields are empty or invalid
            if (string.IsNullOrWhiteSpace(PatientName) ||
                string.IsNullOrWhiteSpace(Gender) ||
                string.IsNullOrWhiteSpace(PhoneNumber) ||
                PatientHeight == -1f ||
                PatientWeight == -1f ||
                ActivityLevelCoefficient == 0f)
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία!", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newPatientId = GenerateNewPatientId();

            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
                string insertSQL = "INSERT INTO Patient(Patient_id, Name, Gender, Phone_number, Date_of_birth, Height, Weight, Activity_level) " +
                            "VALUES (@patientId, @name, @gender, @phone, @date, @weight, @weight, @activity)";

                SQLiteCommand command = new SQLiteCommand(insertSQL, connection);
                command.Parameters.AddWithValue("@patientId", newPatientId);
                command.Parameters.AddWithValue("@name", PatientName);
                command.Parameters.AddWithValue("@gender", Gender);
                command.Parameters.AddWithValue("@phone", PhoneNumber);
                command.Parameters.AddWithValue("@date", BirthDate);
                command.Parameters.AddWithValue("@weight", PatientHeight);
                command.Parameters.AddWithValue("@weight", PatientWeight);
                command.Parameters.AddWithValue("@activity", ActivityLevelCoefficient);

                command.ExecuteNonQuery();

                MessageBox.Show("Ο ασθενής καταχωρήθηκε με επιτυχία, με ΑΜ: " + newPatientId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Προέκυψε ένα σφάλμα: " + ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

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
                    connection = new SQLiteConnection(connectionString);
                    connection.Open();

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

                    MessageBox.Show("Οι προτιμήσεις αποθηκεύτηκαν με επιτυχία!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Προέκυψε ένα σφάλμα: " + ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnAddPreferred_Click(object sender, EventArgs e)
        {
            ShowFoodPreferencesForm(listBoxPreferred);
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
            ShowFoodPreferencesForm(listBoxAvoided);
        }

        private void btnRemoveAvoided_Click(object sender, EventArgs e)
        {
            for (int i = listBoxAvoided.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int selectedIndex = listBoxAvoided.SelectedIndices[i];
                listBoxAvoided.Items.RemoveAt(selectedIndex);
            }
        }

        private void btnGeneratePlan_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TDEE.ToString());
        }
    }
}
