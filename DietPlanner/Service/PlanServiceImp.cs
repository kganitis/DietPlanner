using DietPlanner.DAO;
using DietPlanner.Model;

namespace DietPlanner.Service
{
    internal class PlanServiceImp :IPlanService
    {
        private IPlanDAO _planDAO;

        public PlanServiceImp(IPlanDAO planDAO)
        {
            _planDAO = planDAO;
        }

        public bool SavePlan(Plan plan)
        {
            if (_planDAO.Delete(plan))
            {
                return _planDAO.Insert(plan);
            }
            else { return false; }
        }

        public Plan GetPlanForPatient(Patient patient)
        {
            return _planDAO.GetPlanForPatient(patient);
        }

        public Plan GeneratePlanForPatient(Patient patient)
        {
            return new PlanGenerator(patient).Plan;
        }
    }
}
