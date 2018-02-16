using System;
using System.Collections.Generic;
using System.Text;

public class Cymric : Cat
{
    public double FurtLength { get; set; }

    public override string ToString()
    {
        return $"Cymric {Name} {FurtLength:f2}";
    }
}
