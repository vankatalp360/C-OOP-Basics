﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    class CarSalesman
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                CreateEngine(engines, parameters);
            }

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                CreateCar(cars, engines, parameters);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void CreateCar(List<Car> cars, List<Engine> engines, string[] parameters)
        {
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);
            Car car;
            int weight = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
            {
                car = new Car(model, engine, weight);
            }
            else if (parameters.Length == 3)
            {
                string color = parameters[2];
                car = new Car(model, engine, color);
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                car = new Car(model, engine, int.Parse(parameters[2]), color);
            }
            else
            {
                car = new Car(model, engine);
            }

            cars.Add(car);
        }

        private static void CreateEngine(List<Engine> engines, string[] parameters)
        {
            string model = parameters[0];
            int power = int.Parse(parameters[1]);
            int displacement = -1;
            Engine engine;
            if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
            {
                engine = new Engine(model, power, displacement);
            }
            else if (parameters.Length == 3)
            {
                string efficiency = parameters[2];
                engine = new Engine(model, power, efficiency);
            }
            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];
                displacement = int.Parse(parameters[2]);
                engine = new Engine(model, power, displacement, efficiency);
            }
            else
            {
                engine = new Engine(model, power);
            }

            engines.Add(engine);
        }
    }

}
