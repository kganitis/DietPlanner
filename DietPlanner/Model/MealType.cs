using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class MealType : DietaryEntity
    {
        private string typeID;

        public MealType() { }

        public MealType(string typeID)
        {
            this.TypeID = typeID;
        }

        public string TypeID { get => typeID; set => typeID = value; }
    }
}
