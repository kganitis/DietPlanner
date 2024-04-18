using DietPlanner.DAO;
using DietPlanner.DTO;
using DietPlanner.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Service
{
    internal class PatientServiceImp : IPatientService
    {
        private readonly IPatientDAO _patientDAO;

        public void InsertPatient(PatientDTO patientDTO)
        {
            Patient newPatient = new Patient();
            newPatient.PatientID = patientDTO.PatientID;
            newPatient.Name = patientDTO.Name;
            newPatient.PhoneNumber = patientDTO.PhoneNumber;
            newPatient.Gender = patientDTO.Gender;
            newPatient.DateOfBirth = patientDTO.DateOfBirth;
            newPatient.Height = patientDTO.Height;
            newPatient.Weight = patientDTO.Weight;
            newPatient.ActivityLevel = patientDTO.ActivityLevel;
            newPatient.Goal = patientDTO.Goal;

            _patientDAO.Save(newPatient);// method needs to implement a check for not storing an already existing Patient
        }
    }
}
