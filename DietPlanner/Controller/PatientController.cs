using DietPlanner.DAO;
using DietPlanner.Model;
using DietPlanner.Service;

namespace DietPlanner.Controller
{
    internal class PatientController
    {
        public bool InsertNewPatient(Patient patient)
        {
            IPatientDAO patientDAO = new PatientDAOImp();
            IPatientService patientService = new PatientServiceImp(patientDAO);
            return patientService.InsertPatient(patient);
        }

        public Patient GetPatientByNameAndPhone(string name, string phoneNumber)
        {
            IPatientDAO patientDAO = new PatientDAOImp();
            IPatientService patientService = new PatientServiceImp(patientDAO);
            return patientService.GetPatientByNameAndPhone(name, phoneNumber);
        }
    }
}
