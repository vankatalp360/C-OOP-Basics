using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private bool isRun;
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.isRun = true;
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            while (this.isRun)
            {
                string input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Final stats:");
                    Console.WriteLine($"{dungeonMaster.GetStats()}");
                    isRun = false;
                }
                else
                {
                    var inputParams = input.Split().ToArray();
                    DistrubuteCommand(inputParams);
                }

            }
        }

        private void DistrubuteCommand(string[] inputParams)
        {
            var result = "";
            var command = inputParams[0];
            inputParams = inputParams.Skip(1).ToArray();
            bool invalidCommand = false;
            try
            {
                switch (command)
                {
                    case "JoinParty":
                        result = dungeonMaster.JoinParty(inputParams);
                        break;
                    case "AddItemToPool":
                        result = dungeonMaster.AddItemToPool(inputParams);
                        break;
                    case "PickUpItem":
                        result = dungeonMaster.PickUpItem(inputParams);
                        break;
                    case "UseItem":
                        result = dungeonMaster.UseItem(inputParams);
                        break;
                    case "UseItemOn":
                        result = dungeonMaster.UseItemOn(inputParams);
                        break;
                    case "GiveCharacterItem":
                        result = dungeonMaster.GiveCharacterItem(inputParams);
                        break;
                    case "GetStats":
                        result = dungeonMaster.GetStats();
                        break;
                    case "Attack":
                        result = dungeonMaster.Attack(inputParams);
                        break;
                    case "Heal":
                        result = dungeonMaster.Heal(inputParams);
                        break;
                    case "EndTurn":
                        result = dungeonMaster.EndTurn(inputParams);
                        break;
                    case "IsGameOver":
                        result = $"Final stats:" + Environment.NewLine + $"{dungeonMaster.GetStats()}";
                        isRun = dungeonMaster.IsGameOver();
                        break;
                    default:
                        invalidCommand = true;
                        break;
                }
            }
            catch (Exception e)
            {
                if (e is ArgumentException)
                {
                    result = $"Parameter Error: {e.Message}";
                }
                else
                {
                    result = $"Invalid Operation: {e.Message}";
                }
            }
            if (string.IsNullOrWhiteSpace(command))
            {
                Console.WriteLine("Final stats:");
                Console.WriteLine($"{dungeonMaster.GetStats()}");
                isRun = false;
            }
            else if(!invalidCommand)
            {
                Console.WriteLine(result.TrimEnd());
                invalidCommand = false;
            }
            if (dungeonMaster.LastSurvivorsRounds > 1)
            {
                isRun = false;
                Console.WriteLine("Final stats:");
                Console.WriteLine($"{dungeonMaster.GetStats()}");
            }
        }
    }
}