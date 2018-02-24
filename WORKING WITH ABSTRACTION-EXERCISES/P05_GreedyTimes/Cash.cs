using System;
using System.Collections.Generic;
using System.Text;

public class Cash
{
    public string Name { get; set; }
    public long Amount { get; set; }

    public Cash(string name, long amount)
    {
        Name = name;
        Amount = amount;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"##{Name} - {Amount}");
        return builder.ToString();
    }
}
