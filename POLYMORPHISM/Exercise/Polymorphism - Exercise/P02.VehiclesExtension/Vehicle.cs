using System;

namespace P01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }
        private double fuelQuantity;
        private double fuelConsumptionPerKm;
        private double tankCapacity;

        public double TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }

        public virtual double AirConditionerConsumption { get; }

        public double FuelConsumptionPerKm
        {
            get { return fuelConsumptionPerKm; }
            set { fuelConsumptionPerKm = value; }
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public virtual void Driving(double distance, bool havePeople)
        {
            double fuelConsumption = havePeople ? FuelConsumptionPerKm + AirConditionerConsumption : FuelConsumptionPerKm;

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
            if (fuel <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
                return;
            }
            var canFitFuel = Validator.CanFitFuel(fuel, TankCapacity - FuelQuantity);
            if (canFitFuel)
            {
                FuelQuantity += fuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}