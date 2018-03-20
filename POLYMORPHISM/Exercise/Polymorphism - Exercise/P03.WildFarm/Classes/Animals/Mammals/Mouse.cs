using System;
using P03.WildFarm.Contracts;

namespace P03.WildFarm.Classes.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double WeightIncrease = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            :base(name, weight, livingRegion)
        {
        }

        public override void AskFood()
        {
            Console.WriteLine("Squeak");
        }

        public override void Eat(IFood food)
        {
            var canEat = Validator.ValidateVegetableAndFruitEating(this.GetType().Name, food.GetType().Name);
            if (canEat)
            {
                Weight += WeightIncrease * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }
    }
}