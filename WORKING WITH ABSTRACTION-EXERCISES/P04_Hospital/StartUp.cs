using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        private static Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
        private static Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();
        public static void Main()
        {
            
            string command;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] parts = command.Split();
                ReadInputs(parts);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] parts = command.Split();
                Print(parts);
            }
        }

        private static void Print(string[] parts)
        {
            if (parts.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[parts[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (parts.Length == 2 && int.TryParse(parts[1], out int staq))
            {
                Console.WriteLine(string.Join("\n", departments[parts[0]][staq - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[parts[0] + parts[1]].OrderBy(x => x)));
            }
        }

        private static void ReadInputs(string[] parts)
        {
            var departament = parts[0];
            var firstName = parts[1];
            var lastName = parts[2];
            var pacient = parts[3];
            var fullName = firstName + lastName;

            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }

            bool hasSpace = departments[departament].SelectMany(x => x).Count() < 60;
            if (hasSpace)
            {
                int room = 0;
                doctors[fullName].Add(pacient);
                for (int st = 0; st < departments[departament].Count; st++)
                {
                    if (departments[departament][st].Count < 3)
                    {
                        room = st;
                        break;
                    }
                }
                departments[departament][room].Add(pacient);
            }
        }
    }
}
