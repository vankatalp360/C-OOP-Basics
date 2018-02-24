using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point(string input)
    {
        var parts = input.Split().Select(int.Parse).ToArray();
        X = parts[0];
        Y = parts[1];
    }
}
