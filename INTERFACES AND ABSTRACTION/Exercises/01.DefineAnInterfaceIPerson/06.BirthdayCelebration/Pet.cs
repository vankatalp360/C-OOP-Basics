using System;
using System.Collections.Generic;
using System.Text;

public class Pet : IPet, IBirthdate
{
    public string Name { get; set; }
    public string Birthdate { get; set; }

    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }
}
