
namespace DietPlanner.Model
{
    internal abstract class DietaryEntity
    {
        private string id;
        private string name;

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
