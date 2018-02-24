﻿using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private const int nameLenght = 3;
    private string name;
    private int age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual string Name
    {
        get { return name; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException($"Name's length should not be less than {nameLenght} symbols!");
            }
            name = value;
        }
    }

    public virtual int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Age must be positive!");
            }
            age = value;
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Name: {name}, Age: {age}");
        return builder.ToString().TrimEnd();
    }
}
