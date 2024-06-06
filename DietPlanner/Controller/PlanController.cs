using DietPlanner.DAO;
using DietPlanner.Model;
using DietPlanner.Service;

namespace DietPlanner.Controller
{
    internal class PlanController
    {
        IPlanService planService = new PlanServiceImp(new PlanDAOImp());

        public bool SavePlan(Plan plan)
        {
            return planService.SavePlan(plan);
        }

        public Plan GetPlanForPatient(Patient patient)
        {
            return planService.GetPlanForPatient(patient);
        }

        public Plan GeneratePlanForPatient(Patient patient)
        {
            return planService.GeneratePlanForPatient(patient);
        }
    }
}
