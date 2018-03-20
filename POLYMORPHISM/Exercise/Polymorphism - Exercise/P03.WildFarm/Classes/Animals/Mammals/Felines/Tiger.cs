using System;
using P03.WildFarm.Contracts;

namespace P03.WildFarm.Classes.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double WeightIncrease = 1;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            :base(name, weight, livingRegion, breed)
        {
        }

        public override void AskFood()
        {
            Console.WriteLine("ROAR!!!");
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