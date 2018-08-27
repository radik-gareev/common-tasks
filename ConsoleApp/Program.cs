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
        /// 1.6 Given an image represented by an NxN matrix, where each pixel in the image is
        /// 4 bytes, write a method to rotate the image by 90 degrees.Can you do this in place?
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int[,] m = new[,]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };

            int[,] res = RotateMatrix(m);

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

        private static int[,] RotateMatrix(int[,] m)
        {
            int size = m.GetLength(0) - 1;

            for (int layer = 0; layer < (size + 1) / 2; layer++)
            {
                for (int i = layer; i < size - layer; i++)
                {
                    int tmp = m[layer, i];

                    // top left
                    m[layer, i] = m[i, size - layer];

                    // top right
                    m[i, size - layer] = m[size - layer, size - i];

                    // bottom right
                    m[size - layer, size - i] = m[size - i, layer];

                    // bottom left
                    m[size - i, layer] = tmp;
                }
            }

            return m;
        }
    }
}
