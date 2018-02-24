using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StudentSystem
{
    public Dictionary<string, Student> Repo { get; private set; }

    public StudentSystem()
    {
        Repo = new Dictionary<string, Student>();
    }

    public void ParseCommand(string command)
    {
        string[] args = command.Split();

        if (args[0] == "Create")
        {
            if (!Repo.ContainsKey(args[1]))
            {
                var student = new Student(args.Skip(1).ToArray());
                Repo[args[1]] = student;
            }
        }
        else if (args[0] == "Show")
        {
            var name = args[1];
            if (Repo.ContainsKey(name))
            {
                var student = Repo[name];
                Console.WriteLine(student);
            }
        }
    }
}
