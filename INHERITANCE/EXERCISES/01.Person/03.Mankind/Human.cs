using System;
using System.Collections.Generic;
using System.Text;

public class Human
{
    private string firstName;

    private string lastName;

    public Human()
    {
        
    }

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = Validator.ValidateLastName(value); }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = Validator.ValidateFirstName(value); }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"First Name: {firstName}");
        builder.AppendLine($"Last Name: {lastName}");
        return builder.ToString().TrimEnd();
    }
}
