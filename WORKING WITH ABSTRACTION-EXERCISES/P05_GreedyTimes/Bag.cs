using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Bag
{
    public Dictionary<string, Gold> Gold { get; set; }
    public Dictionary<string, Gem> Gems { get; set; }
    public Dictionary<string, Cash> AllCash { get; set; }
    public long GoldAmount => Gold.Values.Sum(g => g.Amount);
    public long GemsAmount => Gems.Values.Sum(g => g.Amount);
    public long CashAmount => AllCash.Values.Sum(c => c.Amount);
    public long Amount => GoldAmount + GemsAmount + CashAmount;

    public Bag()
    {
        Gems = new Dictionary<string, Gem>();
        AllCash = new Dictionary<string, Cash>();
        Gold = new Dictionary<string, Gold>();
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        if (Gold.Any())
        {
            builder.AppendLine($"<Gold> ${GoldAmount}");
            builder.AppendLine($"##Gold - {GoldAmount}");
        }
        if (Gems.Any())
        {
            builder.AppendLine($"<Gem> ${GemsAmount}");
            foreach (var gem in Gems.OrderByDescending(g => g.Value.Name).ThenBy(g => g.Value.Amount))
            {
                builder.AppendLine($"##{gem.Value.Name} - {gem.Value.Amount}");
            }
        }
        if (AllCash.Any())
        {
            builder.AppendLine($"<Cash> ${CashAmount}");
            foreach (var cash in AllCash.OrderByDescending(c => c.Value.Name).ThenBy(c => c.Value.Amount))
            {
                builder.AppendLine($"##{cash.Value.Name} - {cash.Value.Amount}");
            }
        }
        
        return builder.ToString();
    }
}
