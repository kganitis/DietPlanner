using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal class MealTypeView : DietaryEntityView
    {
        private string typeID;

        public MealTypeView() { }

        public MealTypeView(string typeID)
        {
            this.TypeID = typeID;
        }

        public string TypeID { get => typeID; set => typeID = value; }
    }
}
