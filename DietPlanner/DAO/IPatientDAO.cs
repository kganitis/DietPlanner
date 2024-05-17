using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
