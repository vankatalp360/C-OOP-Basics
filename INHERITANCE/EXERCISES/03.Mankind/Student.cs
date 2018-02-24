using System;
using System.Collections.Generic;
using System.Text;

public class Student:Human 
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
    {
        base.FirstName = firstName;
        base.LastName = lastName;
        FacultyNumber = facultyNumber;
    }
    public string FacultyNumber
    {
        get { return facultyNumber; }
        set { facultyNumber = Validator.ValidateFacultyNumber(value); }
    }
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"First Name: {FirstName}");
        builder.AppendLine($"Last Name: {LastName}");
        builder.AppendLine($"Faculty number: {facultyNumber}");
        return builder.ToString().TrimEnd();
    }
}
