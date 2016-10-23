using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[,] matrix = new[,]
            {
                {0,2,3,4,5 },
                {1,2,3,4,5 },
                {1,2,3,0,5 },
                {1,2,3,4,5 },
            };
            SetZeros(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static void SetZeros(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            bool[] columns = new bool[n];
            bool[] rows = new bool[m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        columns[i] = true;
                        rows[j] = true;
                    }

                }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (columns[i] || rows[j])
                        matrix[i, j] = 0;
                }
        }
    }
}
