using System;
using System.Collections.Generic;
using System.Globalization;

namespace DietPlanner.Model
{
    internal class Patient
    {
        private string patientID;
        private string name;
        private string phoneNumber;
        private string gender;
        private DateTime dateOfBirth;
        private float height;
        private float weight;
        private float activityLevel;
        private int goal;
        private List<DietaryEntity> preferredFoods = new List<DietaryEntity>();
        private List<DietaryEntity> foodsToAvoid = new List<DietaryEntity>();
        
        public Patient() { }

        public Patient(string patientID, string name, string phoneNumber, string gender, 
                        DateTime dateOfBirth, float height, float weight,
                        float activityLevel, int goal, List<DietaryEntity> preferredFoods, 
                        List<DietaryEntity> foodsToAvoid)
        {
            this.patientID = patientID;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.height = height;
            this.weight = weight;
            this.activityLevel = activityLevel;
            this.goal = goal;
            this.preferredFoods = preferredFoods;
            this.foodsToAvoid = foodsToAvoid;
        }
                
        public string PatientID { get => patientID; set => patientID = value; }
        public string Name { get => name; set => name = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string DateOfBirthStr
        {
            get { return dateOfBirth.ToString("dd/MM/yyyy"); }
            set
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    dateOfBirth = parsedDate;
                }
            }
        }
        public int Age
        {
            get
            {
                // Calculate the age based on the current date and the patient's date of birth
                DateTime currentDate = DateTime.Today;
                int age = currentDate.Year - dateOfBirth.Year;

                // Check if the birthday has occurred this year
                if (currentDate < dateOfBirth.AddYears(age))
                {
                    age--;
                }

                return age;
            }
        }
        internal string Gender { get => gender; set => gender = value; }
        public float Height { get => height; set => height = value; }
        public float Weight { get => weight; set => weight = value; }
        internal float ActivityLevel { get => activityLevel; set => activityLevel = value; }
        internal int Goal { get => goal; set => goal = value; }
        internal List<DietaryEntity> PreferredFoods { get => preferredFoods; set => preferredFoods = value; }
        internal List<DietaryEntity> FoodsToAvoid { get => foodsToAvoid; set => foodsToAvoid = value; }

        public double BMR
        {
            /*
             * Harris-Benedict = (13.397m + 4.799h - 5.677a) + 88.362 (MEN)
             * Harris-Benedict = (9.247m + 3.098h - 4.330a) + 447.593 (WOMEN)
             * m is mass in kg, h is height in cm, a is age in years
             */
            get
            {
                float weightCoeff = 13.397f, heightCoeff = 4.799f, ageCoeff = 5.677f, genderCoeff = 88.632f;
                if (Gender == Model.Gender.FEMALE) { weightCoeff = 9.247f; heightCoeff = 3.098f; ageCoeff = 4.330f; genderCoeff = 447.593f; }
                return weightCoeff * Weight + heightCoeff * Height - ageCoeff * Age + genderCoeff;
            }
        }

        public double TDEE => Math.Ceiling(BMR * ActivityLevel);
    }
}
