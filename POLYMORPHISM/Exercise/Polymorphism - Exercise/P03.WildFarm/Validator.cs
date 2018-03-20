using System;

namespace P03.WildFarm
{
    public class Validator
    {
        public static bool ValidateVegetableAndFruitEating(string animalType, string foodType)
        {
            if (foodType == "Vegetable" || foodType == "Fruit")
            {
                return true;
            }
            Console.WriteLine($"{animalType} does not eat {foodType}!");
            return false;
        }

        public static bool ValidateVegetableAndMeatEating(string animalType, string foodType)
        {
            if (foodType == "Vegetable" || foodType == "Meat")
            {
                return true;
            }
            Console.WriteLine($"{animalType} does not eat {foodType}!");
            return false;
        }
        public static bool ValidateMeatEating(string animalType, string foodType)
        {
            if (foodType == "Meat")
            {
                return true;
            }
            Console.WriteLine($"{animalType} does not eat {foodType}!");
            return false;
        }
    }
}