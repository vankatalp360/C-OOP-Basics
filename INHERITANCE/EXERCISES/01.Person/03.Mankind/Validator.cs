using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Validator
{
    public static string ValidateFirstName(string name)
    {
        if (name[0].ToString() != name[0].ToString().ToUpper())
        {
            throw new ArgumentException($"Expected upper case letter! Argument: firstName");
        }
        if (name.Length <= 3)
        {
            throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
        }
        return name;
    }

    public static string ValidateLastName(string name)
    {
        if (name[0].ToString() != name[0].ToString().ToUpper())
        {
            throw new ArgumentException($"Expected upper case letter! Argument: lastName");
        }
        if (name.Length <= 2)
        {
            throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
        }
        return name;
    }

    public static string ValidateFacultyNumber(string number)
    {
        if (number.Length < 5 || number.Length > 10 || !number.All(char.IsLetterOrDigit))
        {
            throw new ArgumentException($"Invalid faculty number!");
        }
        return number;
    }

    public static decimal ValidateWeekSalary(decimal salary)
    {
        if (salary <= 10)
        {
            throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
        }
        return salary;
    }

    public static decimal ValidateWorkingHours(decimal hours)
    {
        if (hours < 1 || hours > 12)
        {
            throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
        }
        return hours;
    }
}
