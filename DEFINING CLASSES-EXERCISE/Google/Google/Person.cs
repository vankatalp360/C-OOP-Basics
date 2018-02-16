using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public string Birthday { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Childrens { get; set; }

    public Person(string name)
    {
        Name = name;
        Pokemons = new List<Pokemon>();
        Parents = new List<Person>();
        Childrens = new List<Person>();
    }

    public Person(string name, string birthday)
        : this(name)
    {
        Birthday = birthday;
    }

    public override string ToString()
    {
        Childrens.Distinct();
        Parents.Distinct();
        Pokemons.Distinct();
        var builder = new StringBuilder();

        builder.AppendLine($"{Name}");
        builder.AppendLine($"Company:");
        if (Company != null)
        {
            builder.AppendLine($"{Company.Name} {Company.Department} {Company.Salary:f2}");
        }
        builder.AppendLine($"Car:");
        if (Car != null)
        {
            builder.AppendLine($"{Car.Model} {Car.Speed}");
        }
        builder.AppendLine($"Pokemon:");
        foreach (var pokemon in Pokemons)
        {
            builder.AppendLine($"{pokemon.Name} {pokemon.Type}");
        }
        builder.AppendLine($"Parents:");
        foreach (var parent in Parents)
        {
            builder.AppendLine($"{parent.Name} {parent.Birthday}");
        }
        builder.AppendLine($"Children:");
        foreach (var children in Childrens)
        {
            builder.AppendLine($"{children.Name} {children.Birthday}");
        }

        return builder.ToString();
    }
}
