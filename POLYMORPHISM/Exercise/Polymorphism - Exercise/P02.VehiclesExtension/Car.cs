namespace P01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            :base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }
        public override double AirConditionerConsumption => 0.9;
        
    }
}