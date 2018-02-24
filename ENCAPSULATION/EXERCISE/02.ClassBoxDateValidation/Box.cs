using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;

    public double Length
    {
        get
        {
            return length;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Length cannot be zero or negative.");
            }
            else
            {
                length = value;
            }
        }
    }

    private double width;

    public double Width
    {
        get
        {
            return width;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Width cannot be zero or negative.");
            }
            else
            {
                width = value;
            }
        }
    }

    private double height;

    public double Height
    {
        get
        {
            return height;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Height cannot be zero or negative.");
            }
            else
            {
                height = value;
            }
        }
    }



    private double SurfaceArea => GetSurfaceArea();
    private double LateralSurfaceArea => GetLateralSurfaceArea();
    private double Volume => GetVolume();

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Surface Area - {SurfaceArea:f2}");
        builder.AppendLine($"Lateral Surface Area - {LateralSurfaceArea:f2}");
        builder.AppendLine($"Volume - {Volume:f2}");

        return builder.ToString().TrimEnd();
    }

    private double GetSurfaceArea()
    {
        return (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
    }

    private double GetLateralSurfaceArea()
    {
        return (2 * Length * Height) + (2 * Width * Height);
    }

    private double GetVolume()
    {
        return Length * Width * Height;
    }

}
