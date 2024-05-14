using DietPlanner.DAO;
using DietPlanner.Model;
using DietPlanner.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Controller
{
    internal class SavePlanController
    {
        public bool SavePlan(Plan plan)
        {
            IPlanDAO planDAO = new PlanDAOImp();
            IPlanService planService = new PlanServiceImp(planDAO);
            return planService.SavePlan(plan);
        }
    }
}
