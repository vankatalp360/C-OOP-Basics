using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            try
            {
                var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
                persons.Add(person);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var bonus = decimal.Parse(Console.ReadLine());
        persons
            .ToList()
            .ForEach(p =>
            {
                p.IncreaseSalary(bonus);
                Console.WriteLine(p.ToString());
            });

    }
}
