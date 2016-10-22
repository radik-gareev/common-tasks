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
        /// Spiral matrix iteraion
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            int[,] matrix =
            {
                {1, 2, 3},
                {5, 6, 7},
                {9, 10, 11}
            };

            string result = SpiralMatrixIteration(matrix);
            Console.WriteLine("Result: " + result);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static string SpiralMatrixIteration(int[,] matrix)
        {
            string result = string.Empty;

            int startColumn = 0,
                startRow = 0,
                currentRow = 0,
                currentColumn = matrix.GetLength(0) - 1;
            int endColumn = matrix.GetLength(0) - 1;
            int endRow = matrix.GetLength(1) - 1;

            while (startColumn <= endColumn && startRow <= endRow)
            {
                for (int i = startColumn; i <= endColumn; i++)
                {
                    result += matrix[currentRow, i] + " ";
                }
                Console.WriteLine("Result: " + result);

                currentRow = endRow;

                for (int i = startRow + 1; i <= endRow; i++)
                {
                    result += matrix[i, currentColumn] + " ";
                }
                Console.WriteLine("Result: " + result);

                startRow++;
                endRow--;
                currentColumn = 0;

                for (int i = endColumn - 1; i >= startColumn; i--)
                {
                    result += matrix[currentRow, i] + " ";
                }
                Console.WriteLine("Result: " + result);

                startColumn++;
                endColumn--;
                currentRow = startRow;

                for (int i = endRow; i >= startRow; i--)
                {
                    result += matrix[i, currentColumn] + " ";
                }
                Console.WriteLine("Result: " + result);
            }


            return result;
        }
    }
}
