using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class PatientView
    {
        private string patientID;
        private string name;
        private string phoneNumber;
        private string gender;
        private DateTime dateOfBirth;
        private int age;
        private float height;
        private float weight;
        private string activityLevel;
        private string goal;
        private List<DietaryEntityView> preferredFoods = new List<DietaryEntityView>();
        private List<DietaryEntityView> foodsToAvoid = new List<DietaryEntityView>();
        
        public PatientView() { }

        public PatientView(string patientID, string name, string phoneNumber, string gender, 
                        DateTime dateOfBirth, float height, float weight, 
                        string activityLevel, string goal, List<DietaryEntityView> preferredFoods, 
                        List<DietaryEntityView> foodsToAvoid)
        {
            this.patientID = patientID;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.age = this.Age;
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
        public int Age
        {
            get
            {
                // Calculate the age based on the current date and the patient's date of birth
                DateTime currentDate = DateTime.Today;
                age = currentDate.Year - dateOfBirth.Year;

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
        internal string ActivityLevel { get => activityLevel; set => activityLevel = value; }
        internal string Goal { get => goal; set => goal = value; }
        internal List<DietaryEntityView> PreferredFoods { get => preferredFoods; set => preferredFoods = value; }
        internal List<DietaryEntityView> FoodsToAvoid { get => foodsToAvoid; set => foodsToAvoid = value; }
    }
}
