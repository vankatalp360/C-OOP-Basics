using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
        var engines = new Dictionary<string, Engine>();
        var cars = new List<Car>();

        var enginesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < enginesCount; i++)
        {
            var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = line[0];
            var power = int.Parse(line[1]);
            var displacement = 0;
            var efficientcy = "n/a";

            if (line.Length > 2)
            {
                if (line.Length == 4)
                {
                    displacement = int.Parse(line[2]);
                    efficientcy = line[3];
                }
                else
                {
                    var hasEfficiency = int.TryParse(line[2], out displacement);
                    if (!hasEfficiency)
                    {
                        efficientcy = line[2];
                    }
                }
            }

            var engine = new Engine(model, power, displacement, efficientcy);
            engines[model] = engine;
        }

        var carsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carsCount; i++)
        {
            var line = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var model = line[0];
            var engine = line[1];
            var weight = 0;
            var color = "n/a";

            if (line.Length > 2)
            {
                if (line.Length == 4)
                {
                    weight = int.Parse(line[2]);
                    color = line[3];
                }
                else
                {
                    var hasEfficiency = int.TryParse(line[2], out weight);
                    if (!hasEfficiency)
                    {
                        color = line[2];
                    }
                }
            }

            var car = new Car(model, engines[engine], weight, color);
            cars.Add(car);
        }

        cars.ForEach(c => Console.Write(c.ToString()));
    }
    
}