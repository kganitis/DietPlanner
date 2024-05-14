using System;
using System.Collections.Generic;
using System.Linq;

namespace DietPlanner.Model
{
    public static class ActivityLevel
    {
        public static readonly string SEDENTARY = "Καθιστική ζωή";
        public static readonly string LIGHTLY_ACTIVE = "Ελαφριά δραστηριότητα";
        public static readonly string MODERATELY_ACTIVE = "Μέτρια δραστηριότητα";
        public static readonly string VERY_ACTIVE = "Αυξημένη δραστηριότητα";
        public static readonly string EXTREMELY_ACTIVE = "Υπερβολική δραστηριότητα";

        private static readonly Dictionary<string, float> Coefficients = new Dictionary<string, float>
        {
            { SEDENTARY, 1.2f },
            { LIGHTLY_ACTIVE, 1.375f },
            { MODERATELY_ACTIVE, 1.55f },
            { VERY_ACTIVE, 1.725f },
            { EXTREMELY_ACTIVE, 1.9f }
        };

        public static float GetCoefficient(string activityLevel)
        {
            if (Coefficients.TryGetValue(activityLevel, out float coefficient))
                return coefficient;

            return 0f;
        }

        public static object[] GetActivityLevelsArray() => Coefficients.Keys.ToArray();

        public static string GetLevelFromCoefficient(float coefficient)
        {
            foreach (var kvp in Coefficients)
            {
                if (Math.Abs(kvp.Value - coefficient) < float.Epsilon)
                    return kvp.Key;
            }

            return string.Empty;
        }
    }
}
