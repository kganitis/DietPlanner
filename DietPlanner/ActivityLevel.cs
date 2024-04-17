using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner
{
    public static class ActivityLevel
    {
        public static readonly string SEDENTARY = "Καθιστική ζωή";
        public static readonly string LIGHTLY_ACTIVE = "Ελαφριά δραστηριότητα";
        public static readonly string MODERATE_ACTIVE = "Μέτρια δραστηριότητα";
        public static readonly string VERY_ACTIVE = "Αυξημένη δραστηριότητα";
        public static readonly string EXTREMELY_ACTIVE = "Υπερβολική δραστηριότητα";

        public static float GetValue(string activityLevel)
        {
            if (activityLevel == SEDENTARY)
                return 1f;
            else if (activityLevel == LIGHTLY_ACTIVE)
                return 1.25f;
            else if (activityLevel == MODERATE_ACTIVE)
                return 1.5f;
            else if (activityLevel == VERY_ACTIVE)
                return 1.75f;
            else if (activityLevel == EXTREMELY_ACTIVE)
                return 2f;
            else
                return 0f;
        }
    }
}
