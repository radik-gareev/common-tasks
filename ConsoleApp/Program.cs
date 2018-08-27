using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// 1.7 Write an algorithm such that if an element in an MxN matrix is 0, its entire row
        /// and column are set to 0.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int[,] m = new[,]
            {
                {1, 0, 3, 4, 17},
                {5, 6, 7, 8, 18},
                {9, 10, 11, 0, 19},
                {13, 14, 15, 16, 20}
            };

            int[,] res = SetZeros(m);

            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    Console.Write(res[i, j] + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int[,] SetZeros(int[,] m)
        {
            int cols = m.GetLength(0);
            int rows = m.GetLength(1);

            bool[] rowsZero = new bool[rows];
            bool[] colsZero = new bool[cols];

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (m[i, j] == 0)
                    {
                        colsZero[i] = true;
                        rowsZero[j] = true;
                    }
                }
            }

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (colsZero[i] || rowsZero[j])
                    {
                        m[i, j] = 0;
                    }
                }
            }

            return m;
        }
    }
}
