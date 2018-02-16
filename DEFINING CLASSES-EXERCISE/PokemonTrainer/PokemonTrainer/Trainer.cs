using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Trainer
{
    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Trainer(string name)
    {
        Name = name;
        Badges = 0;
        Pokemons = new List<Pokemon>();
    }

    public void AddBadges(string element)
    {
        var pokemons = Pokemons.Where(p => p.Element != element).ToList();
        if (pokemons.Count < Pokemons.Count)
        {
            Badges++;
        }
        else
        {
            for (int i = 0; i < Pokemons.Count; i++)
            {
                Pokemons[i].TakeDamage(element);
            }
            Pokemons = Pokemons.Where(p => p.Health > 0).ToList();
        }
    }

    public override string ToString()
    {
        return $"{Name} {Badges} {Pokemons.Count}";
    }
}
