using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class Smartphone : ICallable, IBrowsable
{
    public void Call(string number)
    {
        if (number.All(d => char.IsDigit(d)))
            Console.WriteLine($"Calling... {number}");
        else
            Console.WriteLine("Invalid number!");
    }

    public void Browse(string website)
    {
        if (website.Any(c => char.IsDigit(c)))
            Console.WriteLine("Invalid URL!");
        else
            Console.WriteLine($"Browsing: {website}!");
    }
}
