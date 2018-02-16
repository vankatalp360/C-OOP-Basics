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
    }

    public Engine(string model, int power, int displacement)
        : this(model, power)
    {
        Displacement = displacement == 0 ? "n/a" : displacement.ToString();
    }

    public Engine(string model, int power, string efficiency)
        : this(model, power)
    {
        Efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency)
        : this(model, power, efficiency)
    {
        Displacement = displacement == 0 ? "n/a" : displacement.ToString();
    }
}
