namespace P01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm) 
            :base(fuelQuantity, fuelConsumptionPerKm)
        {
        }

        public override double AirConditionerConsumption => 1.6;

        public override void Refueling(double fuel)
        {
            FuelQuantity += fuel * 0.95;
        }
        
    }
}