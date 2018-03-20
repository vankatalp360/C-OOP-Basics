using System;

namespace P01.Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            :base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override double AirConditionerConsumption => 1.4;
        
    }
}