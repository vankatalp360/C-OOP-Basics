using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var siameses = new List<Siamese>();
        var cymrics = new List<Cymric>();
        var streets = new List<StreetExtraordinaire>();


        string line;

        while ((line = Console.ReadLine()) != "End")
        {
            var parts = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            switch (parts[0])
            {
                case "StreetExtraordinaire": streets.Add(new StreetExtraordinaire() {Name = parts[1], DecibelcOfMeows = int.Parse(parts[2])});
                    break;
                case "Siamese": siameses.Add(new Siamese(){Name = parts[1], earSize = int.Parse(parts[2])});
                    break;
                case "Cymric": cymrics.Add(new Cymric() {Name = parts[1], FurtLength = double.Parse(parts[2])});
                    break;
            }
        }

        var catName = Console.ReadLine();

        var siames = siameses.FirstOrDefault(c => c.Name == catName);
        var street = streets.FirstOrDefault(c => c.Name == catName);
        var cymric = cymrics.FirstOrDefault(c => c.Name == catName);

        if (siames != null)
        {
            Console.WriteLine(siames);
        }
        if (street != null)
        {
            Console.WriteLine(street);
        }
        if (cymric != null)
        {
            Console.WriteLine(cymric);
        }
    }
}
