using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var departments = new Dictionary<string, List<Employee>>();

        var lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var line = Console.ReadLine().Split();
            var name = line[0];
            var salary = decimal.Parse(line[1]);
            var position = line[2];
            var department = line[3];
            string email = "n/a";
            var age = -1;
            if (line.Length > 4)
            {
                if (line.Length == 6)
                {
                    email = line[4];
                    age = int.Parse(line[5]);
                }
                else
                {
                    var ageOrEmaile = int.TryParse(line[4], out age);
                    if (!ageOrEmaile)
                    {
                        age = -1;
                        email = line[4];
                    }
                }
            }
            var employee = new Employee(name, salary, position, department, email, age);
            if (!departments.ContainsKey(department))
            {
                departments[department] = new List<Employee>();
            }
            departments[department].Add(employee);
        }

        var highestDeparment = departments.OrderByDescending(p => p.Value.Sum(f => f.Salary)).First();

        Console.WriteLine($"Highest Average Salary: {highestDeparment.Key}");
        foreach (var employee in highestDeparment.Value.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}
