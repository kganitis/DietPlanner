using DietPlanner.DAO;
using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Service
{
    internal class PlanServiceImp :IPlanService
    {
        private IPlanDAO _planDAO;

        public PlanServiceImp(IPlanDAO planDAO)
        {
            _planDAO = planDAO;
        }

        public bool SavePlan (Plan plan)
        {
           return _planDAO.Save(plan);
        }

        public Plan GetPlanForPatient(Patient patient)
        {
            return _planDAO.GetPlanForPatient(patient);
        }
    }
}
