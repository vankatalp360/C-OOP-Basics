using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    private string name;

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

    private decimal price;

    public decimal Price
    {
        get
        {
            return price;
        }
        set
        {
            Validator.ValidateMoney(value);
            price = value;
        }
    }

    public override string ToString()
    {
        return Name;
    }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

}
