using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            var people = new List<Person>();
            var products = new List<Product>();

            ReadPeopleAndProducts(people, products);
            BuyProducts(people, products);

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void BuyProducts(List<Person> people, List<Product> products)
    {
        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            var args = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var personName = args[0];
            var productName = args[1];

            var person = people.First(p => p.Name == personName);
            var product = products.First(p => p.Name == productName);

            person.BuyProduct(product);
        }
    }

    private static void ReadPeopleAndProducts(List<Person> people, List<Product> products)
    {
        var peopleArgs = Console.ReadLine()
                    .Split(new[] { '=', ';'}, StringSplitOptions.RemoveEmptyEntries);
        var productsArgs = Console.ReadLine()
            .Split(new[] { '=', ';'}, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < peopleArgs.Length; i += 2)
        {
            var name = peopleArgs[i];
            var money = decimal.Parse(peopleArgs[i + 1]);

            try
            {
                var person = new Person(name, money);
                people.Add(person);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        for (int i = 0; i < productsArgs.Length; i += 2)
        {
            var name = productsArgs[i];
            var price = decimal.Parse(productsArgs[i + 1]);

            try
            {
                var product = new Product(name, price);
                products.Add(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }
    }
}
