using System;
using System.Collections.Generic;
using System.Text;

public class Animal
{
    private string name;
    private int age;
    private string gender;

    public virtual string Gender
    {
        get { return gender; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) ||
                (value != "Male" && value != "Female"))
            {
                throw new ArgumentException("Invalid input!");
            }
            gender = value;
        }
    }

    public int Age
    {
        get { return age; }
        set {
            if (value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            age = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            name = value;
        }
    }


    public virtual string ProduceSound()
    {
        return $"";
    }

    public Animal()
    {
        
    }
    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{this.GetType()}");
        builder.AppendLine($"{name} {age} {Gender}");
        builder.AppendLine($"{ProduceSound()}");

        return builder.ToString().TrimEnd();
    }
}