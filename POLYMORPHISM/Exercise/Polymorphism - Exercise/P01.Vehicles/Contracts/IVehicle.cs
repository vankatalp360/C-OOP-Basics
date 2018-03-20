namespace P01.Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKm { get; }
        void Driving(double distance);
        void Refueling(double fuel);
    }
}