using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Service
{
    internal interface IPlanService
    {
        bool SavePlan(Plan plan);
        Plan GetPlanForPatient(Patient patient);
    }
}
