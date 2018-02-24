using System;
using System.Collections.Generic;
using System.Text;
public class StartUp
{
    static void Main()
    {
        StudentSystem studentSystem = new StudentSystem();

        string command;
        while ((command = Console.ReadLine()) != "Exit")
        {
            studentSystem.ParseCommand(command);
        }
    }
}
