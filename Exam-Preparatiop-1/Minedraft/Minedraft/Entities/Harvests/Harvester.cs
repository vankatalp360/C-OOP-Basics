using System;
using System.Text;

public abstract class Harvester : IIndentification
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    public string Id
    {
        get => this.id;
        protected set => this.id = value;
    }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (Validator.ValidateOreOutput(value))
            {
                this.oreOutput = value;
            }
            else
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(OreOutput)}");
            }
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (Validator.ValidateEnergyRequirement(value))
            {
                this.energyRequirement = value;
            }
            else
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
            }
        }
    }

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        var type = this.GetType().Name;
        var index = type.IndexOf("Harvester");
        type = type.Remove(index);
        builder.AppendLine($"{type} Harvester - {this.id}");
        builder.AppendLine($"Ore Output: {this.oreOutput}");
        builder.AppendLine($"Energy Requirement: {this.energyRequirement}");

        return builder.ToString().Trim();
    }
}