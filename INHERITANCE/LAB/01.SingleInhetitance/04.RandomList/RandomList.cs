using System;
using System.Collections.Generic;
using System.Text;

public class RandomList :List<string>
{
    public string RandomString()
    {
        var random = new Random();
        string text = null;

        if (this.Count > 0)
        {
            var index = random.Next(0, this.Count - 1);
            text = this[index];
        }

        return text;
    }
}