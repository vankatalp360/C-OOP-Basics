using System;

class StartUp
{
    static void Main(string[] args)
    {
        var line = Console.ReadLine();
        var rectangle = new Rectangle(line);

        var checks = int.Parse(Console.ReadLine());

        for (int i = 0; i < checks; i++)
        {
            var point = new Point(Console.ReadLine());
            Console.WriteLine(rectangle.ContainPoint(point));
        }
    }
}
