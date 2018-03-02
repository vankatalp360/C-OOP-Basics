using System;
using System.Collections.Generic;
using System.Linq;
using P08.MilitaryElite.Contracts;

namespace P08.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var soldiers = new List<ISoldier>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                var soldierType = tokens[0];
                int id = int.Parse(tokens[1]);
                var firstName = tokens[2];
                var lastName = tokens[3];
                var salary = decimal.Parse(tokens[4]);

                ISoldier soldier = null;

                try
                {
                    switch (soldierType)
                    {
                        case "Private":
                            soldier = new Private(id, firstName, lastName, salary);
                            break;
                        case "LeutenantGeneral":
                            var leutenant = new LeutenantGeneral(id, firstName, lastName, salary);

                            for (int i = 5; i < tokens.Length; i++)
                            {
                                var privateId = int.Parse(tokens[i]);
                                ISoldier @private = soldiers.FirstOrDefault(p => p.Id == privateId);
                                leutenant.AddPivate(@private);
                            }

                            soldier = leutenant;
                            break;
                        case "Engineer":
                            var engineerCorps = tokens[5];
                            var enginner = new Engineer(id, firstName, lastName, salary, engineerCorps);

                            for (int i = 6; i < tokens.Length; i++)
                            {
                                var partName = tokens[i];
                                var hoursWorked = int.Parse(tokens[++i]);
                                IRepair repair = new Repair(partName, hoursWorked);
                                enginner.AddRepair(repair);
                            }

                            soldier = enginner;
                            break;
                        case "Commando":
                            var commandoCorps = tokens[5];
                            var commando = new Commando(id, firstName, lastName, salary, commandoCorps);

                            for (int i = 6; i < tokens.Length; i++)
                            {
                                var codeName = tokens[i];
                                var missionState = tokens[++i];
                                try
                                {
                                    IMission mission = new Mission(codeName, missionState);
                                    commando.AddMission(mission);
                                }
                                catch { }
                            }

                            soldier = commando;
                            break;
                        case "Spy":
                            int codeNumber = (int)salary;
                            soldier = new Spy(id, firstName, lastName, codeNumber);
                            break;
                        default:
                            throw new ArgumentException("Invalid soldier type!");
                    }
                    soldiers.Add(soldier);
                }
                catch (Exception)
                {
                }
            }

            foreach (var s in soldiers)
            {
                Console.WriteLine(s);
            }
        }
    }
}
