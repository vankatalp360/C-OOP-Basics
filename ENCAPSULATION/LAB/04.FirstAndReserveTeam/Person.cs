using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private const decimal MinSalary = 460;
    private const int MinNameLenght = 3;
    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (ValidateName(value))
            {
                firstName = value;
            }
            else
            {
                throw new ArgumentException($"First name cannot contain fewer than {MinNameLenght} symbols!");
            }
        }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (ValidateName(value))
            {
                lastName = value;
            }
            else
            {
                throw new ArgumentException($"Last name cannot contain fewer than {MinNameLenght} symbols!");
            }
        }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if (ValidateAge(value))
            {
                age = value;
            }
            else
            {
                throw new ArgumentException($"Age cannot be zero or a negative integer!");
            }
        }
    }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (ValidateSalary(value))
            {
                salary = value;
            }
            else
            {
                throw new ArgumentException($"Salary cannot be less than {MinSalary} leva!");
            }
        }
    }




    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
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

    private bool ValidateName(string name)
    {
        if (name.Length < MinNameLenght)
        {
            return false;   
        }
        return true;
    }

    private bool ValidateSalary(decimal salary)
    {
        if (salary < 460)
        {
            return false;
        }
        return true;
    }

    private bool ValidateAge(int age)
    {
        if (age <= 0)
        {
            return false;   
        }
        return true;
    }
}
