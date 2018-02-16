using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var carsCount = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            var carArgs = Console.ReadLine().Split();
            var model = carArgs[0];
            var engineSpeed = int.Parse(carArgs[1]);
            var enginePower = int.Parse(carArgs[2]);
            var cargoWeight = int.Parse(carArgs[3]);
            var cargoType = carArgs[4];

            var engine = new Engine(engineSpeed, enginePower);
            var cargo = new Cargo(cargoWeight, cargoType);
            var car = new Car(model, engine, cargo);
            var tireCount = 0;
            for (int j = 5; j <= 11; j += 2)
            {
                var pressure = double.Parse(carArgs[j]);
                var age = int.Parse(carArgs[j + 1]);
                var tire = new Tire(pressure, age);

                car.Tires[tireCount] = tire;
                tireCount++;
            }

            cars.Add(car);
        }

        var command = Console.ReadLine();

        if (command == "fragile")
        {
            foreach (var car in cars.Where(c => c.Cargo.Type == "fragile"))
            {
                foreach (var tire in car.Tires)
                {
                    if (tire.Pressure < 1)
                    {
                        Console.WriteLine(car.Model);
                        break;
                    }
                }
            }
        }
        else
        {
            foreach (var car in cars.Where(c => c.Cargo.Type == "flamable"))
            {
                if (car.Engine.Power > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
