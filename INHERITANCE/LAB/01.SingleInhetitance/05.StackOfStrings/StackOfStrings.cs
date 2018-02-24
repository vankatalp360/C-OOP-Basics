using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StackOfStrings
{
    private List<string> data = new List<string>();

    public bool IsEmpty()
    {
        return data.Any();
    }
    public void Push(string item)
    {
        data.Add(item);
    }

    public string Peek()
    {
        if (data.Any())
        {
            var text = data[data.Count - 1];
            return text;
        }
        return null;
    }

    public string Pop()
    {
        if (data.Any())
        {
            var index = data.Count - 1;
            var text = data[index];
            data.RemoveAt(index);
            return text;
        }
        return null;
    }
    
}
