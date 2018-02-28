using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

public class Smartphone : ICallable, IBrowsable
{
    public string Model { get; set; }

    public Smartphone(string model)
    {
        Model = model;
    }
    

    public void Call(string number)
    {
        number = Validator.ValidatePhoneNumber(number);
        Console.WriteLine($"Calling... {number}");
    }

    public void Browse(string site)
    {
        site = Validator.ValidateURL(site);
        Console.WriteLine($"Browsing: {site}!");
    }
}
