﻿using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var studentArgs = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        var workerArgs = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        try
        {
            var student = new Student(studentArgs[0], studentArgs[1], studentArgs[2]);
            var worker = new Worker(workerArgs[0], workerArgs[1], decimal.Parse(workerArgs[2]), decimal.Parse(workerArgs[3]));
            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
