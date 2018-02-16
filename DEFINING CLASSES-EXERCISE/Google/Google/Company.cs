﻿using System;
using System.Collections.Generic;
using System.Text;

public class Company
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public Company(string name, string department, decimal salary)
    {
        Name = name;
        Department = department;
        Salary = salary;
    }
}
