using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var trainers = new Dictionary<string, Trainer>();

        ReadInput(trainers);

        string line;

        while ((line = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                trainer.Value.AddBadges(line);
            }
        }

        foreach (var trainer in trainers.Values.OrderByDescending(t => t.Badges))
        {
            Console.WriteLine(trainer);
        }
    }

    private static void ReadInput(Dictionary<string, Trainer> trainers)
    {
        string line;

        while ((line = Console.ReadLine()) != "Tournament")
        {
            var input = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var trainerName = input[0];
            var pokemonName = input[1];
            var element = input[2];
            var health = int.Parse(input[3]);

            var trainer = new Trainer(trainerName);
            var pokemon = new Pokemon(pokemonName, element, health);

            if (!trainers.ContainsKey(trainerName))
            {
                trainers[trainerName] = trainer;
            }
            trainers[trainerName].Pokemons.Add(pokemon);
        }
    }
}
