using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        private static List<string> paths = new List<string>();
        /// <summary>
        /// 1. Count the number of ways to move from upper left corner of rectangle to bottom right. 
        /// Moving is possible to the bottom and to the right.
        /// 2. Find the route with the largest sum.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
            {
                {0,1,2, 5 },
                {0,4,3, 6 },
                {20,1,1, 1 }
            };

            GetMatrixPaths(matrix, 0, 0, string.Empty);
            Console.WriteLine("Paths count: " + paths.Count);
            int maxSum = GetMaxSumRoute(matrix);
            Console.WriteLine("Max sum: " + maxSum);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetMaxSumRoute(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            for (int i = n - 2; i >= 0; i--)
            {
                matrix[m - 1, i] += matrix[m - 1, i + 1];
            }

            for (int j = m - 2; j >= 0; j--)
            {
                matrix[j, n - 1] += matrix[j + 1, n - 1];
            }

            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    matrix[i, j] += Math.Max(matrix[i + 1, j], matrix[i, j + 1]);
                }
            }

            return matrix[0, 0];
        }

        public static void GetMatrixPaths(int[,] matrix, int i, int j, string path)
        {
            path += string.Format("({0}, {1}) ", i, j);
            if (i >= matrix.GetLength(0) || j >= matrix.GetLength(1))
            {
                return;
            }

            if (i == matrix.GetLength(0) - 1 && j == matrix.GetLength(1) - 1)
            {
                paths.Add(path);
            }
            else
            {
                GetMatrixPaths(matrix, i + 1, j, path);
                GetMatrixPaths(matrix, i, j + 1, path);
            }
        }
    }
}
