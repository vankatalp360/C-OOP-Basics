using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelPer1Km { get; set; }
    public double Distance { get; set; }

    public Car()
    {
        
    }

    public Car(string model, double fuelAmount, double fuelPer1Km)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelPer1Km = fuelPer1Km;
    }
    public void Drive(double amountOfKm)
    {
        var posibleDistance = FuelAmount / FuelPer1Km;
        if (posibleDistance >= amountOfKm)
        {
            FuelAmount -= amountOfKm * FuelPer1Km;
            Distance += amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
