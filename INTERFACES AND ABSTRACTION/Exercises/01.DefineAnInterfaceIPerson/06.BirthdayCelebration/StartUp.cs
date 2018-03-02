using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var birthdates = new List<IBirthdate>();
        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            var input = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "Citizen")
            {
                var citizen = new Citizen(input[1], int.Parse(input[2]), input[4], input[3]);
                birthdates.Add(citizen);
            }
            else if(input[0] == "Pet")
            {
                var pet = new Pet(input[1], input[2]);
                birthdates.Add(pet);
            }
        }

        var year = Console.ReadLine();
        foreach (var birthdate in birthdates.Where(b => b.Birthdate.EndsWith(year)))
        {
            Console.WriteLine(birthdate.Birthdate);
        }
    }
}