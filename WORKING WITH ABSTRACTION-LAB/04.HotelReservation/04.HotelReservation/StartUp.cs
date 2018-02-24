using System;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().ToArray();
        var calculator = new PriceCalculator(input);
        var price = calculator.CalculatePrice();

        Console.WriteLine(price);
    }
}
