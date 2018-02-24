using System;

public class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            var pizza = ReadPizza();
            Console.WriteLine(pizza);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static Pizza ReadPizza()
    {
        var inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.None);
        var pizza = new Pizza(inputArgs[1]);

        inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.None);
        var dough = new Dough(inputArgs[1], inputArgs[2], double.Parse(inputArgs[3]));
        pizza.Dough = dough;


        var toppingsCounter = 0;
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            toppingsCounter++;
            Validator.ValidateNumberOfToppings(toppingsCounter);
            inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.None);
            var topping = new Topping(inputArgs[1], double.Parse(inputArgs[2]));
            pizza.Toppings.Add(topping);
        }

        return pizza;
    }
}
