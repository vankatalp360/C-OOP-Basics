using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var days = new DateModifier();
        days.CalculateDifference(firstDate, secondDate);
        Console.WriteLine(days.DaysDifference);
    }
}
