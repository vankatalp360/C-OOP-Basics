using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            var cars = new Dictionary<string, Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                var engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                var cargo = new Cargo(cargoWeight, cargoType);

                var tires = new Tire[4];
                AddTires(parameters.Skip(5).ToArray(), tires);
                var car = new Car(model, engine, cargo, tires);
                cars[model] = car;
            }

            ReadCommand(cars);
        }

        private static void ReadCommand(Dictionary<string, Car> cars)
        {
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                cars = cars.Where(c => c.Value.Cargo.Type == "fragile")
                    .Where(c => c.Value.Tires.Any(t => t.Pressure < 1))
                    .ToDictionary(c => c.Key, k => k.Value);

                foreach (var car in cars.Keys)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                cars = cars.Where(c => c.Value.Cargo.Type == "flamable")
                    .Where(c => c.Value.Engine.Power > 250)
                    .ToDictionary(c => c.Key, k => k.Value);

                foreach (var car in cars.Keys)
                {
                    Console.WriteLine(car);
                }
            }
        }


        private static void AddTires(string[] parameters, Tire[] tires)
        {
            for (int i = 0; i < 8; i+=2)
            {
                var pressure = double.Parse(parameters[i]);
                var age = int.Parse(parameters[i + 1]);
                var tire = new Tire(age, pressure);
                tires[i / 2] = tire;
            }
        }
    }
}
