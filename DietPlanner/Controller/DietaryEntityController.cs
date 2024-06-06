using DietPlanner.DAO;
using DietPlanner.Model;
using DietPlanner.Service;

namespace DietPlanner.Controller
{
    internal class DietaryEntityController
    {
        public void SavePreferredFoods(Patient patient)
        {
            IPatientDAO patientDAO = new PatientDAOImp();
            IPatientService patientService = new PatientServiceImp(patientDAO);
            patientService.SavePreferredFoods(patient);
        }

        public void SaveAvoidedFoods(Patient patient)
        {
            IPatientDAO patientDAO = new PatientDAOImp();
            IPatientService patientService = new PatientServiceImp(patientDAO);
            patientService.SaveAvoidedFoods(patient);
        }
    }
}
