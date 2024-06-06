using DietPlanner.Model;

namespace DietPlanner.Service
{
    internal interface IPlanService
    {
        bool SavePlan(Plan plan);
        Plan GetPlanForPatient(Patient patient);
        Plan GeneratePlanForPatient(Patient patient);
    }
}
