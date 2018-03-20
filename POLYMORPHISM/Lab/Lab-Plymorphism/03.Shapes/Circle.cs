using System;

public class Circle : Shape
{
    public Circle(double radius)
    {
        this.Radius = radius;
    }
    private double radius;

    public double Radius
    {
        get
        {
            return radius;
        }
        set
        {
            radius = Validator.ValidateRadius(value);
        }
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override string Draw()
    {
        return $"{base.Draw()}Circle";
    }
}