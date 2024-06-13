using DietPlanner.Model;

namespace DietPlanner.DAO
{
    internal interface IPlanDAO
    {
        bool Insert(Plan plan);
        bool Delete(Plan plan);
        Plan GetPlanForPatient(Patient patient);
    }
}
