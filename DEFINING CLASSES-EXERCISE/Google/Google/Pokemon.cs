﻿using System;
using System.Collections.Generic;
using System.Text;

public class Pokemon
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Pokemon(string name, string type)
    {
        Name = name;
        Type = type;
    }
}
