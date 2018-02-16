using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
        var cars = new Dictionary<string, Car>();

        var inputs = int.Parse(Console.ReadLine());
        for (int i = 0; i < inputs; i++)
        {
            var carInput = Console.ReadLine().Split();
            var model = carInput[0];
            var fuel = double.Parse(carInput[1]);
            var perKm = double.Parse(carInput[2]);
            var car = new Car(model, fuel, perKm);
            cars[model] = car;
        }

        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            var parts = command.Split();
            var model = parts[1];
            var kmAmount = double.Parse(parts[2]);
            cars[model].Drive(kmAmount);
        }

        foreach (var car in cars.Values)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.Distance}");
        }
    }
}
