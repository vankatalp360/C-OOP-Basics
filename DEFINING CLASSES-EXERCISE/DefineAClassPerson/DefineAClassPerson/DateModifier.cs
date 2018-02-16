using System;
using System.Collections.Generic;
using System.Text;

public class DateModifier
{
    private double daysDifference;

    public double DaysDifference
    {
        get { return daysDifference; }
    }

    public void CalculateDifference(string date1, string date2)
    {
        var firstDate = DateTime.Parse(date1);
        var secondDate = DateTime.Parse(date2);
        daysDifference = Math.Abs((secondDate - firstDate).TotalDays);
    }
}
