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
    internal class GetPatienByNameAndPhoneController
    {
        public Patient GetPatientByNameAndPhone(string name, string phoneNumber)
        {
            IPatientDAO patientDAO = new PatientDAOImp();
            IPatientService patientService = new PatientServiceImp(patientDAO);
            return patientService.GetPatientByNameAndPhone(name, phoneNumber);
        } 
    }
}
