using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.DAO
{
    internal interface IPlanDAO
    {
        bool Save(Plan plan);
        Plan GetPlanForPatient(Patient patient);
    }
}
