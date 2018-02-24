﻿using System;

class Program
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        try
        {
            Chicken chicken = new Chicken(name, age);
            Console.WriteLine(chicken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}
