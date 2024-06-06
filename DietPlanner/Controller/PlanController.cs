using DietPlanner.DAO;
using DietPlanner.Model;
using DietPlanner.Service;

namespace DietPlanner.Controller
{
    internal class PlanController
    {
        public bool SavePlan(Plan plan)
        {
            IPlanDAO planDAO = new PlanDAOImp();
            IPlanService planService = new PlanServiceImp(planDAO);
            return planService.SavePlan(plan);
        }

        public Plan GetPlanForPatient(Patient patient)
        {
            IPlanDAO planDAO = new PlanDAOImp();
            IPlanService planService = new PlanServiceImp(planDAO);
            return planService.GetPlanForPatient(patient);
        }

        public Plan GeneratePlanForPatient(Patient patient)
        {
            IPlanDAO planDAO = new PlanDAOImp();
            IPlanService planService = new PlanServiceImp(planDAO);
            return planService.GeneratePlanForPatient(patient);
        }
    }
}
