using System;
using System.Collections.Generic;
using System.Text;

public class Square
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Square(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void Draw()
    {
        for (int i = 0; i < Height; i++)
        {
            if (i == 0)
            {
                Console.Write('|');
                Console.Write(new string('-', Width));
                Console.WriteLine('|');
            }
            else if (i == Height - 1)
            {
                Console.Write('|');
                Console.Write(new string('-', Width));
                Console.Write('|');
            }
            else
            {
                Console.Write('|');
                Console.Write(new string(' ', Width));
                Console.WriteLine('|');
            }
        }
        Console.WriteLine();
    }
}
