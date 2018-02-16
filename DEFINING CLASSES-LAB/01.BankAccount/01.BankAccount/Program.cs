using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var bankAccounts = new Dictionary<int, BankAccount>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var inputParts = input.Split();
            var command = inputParts[0];
            var id = int.Parse(inputParts[1]);

            switch (command)
            {
                case "Create": CreateAccount(id, bankAccounts);
                    break;
                case "Deposit": Deposit(id, bankAccounts, decimal.Parse(inputParts[2]));
                    break;
                case "Withdraw": Withdraw(id, bankAccounts, decimal.Parse(inputParts[2]));
                    break;
                case "Print": Print(id, bankAccounts);
                    break;
            }
        }
    }

    private static void CreateAccount(int id, Dictionary<int, BankAccount> bankAccounts)
    {
        if (!bankAccounts.ContainsKey(id))
        {
            bankAccounts[id] = new BankAccount(id);
            return;
        }
        Console.WriteLine("Account already exists");
    }

    private static void Deposit(int id, Dictionary<int, BankAccount> bankAccounts, decimal amount)
    {
        if (bankAccounts.ContainsKey(id))
        {
            bankAccounts[id].Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(int id, Dictionary<int, BankAccount> bankAccounts, decimal amount)
    {
        if (bankAccounts.ContainsKey(id))
        {
            if (bankAccounts[id].Balance >= amount)
            {
                bankAccounts[id].Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Print(int id, Dictionary<int, BankAccount> bankAccounts)
    {
        if (bankAccounts.ContainsKey(id))
        {
            Console.WriteLine(bankAccounts[id]);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }
}
