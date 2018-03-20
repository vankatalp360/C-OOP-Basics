using System;
using P03.WildFarm.Contracts;

namespace P03.WildFarm.Classes.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double WeightIncrease = 0.4;
        public Dog()
        {
            
        }
        public Dog(string name, double weight, string livingRegion) 
            :base(name, weight, livingRegion)
        {
        }

        public override void AskFood()
        {
            Console.WriteLine("Woof!");
        }

        public override void Eat(IFood food)
        {
            var canEat = Validator.ValidateMeatEating(this.GetType().Name, food.GetType().Name);
            if (canEat)
            {
                Weight += WeightIncrease * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }
    }
}