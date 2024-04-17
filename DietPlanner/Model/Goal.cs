using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    public static class Goal
    {
        public static readonly string GAIN_WEIGHT = "Αύξηση βάρους";
        public static readonly string LOSE_WEIGHT = "Μείωση βάρους";
        public static readonly string MAINTAIN_WEIGHT = "Διατήρηση βάρους";

        public static int GetValue(string goal)
        {
            if (goal == GAIN_WEIGHT)
                return 1;
            else if (goal == LOSE_WEIGHT)
                return -1;
            else
                return 0;
        }
    }
}
