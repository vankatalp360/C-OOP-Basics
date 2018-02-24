using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(string input)
    {
        var parts = input.Split().Select(int.Parse).ToArray();
        TopLeft = new Point(parts[0], parts[1]);
        BottomRight = new Point(parts[2], parts[3]);
    }

    public bool ContainPoint(Point point)
    {
        bool x = point.X >= TopLeft.X && point.X <= BottomRight.X;
        bool y = point.Y >= TopLeft.Y && point.Y <= BottomRight.Y;
        return x && y;
    }
}
