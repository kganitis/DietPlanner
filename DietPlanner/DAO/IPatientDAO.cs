using DietPlanner.Model;

namespace DietPlanner.DAO
{
    internal interface IPatientDAO
    {
        bool Save(Patient patient);
        Patient GetPatientByNameAndPhone(string name, string phoneNum);
        void SavePreferredFoodsForPatient(Patient patient);
        void SaveFoodsAvoidedForPatient(Patient patient);
    }
}
