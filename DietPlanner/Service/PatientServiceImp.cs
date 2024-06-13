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

        public bool SavePatient(Patient patient)
        {
            // Generate a new ID if needed
            if (string.IsNullOrEmpty(patient.PatientID))
            {
                patient.PatientID = _patientDAO.GetNextAvailablePatientID();
            }

            if (_patientDAO.Delete(patient))
            {
                return _patientDAO.Insert(patient);
            }

            return false;
        }

        public void SavePreferredFoodsForPatient(Patient patient)
        {
            _patientDAO.InsertPreferredFoodsForPatient(patient);
        }

        public void SaveAvoidedFoodsForPatient(Patient patient)
        {
            _patientDAO.InsertFoodsAvoidedForPatient(patient);
        }

        public Patient GetPatientByNameAndPhone(string name, string phoneNumber)
        {
            Patient patient = _patientDAO.GetPatientByNameAndPhone(name, phoneNumber);
            if (patient != null)
            {
                patient.PreferredFoods = _patientDAO.GetPreferredFoodsForPatient(patient);
                patient.FoodsToAvoid = _patientDAO.GetAvoidedFoodsForPatient(patient);
            }
            
            return patient;
        }
    }
}
