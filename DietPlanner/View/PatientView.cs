using DietPlanner.Controller;
using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace DietPlanner.View
{
    public partial class PatientView : Form
    {
        private PatientController patientController = new PatientController();
        private PlanController planController = new PlanController();

        private PreferencesView formPreferences;

        private Patient patient = null;
        private Plan plan = null;

        #region Getters / Setters

        public string ID
        {
            get { return textBoxID.Text; }
            set { textBoxID.Text = value; }
        }

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
                if (Gender == Model.Gender.FEMALE) { weightCoeff = 9.247f; heightCoeff = 3.098f; ageCoeff = 4.330f; genderCoeff = 447.593f; }
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

        internal Patient Patient
        {
            get => patient;
            set
            {
                patient = value;
                if (value == null)
                {
                    ClearForm();
                    Plan = null;
                }
                else
                {
                    FillFormWithPatientData();
                    Plan = planController.GetPlanForPatient(patient);
                }
            }
        }

        internal Plan Plan
        {
            get => plan;
            set
            {
                plan = value;
                if (plan != null)
                {
                    btnGeneratePlan.Text = "Προβολή Εβδομαδιαίου Πλάνου";
                }
                else
                {
                    btnGeneratePlan.Text = "Έκδοση Εβδομαδιαίου Πλάνου";
                }
            }
        }

        #endregion

        public PatientView()
        {
            InitializeComponent();
        }

        private void FormDataEntry_Load(object sender, EventArgs e)
        {
            comboBoxActivityLevel.Items.AddRange(ActivityLevel.GetActivityLevelsArray());
            comboBoxGoal.Items.AddRange(Goal.GetGoalsArray());
        }

        private void ClearForm()
        {
            ID = String.Empty;
            PatientName = String.Empty;
            Gender = String.Empty;
            PhoneNumber = String.Empty;
            DateOfBirthStr = "01/01/2000";
            heightTextBox.Clear();
            weightTextBox.Clear();
            comboBoxActivityLevel.SelectedItem = null;
            comboBoxGoal.SelectedItem = null;
            listBoxPreferred.Items.Clear();
            listBoxAvoided.Items.Clear();
        }

        private void FillFormWithPatientData()
        {
            if (patient == null)
            {
                return;
            }

            ID = patient.PatientID;
            PatientName = patient.Name;
            Gender = patient.Gender;
            PhoneNumber = patient.PhoneNumber;
            DateOfBirthStr = patient.DateOfBirth.ToString("dd/MM/yyyy");
            PatientHeight = patient.Height;
            PatientWeight = patient.Weight;
            ActivityLevelCoefficient = patient.ActivityLevel;
            GoalValue = patient.Goal;
            FoodsPreferred = patient.PreferredFoods;
            FoodsAvoided = patient.FoodsToAvoid;
        }

        #region Save Data methods
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
            if (SavePatientData())
            {
                MessageBox.Show("Τα στοιχεία αποθηκεύτηκαν με επιτυχία");
            }
        }

        private bool SavePatientData()
        {
            if (EmptyOrInvalidFields())
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία!", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Patient newPatientData = new Patient()
            {
                PatientID = ID,
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

            if (!patientController.InsertNewPatient(newPatientData))
            {
                return false;
            }

           Patient = newPatientData;

            if (Patient.PreferredFoods.Count > 0)
            {
                patientController.SavePreferredFoodsForPatient(Patient);
            }

            if (Patient.FoodsToAvoid.Count > 0)
            {
                patientController.SaveAvoidedFoodsForPatient(Patient);
            }

            return true;
        }

        #endregion

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            Patient = patientController.GetPatientByNameAndPhone(PatientName, PhoneNumber);
        }

        private void UpdateSearchButtonState(object sender, EventArgs e)
        {
            btnSearchPatient.Enabled = !String.IsNullOrEmpty(PatientName) && !String.IsNullOrEmpty(PhoneNumber);
        }

        #region Preferences methods
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
                formPreferences = new PreferencesView(listBoxToFill, exlcudedListBox);
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

        #endregion

        private void btnViewOrGeneratePlan_Click(object sender, EventArgs e)  
        {
            if (!SavePatientData())
            {
                return;
            }

            Plan = planController.GetPlanForPatient(Patient);

            if (Plan == null)
            {
                Plan = planController.GeneratePlanForPatient(Patient);
            }

            PlanView formPlan = new PlanView(this, Plan);
            formPlan.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Patient = null;
        }
    }
}
