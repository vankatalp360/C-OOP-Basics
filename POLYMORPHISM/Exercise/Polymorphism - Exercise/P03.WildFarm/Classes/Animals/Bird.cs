using P03.WildFarm.Contracts;

namespace P03.WildFarm.Classes.Animals
{
    public abstract class Bird : Animal, IBird
    {
        public Bird()
        {
            
        }
        protected Bird(string name, double weight, double wingSize) 
            :base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}