using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var type = Console.ReadLine();
        var width = int.Parse(Console.ReadLine());
        var height = width;
        if (type == "Rectangle")
        {
            height = int.Parse(Console.ReadLine());
        }
        var square = new Square(width, height);
        square.Draw();
    }
}
