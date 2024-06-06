using DietPlanner.Model;

namespace DietPlanner.DAO
{
    internal interface IPlanDAO
    {
        bool Save(Plan plan);
        Plan GetPlanForPatient(Patient patient);
    }
}
