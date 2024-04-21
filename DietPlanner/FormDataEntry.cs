using DietPlanner.DataFetcher;
using DietPlanner.View;
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
using System.Xml.Linq;

namespace DietPlanner
{
    public partial class FormDataEntry : Form
    {
        private FormPreferences formPreferences;

        private string testPatientID = "p0000";

        #region Getters / Setters

        public string PatientName
        {
            get { return patientNameTextBox.Text; }
            set { patientNameTextBox.Text = value; }
        }

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

        public string DateOfBirthStr
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

        public DateTime DateOfBirth
        {
            get { return birthDatePicker.Value; }
            set { birthDatePicker.Value = value;}
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
                if (value <= 30 || value >= 300)
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
                if (Gender == View.Gender.FEMALE) { weightCoeff = 9.247f; heightCoeff = 3.098f; ageCoeff = 4.330f; genderCoeff = 447.593f; }
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
                    MessageBox.Show("Μη έγκυρη τιμή στόχου.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        internal List<DietaryEntity> FoodsPreferred
        {
            get
            {
                List<DietaryEntity> foodsPreferred = new List<DietaryEntity>();
                foreach (var item in listBoxPreferred.Items)
                {
                    foodsPreferred.Add(item as DietaryEntity);
                }
                return foodsPreferred;
            }
            set
            {
                listBoxPreferred.Items.Clear();
                foreach (var item in value)
                {
                    listBoxPreferred.Items.Add(item);
                }
            }
        }

        internal List<DietaryEntity> FoodsAvoided
        {
            get
            {
                List<DietaryEntity> foodsAvoided = new List<DietaryEntity>();
                foreach (var item in listBoxAvoided.Items)
                {
                    foodsAvoided.Add(item as DietaryEntity);
                }
                return foodsAvoided;
            }
            set
            {
                listBoxAvoided.Items.Clear();
                foreach (var item in value)
                {
                    listBoxAvoided.Items.Add(item);
                }
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
            LoadPatientDataByID(testPatientID);
        }

        private bool EmptyOrInvalidFields()
        {
            return string.IsNullOrWhiteSpace(PatientName) ||
                string.IsNullOrWhiteSpace(Gender) ||
                string.IsNullOrWhiteSpace(PhoneNumber) ||
                PatientHeight == -1f ||
                PatientWeight == -1f ||
                ActivityLevelCoefficient == 0f ||
                GoalValue == int.MaxValue;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (EmptyOrInvalidFields())
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία!", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Patient newPatient = new Patient()
            {
                PatientID = DataAccess.GetNextAvailablePatientID(),
                Name = PatientName,
                Gender = Gender,
                PhoneNumber = PhoneNumber,
                DateOfBirth = DateOfBirth,
                Height = PatientHeight,
                Weight = PatientWeight,
                ActivityLevel = ActivityLevelCoefficient,
                Goal = GoalValue,
                PreferredFoods = FoodsPreferred,
                FoodsToAvoid = FoodsAvoided
            };

            DataAccess.SavePatientData(newPatient);
            
            if (newPatient.PreferredFoods.Count > 0)
            {
                DataAccess.SavePreferredFoodsForPatient(newPatient);
            }

            if (newPatient.FoodsToAvoid.Count > 0)
            {
                DataAccess.SaveFoodsAvoidedForPatient(newPatient);
            }
        }

        private void btnAddPreferred_Click(object sender, EventArgs e)
        {
            ShowFoodPreferencesForm(listBoxPreferred, listBoxAvoided);
        }

        private void btnAddAvoided_Click(object sender, EventArgs e)
        {
            ShowFoodPreferencesForm(listBoxAvoided, listBoxPreferred);
        }

        private void ShowFoodPreferencesForm(ListBox listBoxToFill, ListBox exlcudedListBox)
        {
            if (formPreferences == null || formPreferences.IsDisposed)
            {
                formPreferences = new FormPreferences(listBoxToFill, exlcudedListBox);
                formPreferences.Show();
            }
        }

        private void btnRemovePreferred_Click(object sender, EventArgs e)
        {
            RemoveItemFromListBox(listBoxPreferred);
        }

        private void btnRemoveAvoided_Click(object sender, EventArgs e)
        {
            RemoveItemFromListBox(listBoxAvoided);
        }

        private void RemoveItemFromListBox(ListBox listBox)
        {
            for (int i = listBox.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int selectedIndex = listBox.SelectedIndices[i];
                listBox.Items.RemoveAt(selectedIndex);
            }
        }

        private void btnGeneratePlan_Click(object sender, EventArgs e)
        {
            Patient patient = DataAccess.GetPatientByID(testPatientID);
            patient.PreferredFoods = FoodsPreferred;
            patient.FoodsToAvoid = FoodsAvoided;
            new PlanGenerator(patient);
        }

        private void LoadPatientDataByID(string patientID)
        {
            Patient patientData = DataAccess.GetPatientByID(patientID);
            
            PatientName = patientData.Name;
            Gender = patientData.Gender;
            PhoneNumber = patientData.PhoneNumber;
            DateOfBirthStr = patientData.DateOfBirth.ToString("dd/MM/yyyy");
            PatientHeight = patientData.Height;
            PatientWeight = patientData.Weight;
            ActivityLevelCoefficient = patientData.ActivityLevel;
            GoalValue = patientData.Goal;

            List<DietaryEntity>[] foodsPreferences = DataAccess.GetAllPreferencesByPatientID(patientID);

            FoodsPreferred = foodsPreferences[1];
            FoodsAvoided = foodsPreferences[0];
        }
    }
}
