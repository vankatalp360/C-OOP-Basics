public class PressureProvider : Provider
{
    private const int EnergyIncrease = 50;

    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        this.EnergyOutput += (base.EnergyOutput / 100) * EnergyIncrease;
    }
}