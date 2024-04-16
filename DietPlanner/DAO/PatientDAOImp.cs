using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.DAO
{
    internal class PatientDAOImp : IPatientDAO
    {
        public void AddFoodsToAvoid(string patientId, List<DietaryEntity> foods)
        {
            throw new NotImplementedException();
        }

        public void AddPreferredFoods(string patientId, List<DietaryEntity> foods)
        {
            throw new NotImplementedException();
        }

        public Patient Delete(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(int id)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Save(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void ShowAllItems()
        {
            throw new NotImplementedException();
        }

        public void Update(Patient entity, Patient newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
