using DietPlanner.DAO;
using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Service
{
    internal class PatientServiceImp : IPatientService
    {
        private IPatientDAO _patientDAO;

        public PatientServiceImp (IPatientDAO patientDAO)
        {
            _patientDAO = patientDAO;
        }

        public void InsertPatient(Patient patient)
        {
            _patientDAO.Save(patient);
        }

        public void SavePreferredFoods(Patient patient)
        {
            _patientDAO.SavePreferredFoodsForPatient(patient);
        }

        public void SaveAvoidedFoods(Patient patient)
        {
            _patientDAO.SaveFoodsAvoidedForPatient(patient);
        }

        public Patient GetPatientByNameAndPhone(string name, string phoneNumber)
        {
            return _patientDAO.GetPatientByNameAndPhone(name, phoneNumber);
        }
    }
}
