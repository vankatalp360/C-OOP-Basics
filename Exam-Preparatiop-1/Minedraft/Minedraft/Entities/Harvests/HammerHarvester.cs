public class HammerHarvester : Harvester
{
    private const int OreOutputIncrease = 200;
    private const int EnergyIncrease = 100;
    

    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput += (base.OreOutput / 100) * OreOutputIncrease;
        this.EnergyRequirement += (base.EnergyRequirement / 100) * EnergyIncrease;
    }
}