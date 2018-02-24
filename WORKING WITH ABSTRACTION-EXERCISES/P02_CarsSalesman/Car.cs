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
        Weight = "n/a";
        Color = "n/a";
    }

    public Car(string model, Engine engine, int weight)
    {
        Model = model;
        Engine = engine;
        Weight = weight.ToString();
        Color = "n/a";
    }

    public Car(string model, Engine engine, string color)
    {
        Model = model;
        Engine = engine;
        Weight = "n/a";
        Color = color;
    }

    public Car(string model, Engine engine, int weight, string color)
    {
        Model = model;
        Engine = engine;
        Weight = weight.ToString();
        Color = color;
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{Model}:");
        sb.Append(Engine.ToString());
        sb.AppendLine($"  Weight: {Weight}");
        sb.Append($"  Color: {Color}");

        return sb.ToString();
    }
}
