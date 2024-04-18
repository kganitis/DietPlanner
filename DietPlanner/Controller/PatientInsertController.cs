using DietPlanner.DAO;
using DietPlanner.DTO;
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
        PatientDTO patientDTO;
        IPatientDAO patientDAO = new PatientDAOImp();
        IPatientService patientService = new PatientServiceImp();
    }
}
