
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

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
