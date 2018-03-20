public class Validator
{
    public static bool ValidateOreOutput(double oreOutput)
    {
        if (oreOutput < 0)
        {
            return false;
        }
        return true;
    }
    public static bool ValidateEnergyRequirement(double energyRequirement)
    {
        if (energyRequirement < 0 || energyRequirement > 20000)
        {
            return false;
        }
        return true;
    }
    public static bool ValidateEnergyOutput(double energyOutput)
    {
        if (energyOutput < 0 || energyOutput > 10000)
        {
            return false;
        }
        return true;
    }
}