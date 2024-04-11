using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class Patient
    {
        private string patientID { get; set; }
        private string name { get; set; }
        private string phoneNumber { get; set; }
        private DateTime dateOfBirth { get; set; }
        private int age { get; set; }
        private float height { get; set; }
        private float weight { get; set; }
        private ActivityLevel activityLevel { get; set; }
        private Diet diet { get; set; }
        public List<DietaryEntity> preferredFoods { get; set; }
        public List<DietaryEntity> foodsToAvoid { get; set; }
        public Plan plan { get; set; }


    }
}
