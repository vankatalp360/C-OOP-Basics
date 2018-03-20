namespace P01.Vehicles
{
    public class Validator
    {
        public static bool HasEnoughFuel(double fuel, double distance, double consumption)
        {
            var posibleDistance = fuel / consumption;
            if (posibleDistance < distance)
            {
                return false;
            }
            return true;
        }

        public static bool CanFitFuel(double fuel, double tankCapacity)
        {
            if (fuel > tankCapacity)
            {
                return false;
            }
            return true;
        }
    }
}