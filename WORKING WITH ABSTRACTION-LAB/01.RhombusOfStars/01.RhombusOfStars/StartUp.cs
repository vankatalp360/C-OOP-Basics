using System;

class StartUp
{
    static void Main(string[] args)
    {
        var size = int.Parse(Console.ReadLine());

        for (int counter = 1; counter <= size; counter++)
        {
            PrintRow(counter, size);
        }
        for (int counter = size - 1; counter > 0; counter--)
        {
            PrintRow(counter, size);
        }
    }

    private static void PrintRow(int counter, int size)
    {
        Console.Write(new string(' ', size - counter));
        for (int i = 0; i < counter; i++)
        {
            Console.Write(i < counter - 1 ? "* " : "*");
        }
        Console.WriteLine();
    }
}
