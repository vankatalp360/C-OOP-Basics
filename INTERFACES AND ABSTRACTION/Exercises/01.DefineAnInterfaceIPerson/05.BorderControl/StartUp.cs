using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var ids = new List<IIdentifiable>();
        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            var input = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length == 3)
            {
                var citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                ids.Add(citizen);
            }
            else
            {
                var robot = new Robot(input[0], input[1]);
                ids.Add(robot);
            }
        }

        var digits = Console.ReadLine();
        foreach (var id in ids.Where(r => r.Id.EndsWith(digits)))
        {
            Console.WriteLine(id.Id);
        }
    }
}