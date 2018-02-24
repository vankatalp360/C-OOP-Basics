using System;
using System.Collections.Generic;
using System.Text;

public class Validator
{
    public static string ValidateAuthor(string author)
    {
        var authorArgs = author.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        if (authorArgs.Length > 1 && char.IsDigit(authorArgs[1][0]))
        {
            throw new ArgumentException($"Author not valid!");
        }
        return author;
    }

    public static string ValidateTitle(string title)
    {
        if (title.Length < 3)
        {
            throw new ArgumentException($"Title not valid!");
        }
        return title;
    }

    public static decimal ValidatePrice(decimal price)
    {
        if (price <= 0)
        {
            throw new ArgumentException($"Price not valid!");
        }
        return price;
    }

}
