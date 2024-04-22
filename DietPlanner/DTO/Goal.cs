using System.Collections.Generic;
using System.Linq;

namespace DietPlanner.DTO
{
    public static class Goal
    {
        public static readonly string GAIN_WEIGHT = "Αύξηση βάρους";
        public static readonly string LOSE_WEIGHT = "Μείωση βάρους";
        public static readonly string MAINTAIN_WEIGHT = "Διατήρηση βάρους";

        public static readonly Dictionary<string, int> Values = new Dictionary<string, int>
        {
            { GAIN_WEIGHT, 1 },
            { LOSE_WEIGHT, -1 },
            { MAINTAIN_WEIGHT, 0 }
        };

        public static int GetValue(string goal)
        {
            if (Values.TryGetValue(goal, out int value))
                return value;

            return int.MaxValue;
        }

        public static object[] GetGoals => Values.Keys.ToArray();

        public static string GetGoalFromValue(int value)
        {
            foreach (var kvp in Values)
            {
                if (kvp.Value == value)
                    return kvp.Key;
            }

            return string.Empty;
        }
    }
}
