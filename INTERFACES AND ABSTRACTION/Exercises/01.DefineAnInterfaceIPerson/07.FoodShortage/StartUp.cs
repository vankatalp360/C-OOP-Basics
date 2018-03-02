using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var buyers = new List<IBuyer>();

        var inputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputs; i++)
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length == 4)
            {
                var citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                buyers.Add(citizen);
            }
            else
            {
                var reble = new Rebel(input[0], int.Parse(input[1]));
                buyers.Add(reble);
            }
        }

        string name;

        while ((name = Console.ReadLine()) != "End")
        {
            var currentBuyer = buyers.FirstOrDefault(b => b.Name == name);
            if (currentBuyer != null)
            {
                currentBuyer.BuyFood();
            }
        }

        var allFood = buyers.Sum(b => b.Food);
        Console.WriteLine(allFood);
    }
}