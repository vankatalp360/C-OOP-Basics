using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var animals = new List<Animal>();
        string command;

        while ((command = Console.ReadLine()) != "Beast!")
        {
            try
            {
                ReadAnimals(animals, command);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void ReadAnimals(List<Animal> animals, string command)
    {
        Animal animal = new Animal();
        string animalType = "";
        for (int i = 0; i < 2; i++)
        {
            if (i == 1)
            {
                command = Console.ReadLine();
            }
            var input = command.Split(new[] { ' ' }, StringSplitOptions.None);
            if (input.Length == 1)
            {
                animalType = input[0];
            }
            else if (input.Length == 3)
            {
                var name = input[0];
                var age = int.Parse(input[1]);
                var gender = "";
                if (input.Length == 3)
                {
                    gender = input[2];
                }
                switch (animalType)
                {
                    case "Cat":
                        animal = new Cat(name, age, gender);
                        break;
                    case "Dog":
                        animal = new Dog(name, age, gender);
                        break;
                    case "Frog":
                        animal = new Frog(name, age, gender);
                        break;
                    case "Tomcat":
                        animal = new Tomcat(name, age);
                        break;
                    case "Kitten":
                        animal = new Kitten(name, age);
                        break;
                    default: throw new ArgumentException($"Invalid input!");
                }
                animals.Add(animal);
            }
            else
            {
                throw new ArgumentException($"Invalid input!");
            }
        }
    }
}