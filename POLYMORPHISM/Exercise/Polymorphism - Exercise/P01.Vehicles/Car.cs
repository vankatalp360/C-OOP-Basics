using P01.Vehicles.Contracts;

namespace P01.Vehicles
{
    public class Car : Vehicle, IVehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm) 
            :base(fuelQuantity, fuelConsumptionPerKm)
        {
        }
        public override double AirConditionerConsumption => 0.9;
        
    }
}