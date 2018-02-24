using System;
using System.Collections.Generic;
using System.Text;
public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public Student(string[] parts)
        : this(parts[0], int.Parse(parts[1]), double.Parse(parts[2]))
    {
        
    }

    public override string ToString()
    {
        string studentInfo;

        if (Grade >= 5.00)
        {
            studentInfo = "Excellent student.";
        }
        else if (Grade < 5.00 && Grade >= 3.50)
        {
            studentInfo = "Average student.";
        }
        else
        {
            studentInfo = "Very nice person.";
        }

        return $"{Name} is {Age} years old. {studentInfo}";
    }
}