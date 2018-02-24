using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    public double Length { get; private set; }
    public double Width { get; private set; }
    public double Height { get; private set; }


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
