using DietPlanner.DAO;
using DietPlanner.Model;
using DietPlanner.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Controller
{
    internal class PatientInsertController
    {
        public void InsertNewPatient(Patient patient)
        {
            IPatientDAO patientDAO = new PatientDAOImp();
            IPatientService patientService = new PatientServiceImp(patientDAO);
            patientService.InsertPatient(patient);
        }
    }
}
