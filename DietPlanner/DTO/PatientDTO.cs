using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.DTO
{
    internal class PatientDTO
    {
        private string patientID;
        private string name;
        private string phoneNumber;
        private Gender gender;
        private DateTime dateOfBirth;
        private float height;
        private float weight;
        private string activityLevel;
        private string goal;
        private List<DietaryEntity> preferredFoods = new List<DietaryEntity>();
        private List<DietaryEntity> foodsToAvoid = new List<DietaryEntity>();

        public PatientDTO() { }

        public PatientDTO(string patientID, string name, string phoneNumber, Gender gender,
                        DateTime dateOfBirth, float height, float weight, string activityLevel, string goal)
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
        }

        public string PatientID { get => patientID; set => patientID = value; }
        public string Name { get => name; set => name = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
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
        internal Gender Gender { get => gender; set => gender = value; }
        public float Height { get => height; set => height = value; }
        public float Weight { get => weight; set => weight = value; }
        internal string ActivityLevel { get => activityLevel; set => activityLevel = value; }
        internal string Goal { get => goal; set => goal = value; }
        internal List<DietaryEntity> PreferredFoods { get => preferredFoods; set => preferredFoods = value; }
        internal List<DietaryEntity> FoodsToAvoid { get => foodsToAvoid; set => foodsToAvoid = value; }
    }
}

