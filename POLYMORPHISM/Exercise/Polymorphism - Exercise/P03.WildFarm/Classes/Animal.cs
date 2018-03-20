using P03.WildFarm.Contracts;

namespace P03.WildFarm.Classes
{
    public abstract class Animal : IAnimal
    {
        public Animal()
        {
            
        }
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        public abstract void AskFood();
        public abstract void Eat(IFood food);
    }
}