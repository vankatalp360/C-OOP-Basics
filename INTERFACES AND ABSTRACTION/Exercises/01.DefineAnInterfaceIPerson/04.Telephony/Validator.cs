using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Validator
{
    public static string ValidatePhoneNumber(string number)
    {
        if (number.All(char.IsDigit))
        {
            return number;
        }
        throw new ArgumentException($"Invalid number!");
    }

    public static string ValidateURL(string url)
    {
        if (!url.Any(char.IsDigit))
        {
            return url;
        }
        throw new ArgumentException($"Invalid URL!");
    }
}
