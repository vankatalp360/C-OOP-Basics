using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] vault = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag();

            for (int i = 0; i < vault.Length; i += 2)
            {
                string name = vault[i];
                long amount = long.Parse(vault[i + 1]);

                if (name.Length == 3)
                {
                    AddCash(bag, name, amount, capacity);
                }
                else if(name.ToLower() == "gold")
                {
                    AddGold(bag, amount, capacity);
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    AddGems(bag, name, amount, capacity);
                }
            }

            if (bag.Gold.Any())
            {
                Console.WriteLine(bag.ToString().TrimEnd());
            }
            
        }

        private static void AddGems(Bag bag, string name, long amount, long capacity)
        {
            var posibleAmount = capacity - bag.Amount;
            var posibleGemsAmount = bag.GoldAmount - bag.GemsAmount;
            if (amount <= posibleAmount && amount <= posibleGemsAmount && bag.Gold.Any())
            {
                if (!bag.Gems.ContainsKey(name))
                {
                    var gem = new Gem(name, amount);
                    bag.Gems[name] = gem;
                }
                else
                {
                    bag.Gems[name].Amount += amount;
                }
            }
        }

        private static void AddGold(Bag bag, long amount, long capacity)
        {
            var posibleAmount = capacity - bag.Amount;
            if (amount <= posibleAmount)
            {
                if (!bag.AllCash.ContainsKey("gold"))
                {
                    var gold = new Gold(amount);
                    bag.Gold["gold"] = gold;
                }
                else
                {
                    bag.Gold["gold"].Amount += amount;
                }
            }
        }

        private static void AddCash(Bag bag, string name, long amount, long capacity)
        {
            var posibleAmount = capacity - bag.Amount;
            var posibleCashAmount = bag.GemsAmount - bag.CashAmount;
            if (amount <= posibleAmount && amount <= posibleCashAmount && bag.Gold.Any())
            {
                if (!bag.AllCash.ContainsKey(name))
                {
                    var cash = new Cash(name, amount);
                    bag.AllCash[name] = cash;
                }
                else
                {
                    bag.AllCash[name].Amount += amount;
                }
            }
        }
    }
}