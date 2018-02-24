using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    public List<Product> Bag { get; set; }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }
    private decimal Money
    {
        get
        {
            return money;
        }
        set
        {
            Validator.ValidateMoney(value);
            money = value;
        }
    }

    public Person()
    {
        
    }
    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        Bag = new List<Product>();
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append($"{Name} - ");
        builder.AppendLine(Bag.Any() ? string.Join(", ", Bag) : "Nothing bought");

        return builder.ToString().TrimEnd();
    }

    public void BuyProduct(Product product)
    {
        if (product.Price <= money)
        {
            money -= product.Price;
            Bag.Add(product);
            Console.WriteLine($"{Name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{name} can't afford {product.Name}");
        }
    }
}
