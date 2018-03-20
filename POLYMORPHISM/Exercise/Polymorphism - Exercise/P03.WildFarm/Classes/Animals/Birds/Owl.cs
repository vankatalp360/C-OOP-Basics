using System;
using P03.WildFarm.Contracts;

namespace P03.WildFarm.Classes.Animals.Birds
{
    public class Owl : Bird
    {
        private const double WeightIncrease = 0.25;
        public Owl(string name, double weight, double wingSize) 
            :base(name, weight, wingSize)
        {
        }

        public override void AskFood()
        {
            Console.WriteLine("Hoot Hoot");
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