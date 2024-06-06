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

        public bool SavePlan (Plan plan)
        {
           return _planDAO.Save(plan);
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
