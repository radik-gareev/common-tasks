using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// You are given 2d array A of size N*N. Some cells have values '1' and some - '0'. You can change one cell value from '0' to '1'. 
        /// Find length of longest segment 1xK or Kx1 that contains only cells with '1' values.
        /// Example:
        /// 010
        /// 010
        /// 000, the answer is 3 - you can change one middle cell in the last line to have a segment of size 3.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[,] arr = new int[,]
            {
                { 0,1,1,0,1},
                //{ 0,1,0,1,1,0},
                //{ 1,0,0,0,0,1},
                //{ 1,1,1,0,0,0},
                //{ 0,1,0,1,0,1},
                //{ 1,0,1,0,0,1},
                //{ 0,1,1,0,1,0},
            };
            Console.WriteLine(GetLongestLineLength(arr));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetLongestLineLength(int[,] arr)
        {
            int rowMaxLength = 0;

            // search in rows
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                rowMaxLength = Math.Max(rowMaxLength, GetRowMaxLength(arr, i));
            }

            // search in columns
            int colMaxLength = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                colMaxLength = Math.Max(colMaxLength, GetColMaxLength(arr, i));
            }

            return Math.Max(rowMaxLength, colMaxLength);
        }

        private static int GetRowMaxLength(int[,] arr, int row)
        {
            int maxLength = 0;
            int prevZeroIndex = -1;
            int prevPrevZeroIndex = -1;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[row, j] == 0)
                {
                    if (j - prevPrevZeroIndex - 1 > maxLength)
                    {
                        maxLength = j - prevPrevZeroIndex - 1;
                    }

                    prevPrevZeroIndex = prevZeroIndex;
                    prevZeroIndex = j;
                }
            }

            if (arr.GetLength(1) - prevPrevZeroIndex - 1 > maxLength)
            {
                maxLength = arr.GetLength(1) - prevPrevZeroIndex - 1;
            }
            return maxLength;
        }

        private static int GetColMaxLength(int[,] arr, int col)
        {
            int maxLength = 0;
            int prevZeroIndex = -1;
            int prevPrevZeroIndex = -1;
            for (int j = 0; j < arr.GetLength(0); j++)
            {
                if (arr[j, col] == 1)
                {
                    if (j - prevPrevZeroIndex - 1 > maxLength)
                    {
                        maxLength = j - prevPrevZeroIndex - 1;
                    }

                    prevPrevZeroIndex = prevZeroIndex;
                    prevZeroIndex = j;
                }
            }

            if (arr.GetLength(0) - prevPrevZeroIndex - 1 > maxLength)
            {
                maxLength = arr.GetLength(0) - prevPrevZeroIndex - 1;
            }
            return maxLength;
        }

    }


}
