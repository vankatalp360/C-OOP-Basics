using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari : ICar
{
    public string Model { get; set; }
    public string Driver { get; set; }

    public Ferrari(string driver)
    {
        Model = "488-Spider";
        Driver = driver;
    }

    public override string ToString()
    {
        return $"{Model}/{PushBrakes()}/{PushGasPedal()}/{Driver}";
    }

    public string PushGasPedal()
    {
        return $"Zadu6avam sA!";
    }

    public string PushBrakes()
    {
        return $"Brakes!";
    }
}
