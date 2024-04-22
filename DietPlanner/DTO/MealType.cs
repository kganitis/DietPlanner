namespace DietPlanner.DTO
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
