using System;
using P03.WildFarm.Contracts;

namespace P03.WildFarm.Classes.Animals.Birds
{
    public class Hen : Bird
    {
        private const double WeightIncrease = 0.35;
        public Hen(string name, double weight, double wingSize) 
            :base(name, weight, wingSize)
        {
        }

        public override void AskFood()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(IFood food)
        {
            Weight += food.Quantity * WeightIncrease;
            FoodEaten += food.Quantity;
        }
    }
}