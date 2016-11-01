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
        /// Count the number of ways to move from upper left corner of rectangle to bottom right. 
        /// Moving is possible to the bottom and to the right
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
            {
                {0,1,1 },
                {0,1,1 },
                {0,1,1 }
            };

            GetMatrixPaths(matrix, 0, 0, string.Empty);
            Console.Write("Press ENTER...");
            Console.Read();
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
