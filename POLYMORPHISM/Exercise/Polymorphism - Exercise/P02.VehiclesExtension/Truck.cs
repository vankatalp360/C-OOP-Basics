using System;

namespace P01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            :base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override double AirConditionerConsumption => 1.6;

        public override void Refueling(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
                return;
            }
            var canFitFuel = Validator.CanFitFuel(fuel, TankCapacity - FuelQuantity);
            if (canFitFuel)
            {
                FuelQuantity += fuel * 0.95;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }
        
    }
}