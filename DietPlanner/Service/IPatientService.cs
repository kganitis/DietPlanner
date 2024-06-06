using DietPlanner.Model;

namespace DietPlanner.Service
{
    internal interface IPatientService
    {
        bool InsertPatient (Patient patient);
        void SavePreferredFoodsForPatient(Patient patient);
        void SaveAvoidedFoodsForPatient(Patient patient);
        Patient GetPatientByNameAndPhone(string name, string phoneNumber);
    }
}
