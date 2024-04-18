using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal abstract class DietaryEntityView
    {
        private string name;

        protected DietaryEntityView() { }

        protected DietaryEntityView(string name)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }
    }
}
