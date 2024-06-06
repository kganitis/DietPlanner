using DietPlanner.DAO;
using DietPlanner.Model;

namespace DietPlanner.Service
{
    internal class PatientServiceImp : IPatientService
    {
        private IPatientDAO _patientDAO;

        public PatientServiceImp (IPatientDAO patientDAO)
        {
            _patientDAO = patientDAO;
        }

        public bool InsertPatient(Patient patient)
        {
            return _patientDAO.Save(patient);
        }

        public void SavePreferredFoodsForPatient(Patient patient)
        {
            _patientDAO.SavePreferredFoodsForPatient(patient);
        }

        public void SaveAvoidedFoodsForPatient(Patient patient)
        {
            _patientDAO.SaveFoodsAvoidedForPatient(patient);
        }

        public Patient GetPatientByNameAndPhone(string name, string phoneNumber)
        {
            return _patientDAO.GetPatientByNameAndPhone(name, phoneNumber);
        }
    }
}
