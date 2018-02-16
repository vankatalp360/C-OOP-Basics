using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
    }

    public Car(string model, Engine engine, int weight)
        : this(model, engine)
    {
        Weight = weight == 0 ? "n/a" : weight.ToString();
    }

    public Car(string model, Engine engine, string color)
        : this(model, engine)
    {
        Color = color;
    }

    public Car(string model, Engine engine, int weight, string color)
        : this(model, engine, color)
    {
        Weight = weight == 0 ? "n/a" : weight.ToString();
    }

    public override string ToString()
    {
        var engine = Engine;
        var str = new StringBuilder()
            .AppendLine($"{Model}:")
            .AppendLine($"  {engine.Model}:")
            .AppendLine($"    Power: {engine.Power}")
            .AppendLine($"    Displacement: {engine.Displacement}")
            .AppendLine($"    Efficiency: {engine.Efficiency}")
            .AppendLine($"  Weight: {Weight}")
            .AppendLine($"  Color: {Color}");

        return str.ToString();
    }
}
