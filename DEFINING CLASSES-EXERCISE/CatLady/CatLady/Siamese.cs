using System;
using System.Collections.Generic;
using System.Text;

public class Siamese : Cat
{
    public int earSize { get; set; }

    public override string ToString()
    {
        return $"Siamese {Name} {earSize}";
    }
}
