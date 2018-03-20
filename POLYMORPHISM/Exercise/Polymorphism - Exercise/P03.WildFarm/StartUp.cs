using System;
using System.Collections.Generic;
using System.Linq;
using P03.WildFarm.Classes;
using P03.WildFarm.Classes.Animals.Birds;
using P03.WildFarm.Classes.Animals.Mammals;
using P03.WildFarm.Classes.Animals.Mammals.Felines;
using P03.WildFarm.Classes.Foods;
using P03.WildFarm.Contracts;

namespace P03.WildFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var animals = new List<IAnimal>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var animalArgs = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Animal animal;
                animal = ReadAnimal(animalArgs);
                animal.AskFood();

                var foodArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Food food;
                food = ReadFood(foodArgs);

                animal.Eat(food);
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food ReadFood(string[] foodArgs)
        {
            Food food;
            var foodType = foodArgs[0];
            var quantity = int.Parse(foodArgs[1]);
            switch (foodType)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Fruit":
                    food = new Fruit(quantity);
                    break;
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
                default:
                    food = new Fruit();
                    break;
            }

            return food;
        }

        private static Animal ReadAnimal(string[] animalArgs)
        {
            Animal animal;
            var animalType = animalArgs[0];
            switch (animalType)
            {
                case "Hen":
                case "Owl":
                    animal = AddBird(animalArgs);
                    break;
                case "Mouse":
                case "Dog":
                    animal = AddMouseOrDog(animalArgs);
                    break;
                case "Cat":
                case "Tiger":
                    animal = AddFeline(animalArgs);
                    break;
                default:
                    animal = new Dog();
                    break;
            }

            return animal;
        }

        private static Animal AddFeline(string[] animalArgs)
        {
            var type = animalArgs[0];
            var name = animalArgs[1];
            var weight = double.Parse(animalArgs[2]);
            var region = animalArgs[3];
            var breed = animalArgs[4];
            Animal feline;
            if (type == "Cat")
            {
                feline = new Cat(name, weight, region, breed);
            }
            else
            {
                feline = new Tiger(name, weight, region, breed);
            }
            return feline;
        }

        private static Animal AddMouseOrDog(string[] animalArgs)
        {
            var type = animalArgs[0];
            var name = animalArgs[1];
            var weight = double.Parse(animalArgs[2]);
            var region = animalArgs[3];
            Animal animal;
            if (type == "Mouse")
            {
                animal = new Mouse(name, weight, region);
            }
            else
            {
                animal = new Dog(name, weight, region);
            }
            return animal;
        }

        private static Animal AddBird(string[] animalArgs)
        {
            var type = animalArgs[0];
            var name = animalArgs[1];
            var weight = double.Parse(animalArgs[2]);
            var wingSize = double.Parse(animalArgs[3]);
            Animal bird;
            if (type == "Owl")
            {
                bird = new Owl(name, weight, wingSize);
            }
            else
            {
                bird = new Hen(name, weight, wingSize);
            }
            return bird;
        }
    }
}
