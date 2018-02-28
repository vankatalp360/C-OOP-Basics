using System;
using System.Collections.Generic;
using System.Text;

public class Tesla :ICar, IElectricCar
{
    public string Model { get; set; }
    public string Color { get; set; }
    public int Battery { get; set; }

    public Tesla(string model, string color, int battery)
    {
        Model = model;
        Color = color;
        Battery = battery;
    }
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{Color} {this.GetType().Name} {Model} with {Battery} Batteries");
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
