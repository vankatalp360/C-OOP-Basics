using System;
using System.Collections.Generic;
using System.Text;
public class Citizen : ICitizen, IIdentifiable, IBirthdate
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Birthdate { get; set; }
    public string Id { get; set; }

    public Citizen(string name, int age, string birthdate, string id)
    {
        Name = name;
        Age = age;
        Birthdate = birthdate;
        Id = id;
    }
}
