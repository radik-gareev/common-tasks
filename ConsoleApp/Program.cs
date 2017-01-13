using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    /// <summary>
    /// Print an NxM matrix with nw-se diagonals starting at bottom left corner.
    /// Ex: 
    /// 1 2 3 4
    /// 5 6 7 8
    /// 9 10 11 12
    ///  
    /// Output: 9
    /// 5 10
    /// 1 6 11
    /// 2 7 12
    /// 3 8
    /// 4
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[,] arr = new[,]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12}
            };

            PrintDiagonals(arr);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static void PrintDiagonals(int[,] arr)
        {
            for (int i = arr.GetLength(0) - 1; i >= 0; i--)
            {
                string diagonal = GetDiagonal(arr, i, 0);
                Console.WriteLine(diagonal);
            }

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                string diagonal = GetDiagonal(arr, 0, j);
                Console.WriteLine(diagonal);
            }
        }

        private static string GetDiagonal(int[,] arr, int i, int j)
        {
            string result = "";

            while (i < arr.GetLength(0) && j < arr.GetLength(1))
            {
                result += arr[i, j] + " ";
                i++;
                j++;
            }

            return result;
        }
    }
}
