using System;
using System.Collections.Generic;
using System.Text;

public class Validator
{
    public static double ValidateFlourType(string type)
    {
        switch (type.ToLower())
        {
            case "white": return 1.5;
            case "wholegrain": return 1.0;
            default: throw new ArgumentException($"Invalid type of dough.");
        }
    }

    public static double ValidateBakingTechnique(string type)
    {
        switch (type.ToLower())
        {
            case "crispy": return 0.9;
            case "chewy": return 1.1;
            case "homemade": return 1.0;
            default: throw new ArgumentException($"Invalid type of dough.");
        }
    }

    public static double ValidateDoughtWeight(double weight)
    {
        if (weight >= 1 && weight <= 200)
        {
            return weight;
        }
        throw new ArgumentException($"Dough weight should be in the range [1..200].");
    }

    public static double ValidateTopping(string topping)
    {
        switch (topping.ToLower())
        {
            case "meat": return 1.2;
            case "veggies": return 0.8;
            case "cheese": return 1.1;
            case "sauce": return 0.9;
            default: throw new ArgumentException($"Cannot place {topping} on top of your pizza.");
        }
    }

    public static double ValidateToppingWeight(string topping, double weight)
    {
        if (weight >= 1 && weight <= 50)
        {
            return weight;
        }
        throw new ArgumentException($"{topping} weight should be in the range [1..50].");
    }

    public static string ValidatePizzaName(string name)
    {
        if (name.Length >= 1 && name.Length <= 15)
        {
            return name;
        }
        throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
    }

    public static bool ValidateNumberOfToppings(int number)
    {
        if (number <= 10)
        {
            return true;
        }
        throw new ArgumentException($"Number of toppings should be in range [0..10].");
    }
}
