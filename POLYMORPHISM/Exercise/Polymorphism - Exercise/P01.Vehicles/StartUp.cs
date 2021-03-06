﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var vehicles = new List<Vehicle>();
            ReadVehicles(vehicles);

            var commandsCount = int.Parse(Console.ReadLine());
            ExecuteCommands(vehicles, commandsCount);
            PrintVehicles(vehicles);
        }

        private static void PrintVehicles(List<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private static void ExecuteCommands(List<Vehicle> vehicles, int commandsCount)
        {
            for (int i = 0; i < commandsCount; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];
                var vehicle = input[1];

                switch (command)
                {
                    case "Drive":
                        DriveVehicle(vehicle, double.Parse(input[2]), vehicles);
                        break;
                    case "Refuel":
                        RefuelCehicle(vehicle, double.Parse(input[2]), vehicles);
                        break;
                }
            }
        }

        private static void ReadVehicles(List<Vehicle> vehicles)
        {
            var carArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1).Select(double.Parse).ToArray();
            var trucksArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1).Select(double.Parse).ToArray();
            vehicles.Add(new Car(carArgs[0], carArgs[1]));
            vehicles.Add(new Truck(trucksArgs[0], trucksArgs[1]));
        }

        private static void RefuelCehicle(string vehilcle, double fuel, List<Vehicle> vehicles)
        {
            if (vehilcle == "Car")
            {
                vehicles[0].Refueling(fuel);
            }
            else
            {
                vehicles[1].Refueling(fuel);
            }
        }

        private static void DriveVehicle(string vehilcle, double distance, List<Vehicle> vehicles)
        {
            if (vehilcle == "Car")
            {
                vehicles[0].Driving(distance);
            }
            else
            {
                vehicles[1].Driving(distance);
            }
        }
    }
}
