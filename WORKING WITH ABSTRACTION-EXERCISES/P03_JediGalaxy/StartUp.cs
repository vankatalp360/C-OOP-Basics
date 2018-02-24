using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class StartUp
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = CreateMatrics(dimestions);

            long sum = 0;
            string command;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivo = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int evilRow = evil[0];
                int evilCol = evil[1];
                EvilTurn(matrix, evilRow, evilCol);

                int ivoRow = ivo[0];
                int ivoCol = ivo[1];
                sum += IvoTurn(matrix, ivoRow, ivoCol);
            }

            Console.WriteLine(sum);

        }

        private static long IvoTurn(int[,] matrix, int row, int col)
        {
            long sum = 0;
            while (row >= 0 && col < matrix.GetLength(1))
            {
                if (PlayerIsInRange(matrix, row, col))
                {
                    sum += matrix[row, col];
                }

                col++;
                row--;
            }
            return sum;
        }

        private static void EvilTurn(int[,] matrix, int row, int col)
        {
            while (row >= 0 && col >= 0)
            {
                if (PlayerIsInRange(matrix, row, col))
                {
                    matrix[row, col] = 0;
                }
                row--;
                col--;
            }
        }

        private static bool PlayerIsInRange(int[,] matrix, int row, int col)
        {
            var rowInRange = row >= 0 && row < matrix.GetLength(0);
            var colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }

        private static int[,] CreateMatrics(int[] dimestions)
        {
            int rows = dimestions[0];
            int cols = dimestions[1];

            int[,] matrix = new int[rows, cols];

            int value = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }

            return matrix;
        }
    }
}
