using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    public string Model { get; set; }
    public int Power { get; set; }
    public string Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine(string model, int power)
    {
        Model = model;
        Power = power;
        Displacement = "n/a";
        Efficiency = "n/a";
    }

    public Engine(string model, int power, int displacement)
    {
        Model = model;
        Power = power;
        Displacement = displacement.ToString();
        Efficiency = "n/a";
    }

    public Engine(string model, int power, string efficiency)
    {
        Model = model;
        Power = power;
        Displacement = "n/a";
        Efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency)
    {
        Model = model;
        Power = power;
        Displacement = displacement.ToString();
        Efficiency = efficiency;
    }



    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"  {Model}:");
        sb.AppendLine($"    Power: {Power}");
        sb.AppendLine($"    Displacement: {Displacement}");
        sb.AppendLine($"    Efficiency: {Efficiency}");

        return sb.ToString();
    }
}
