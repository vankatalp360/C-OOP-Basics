using System;
using System.Text;

public abstract class Provider : IIndentification
{
    private string id;
    private double energyOutput;

    public string Id
    {
        get => this.id;
        protected set => this.id = value;
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (Validator.ValidateEnergyOutput(value))
            {
                this.energyOutput = value;
            }
            else
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
            }
        }
    }

    protected Provider(string id, double energyOutput)
    {
        Id = id;
        EnergyOutput = energyOutput;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        var type = this.GetType().Name;
        var index = type.IndexOf("Provider");
        type = type.Remove(index);

        builder.AppendLine($"{type} Provider - {this.id}");
        builder.AppendLine($"Energy Output: {this.energyOutput}");
        
        return builder.ToString().Trim();
    }
}