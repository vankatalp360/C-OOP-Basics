﻿using System;
using System.Collections.Generic;
using System.Text;

public class Rebel : IBuyer
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public int Food { get; private set; }

    public Rebel(string name, int age)
    {
        Name = name;
        Age = age;
        Food = 0;
    }

    public void BuyFood()
    {
        Food += 5;
    }
}
