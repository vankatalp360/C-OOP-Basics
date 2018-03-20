using P03.WildFarm.Contracts;

namespace P03.WildFarm.Classes.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        public Mammal()
        {
            
        }
        protected Mammal(string name, double weight, string livingRegion) 
            :base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}