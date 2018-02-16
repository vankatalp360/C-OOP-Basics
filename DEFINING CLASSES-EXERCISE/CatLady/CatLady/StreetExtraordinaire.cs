using System;
using System.Collections.Generic;
using System.Text;

public class StreetExtraordinaire : Cat
{
    public int DecibelcOfMeows { get; set; }

    public override string ToString()
    {
        return $"StreetExtraordinaire {Name} {DecibelcOfMeows}";
    }
}
