using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Sneaking
{
    class Sneaking
    {
        private static char[][] room;
        private static Dictionary<int, int> enemies = new Dictionary<int, int>();
        private static Sam sam;
        private static Nikoladze nikoladze;
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            room = new char[rows][];

            ReadRoom(rows);

            var commands = Console.ReadLine().ToCharArray();
            MovePlayers(rows, commands);
        }

        private static void MovePlayers(int rows, char[] commands)
        {
            foreach (var command in commands)
            {
                enemies = new Dictionary<int, int>();
                MoveEnemies(rows);
                MoveSam(command);
                CheckNicoladzeAlive(rows);
            }
        }

        private static void CheckNicoladzeAlive(int rows)
        {
            if (nikoladze.Row == sam.Row)
            {
                room[nikoladze.Row][nikoladze.Col] = 'X';
                Console.WriteLine("Nikoladze killed!");
                PrintRoom();
            }
        }

        private static void MoveSam(char command)
        {
            room[sam.Row][sam.Col] = '.';
            switch (command)
            {
                case 'U':
                    sam.Row--;
                    break;
                case 'D':
                    sam.Row++;
                    break;
                case 'L':
                    sam.Col--;
                    break;
                case 'R':
                    sam.Col++;
                    break;
            }
            if (enemies.ContainsKey(sam.Row))
            {
                if (enemies[sam.Row] == sam.Col)
                {
                    enemies.Distinct();
                    enemies.Remove(sam.Row);
                }
            }
            room[sam.Row][sam.Col] = 'S';


        }

        private static void CheckSamAlive(int rows)
        {
            var row = sam.Row;
            var col = sam.Col;
            if (enemies.ContainsKey(row))
            {
                if (room[row][enemies[row]] == 'b')
                {
                    if (enemies[row] < col)
                    {
                        room[row][col] = 'X';
                        Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");
                        PrintRoom();
                    }
                }
                else
                {
                    if (enemies[row] > col)
                    {
                        room[row][col] = 'X';
                        PrintRoom();
                    }
                }
            }
        }

        private static void PrintRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void MoveEnemies(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (col < room[row].Length - 1)
                        {
                            room[row][col] = '.';
                            room[row][++col] = 'b';
                            enemies[row] = col;
                        }
                        else
                        {
                            room[row][col] = 'd';
                            enemies[row] = col;
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (col > 0)
                        {
                            room[row][col] = '.';
                            room[row][--col] = 'd';
                            enemies[row] = col;
                        }
                        else
                        {
                            room[row][col] = 'b';
                            enemies[row] = col;
                        }
                    }
                }
            }
            CheckSamAlive(rows);
        }

        private static void ReadRoom(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                    if (sam == null)
                    {
                        FindSam(row, col);
                    }
                    if (nikoladze == null)
                    {
                        FindNikoladze(row, col);
                    }
                }
            }
        }

        private static void FindSam(int row, int col)
        {
            if (room[row][col] == 'S')
            {
                sam = new Sam(row, col);
            }
        }

        private static void FindNikoladze(int row, int col)
        {
            if (room[row][col] == 'N')
            {
                nikoladze = new Nikoladze(row, col);
            }
        }
        
    }
}
