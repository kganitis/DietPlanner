using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.DAO
{
    internal interface IPatientDAO : IGenericDAO<Patient>
    {
        Patient GetPatientById(int id);
        Patient GetPatientByName(string name);
        void AddPreferredFoods(string patientId, List<DietaryEntity> foods);
        void AddFoodsToAvoid(string patientId, List<DietaryEntity> foods);

    }
}
