using System;

public class Validator
{
    public static double ValidateSide(double side)
    {
        if (side <= 0)
        {
            throw new ArgumentException("The side must be positive!");
        }
        return side;
    }
    public static double ValidateRadius(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("The radius must be positive!");
        }
        return radius;
    }
}