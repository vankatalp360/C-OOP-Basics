using System;
using System.Collections.Generic;
using _10.ExplicitInterfaces.Contracts;

namespace _10.ExplicitInterfaces
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(' ');
                var name = tokens[0];
                var country = tokens[1];
                var age = int.Parse(tokens[2]);
                var citizen = new Citizen(name, country, age);

                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
