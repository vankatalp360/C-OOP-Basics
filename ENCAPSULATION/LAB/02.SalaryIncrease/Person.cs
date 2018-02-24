using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }




    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} receives {salary:f2} leva.";
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.age < 30)
        {
            salary += salary * (percentage / 200);
        }
        else
        {
            salary += salary * (percentage / 100);
        }
    }
}
