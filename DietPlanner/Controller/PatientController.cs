using DietPlanner.DAO;
using DietPlanner.Model;
using DietPlanner.Service;

namespace DietPlanner.Controller
{
    internal class PatientController
    {
        IPatientService patientService = new PatientServiceImp(new PatientDAOImp());

        public bool InsertNewPatient(Patient patient)
        {
            return patientService.InsertPatient(patient);
        }

        public Patient GetPatientByNameAndPhone(string name, string phoneNumber)
        {
            return patientService.GetPatientByNameAndPhone(name, phoneNumber);
        }

        public void SavePreferredFoodsForPatient(Patient patient)
        {
            patientService.SavePreferredFoodsForPatient(patient);
        }

        public void SaveAvoidedFoodsForPatient(Patient patient)
        {
            patientService.SaveAvoidedFoodsForPatient(patient);
        }
    }
}
