using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private const int halfModeEnergyConsum = 60;
    private const int halfModeOreOutput = 50;
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private string mode;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;
        this.mode = "Full";
    }


    public string RegisterHarvester(List<string> arguments)
    {
        string message = "";

        try
        {
            var type = arguments[0];
            var harvest = HarvesterFactory.CreateHarvester(arguments);
            harvesters[harvest.Id] = harvest;

            message = $"Successfully registered {type} Harvester - {harvest.Id}";
        }
        catch (ArgumentException e)
        {
            message = e.Message;
        }

        return message;
    }
    public string RegisterProvider(List<string> arguments)
    {
        string message = "";

        try
        {
            var type = arguments[0];
            var provider = ProviderFactory.CreateProvider(arguments);
            providers[provider.Id] = provider;

            message = $"Successfully registered {type} Provider - {provider.Id}";
        }
        catch (ArgumentException e)
        {
            message = e.Message;
        }

        return message;
    }

    public string Day()
    {
        var energyProvide = providers.Sum(p => p.Value.EnergyOutput);
        this.totalStoredEnergy += energyProvide;
        double energyRequirement = 0;
        double oreOutput = 0;
        energyRequirement = harvesters.Sum(h => h.Value.EnergyRequirement);
        if (totalStoredEnergy >= energyRequirement)
        {
            if (this.mode == "Full")
            {
                totalStoredEnergy -= energyRequirement;
                oreOutput += harvesters.Sum(h => h.Value.OreOutput);
            }
            else if (this.mode == "Half")
            {
                totalStoredEnergy -= harvesters.Sum(h => (h.Value.EnergyRequirement / 100 * halfModeEnergyConsum));
                oreOutput += harvesters.Sum(h => (h.Value.OreOutput / 100 * halfModeOreOutput));
            }

            totalMinedOre += oreOutput;
        }

        var builder = new StringBuilder();
        builder.AppendLine($"A day has passed.");
        builder.AppendLine($"Energy Provided: {energyProvide}");
        builder.AppendLine($"Plumbus Ore Mined: {oreOutput}");

        return builder.ToString().TrimEnd();
    }

    public string Mode(List<string> arguments)
    {
        var mode = arguments[0];
        switch (mode)
        {
            case "Full":
                this.mode = mode;
                break;
            case "Half":
                this.mode = mode;
                break;
            case "Energy":
                this.mode = mode;
                break;
        }
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var message = $"No element found with id - {id}";
        if (harvesters.ContainsKey(id))
        {
            message = harvesters[id].ToString();
        }
        else if (providers.ContainsKey(id))
        {
            message = providers[id].ToString();
        }
        return message;
    }

    public string ShutDown()
    {
        var message = new StringBuilder();
        message.AppendLine($"System Shutdown");
        message.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        message.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");
        return message.ToString().TrimEnd();
    }
}