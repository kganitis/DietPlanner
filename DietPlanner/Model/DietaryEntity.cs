using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.Model
{
    internal abstract class DietaryEntity
    {
        private string id;
        private string name;

        protected DietaryEntity() { }

        protected DietaryEntity(string id, string name)
        {
            ID = id;
            Name = name;
        }

        public string Name { get => name; set => name = value; }
        public string ID { get => id; set => id = value; }
    }
}
