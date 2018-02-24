using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private string toppingType;
    private double weight;
    private double typeColories;
    public double ToppingCalories => 2 * weight * typeColories;

    private string ToppingType
    {
        set
        {
            typeColories = Validator.ValidateTopping(value);
            toppingType = value;
        }
    }

    private double Weight
    {
        set => weight = Validator.ValidateToppingWeight(toppingType, value);
    }

    public Topping(string toppingType, double weight)
    {
        ToppingType = toppingType;
        Weight = weight;
    }
}
