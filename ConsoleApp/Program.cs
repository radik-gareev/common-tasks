using System;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Given an M x N matrix in which each row and each column is sorted in ascending
        /// order, write a method to find an element.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int[,] m = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            bool res = SearchMatrix(m, 45);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static bool SearchMatrix(int[,] m, int target)
        {
            int col = 0;
            int row = m.GetLength(1) - 1;

            while (col < m.GetLength(0) && row >= 0)
            {
                if (target == m[col, row]) return true;
                if (target < m[col, row])
                {
                    row--;
                }
                else
                {
                    col++;
                }
            }

            return false;
        }
    }
}
