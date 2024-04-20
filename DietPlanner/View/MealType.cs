using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.View
{
    internal class MealType : DietaryEntity
    {
        public MealType() { }

        public MealType(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
