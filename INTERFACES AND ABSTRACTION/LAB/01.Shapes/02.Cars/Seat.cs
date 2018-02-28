using System;
using System.Collections.Generic;
using System.Text;

public class Seat : ICar
{
    public string Model { get; set; }
    public string Color { get; set; }

    public Seat(string model, string color)
    {
        Model = model;
        Color = color;
    }
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{Color} {this.GetType().Name} {Model}");
        builder.AppendLine($"Engine start");
        builder.AppendLine(Start());
        return builder.ToString().Trim();
    }
    public string Start()
    {
        return "Breaaak!";
    }

    public string Stop()
    {
        return "Stop!";
    }
}
