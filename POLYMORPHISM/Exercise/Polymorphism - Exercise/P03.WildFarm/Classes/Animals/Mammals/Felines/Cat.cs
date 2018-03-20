using System;
using P03.WildFarm.Contracts;

namespace P03.WildFarm.Classes.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double WeightIncrease = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            :base(name, weight, livingRegion, breed)
        {
        }

        public override void AskFood()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(IFood food)
        {
            var canEat = Validator.ValidateVegetableAndMeatEating(this.GetType().Name, food.GetType().Name);
            if (canEat)
            {
                Weight += WeightIncrease * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }
    }
}