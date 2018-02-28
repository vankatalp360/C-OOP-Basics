using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var phone = new Smartphone("Smartphone");
        var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Call(numbers, phone);
        var urls = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Browse(urls, phone);
        
    }

    private static void Browse(string[] urls, Smartphone phone)
    {
        foreach(var url in urls)
        {
            try
            {

                phone.Browse(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void Call(string[] numbers, Smartphone phone)
    {
        foreach (var number in numbers)
        {
            try
            {

                phone.Call(number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
}