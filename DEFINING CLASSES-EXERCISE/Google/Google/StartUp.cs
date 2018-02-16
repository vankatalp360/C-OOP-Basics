using System;
using System.Collections.Generic;
using System.Globalization;

class StartUp
{
    static void Main(string[] args)
    {
        var people = new Dictionary<string, Person>();

        string line;
        while ((line = Console.ReadLine()) != "End")
        {
            var parts = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var personName = parts[0];
            var person = new Person(personName);
            if (people.ContainsKey(personName))
            {
                person = people[personName];
            }

            if (parts[1] == "company")
            {
                var companyName = parts[2];
                var department = parts[3];
                var salary = decimal.Parse(parts[4]);
                var company = new Company(companyName, department, salary);
                person.Company = company;
            }
            else if (parts[1] == "pokemon")
            {
                var pokemonName = parts[2];
                var pokemonType = parts[3];
                var pokemon = new Pokemon(pokemonName, pokemonType);
                person.Pokemons.Add(pokemon);
            }
            else if (parts[1] == "parents")
            {
                var parentName = parts[2];
                var parentBirthday = parts[3];
                var parent = new Person(parentName, parentBirthday);
                person.Parents.Add(parent);
            }
            else if (parts[1] == "children")
            {
                var childrenName = parts[2];
                var childrenBirthday = parts[3];
                var children = new Person(childrenName, childrenBirthday);
                person.Childrens.Add(children);
            }
            else if (parts[1] == "car")
            {
                var carModel = parts[2];
                var carSpeed = int.Parse(parts[3]);
                var car = new Car(carModel, carSpeed);
                person.Car = car;
            }

            people[personName] = person;
        }

        var name = Console.ReadLine();
        var human = people[name];
        Console.Write(human);
    }
}
