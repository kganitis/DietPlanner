using DietPlanner.Model;
using System.Collections.Generic;

namespace DietPlanner.DAO
{
    internal interface IPatientDAO
    {
        bool Insert(Patient patient);
        string GetNextAvailablePatientID();
        bool Delete(Patient patient);
        Patient GetPatientByNameAndPhone(string name, string phoneNum);
        List<DietaryEntity> GetPreferredFoodsForPatient(Patient patient);
        List<DietaryEntity> GetAvoidedFoodsForPatient(Patient patient);
        void InsertPreferredFoodsForPatient(Patient patient);
        void InsertFoodsAvoidedForPatient(Patient patient);
    }
}
