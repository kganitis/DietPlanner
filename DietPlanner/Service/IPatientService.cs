using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Service
{
    internal interface IPatientService
    {
        void InsertPatient (Patient patient);
        void SavePreferredFoods(Patient patient);
        void SaveAvoidedFoods(Patient patient);
    }
}
