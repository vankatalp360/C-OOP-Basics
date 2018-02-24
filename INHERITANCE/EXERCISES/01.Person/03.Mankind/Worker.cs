using System;
using System.Collections.Generic;
using System.Text;

public class Worker :Human
{
    private decimal weekSalary;
    private decimal workHours;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours)
    {
        base.FirstName = firstName;
        base.LastName = lastName;
        WorkHours = workingHours;
        WeekSalary = weekSalary;
    }
    
    public decimal SalaryPerHour => (weekSalary / 5) / workHours;
    public decimal WorkHours
    {
        get { return workHours; }
        set { workHours = Validator.ValidateWorkingHours(value); }
    }

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set { weekSalary = Validator.ValidateWeekSalary(value); }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"First Name: {FirstName}");
        builder.AppendLine($"Last Name: {LastName}");
        builder.AppendLine($"Week Salary: {weekSalary:f2}");
        builder.AppendLine($"Hours per day: {workHours:f2}");
        builder.AppendLine($"Salary per hour: {SalaryPerHour:f2}");
        return builder.ToString().TrimEnd();
    }
}
