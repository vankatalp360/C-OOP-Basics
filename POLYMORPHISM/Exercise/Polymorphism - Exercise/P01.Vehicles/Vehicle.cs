using System;
using P01.Vehicles.Contracts;

namespace P01.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public abstract double AirConditionerConsumption { get; }

        public virtual void Driving(double distance)
        {
            var fuelConsumption = FuelConsumptionPerKm + AirConditionerConsumption;
            var hasEnoughFuel = Validator.HasEnoughFuel(FuelQuantity, distance, fuelConsumption);
            if (hasEnoughFuel)
            {
                FuelQuantity -= fuelConsumption * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                return;
            }
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }

        public virtual void Refueling(double fuel)
        {
            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}