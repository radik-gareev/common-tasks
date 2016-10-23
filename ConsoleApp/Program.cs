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
        ///  rotate the matrix by 90 degrees
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[,] matrix = new[,]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };

            //{ 13, 9, 5, 1},
            //{ 14, 10, 6, 2},
            //{ 15, 11, 7, 3},
            //{ 16, 12, 8, 4}

            int[,] rotated = RotateMatrix(matrix);
            for (int i = 0; i < rotated.GetLength(0); i++)
            {
                for (int j = 0; j < rotated.GetLength(1); j++)
                {
                    Console.Write(rotated[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int[,] RotateMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int layer = 0; layer < n/2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;

                    // save top
                    int top = matrix[first, i];

                    // left -> top
                    matrix[first, i] = matrix[last - offset, first];

                    // bottom -> left
                    matrix[last - offset, first] = matrix[last, last - offset];

                    // right -> bottom
                    matrix[last, last - offset] = matrix[i, last];

                    // top -> right
                    matrix[i, last] = top;
                }
            }
            return matrix;
        }
    }
}
