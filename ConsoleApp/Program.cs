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
                //{ 0,1,0,1,0},
                //{ 0,1,0,1,1,0},
                { 1,0,1,1,0,0},
                //{ 1,1,1,0,0,0},
                //{ 0,1,0,1,0,1},
                //{ 1,0,1,0,0,1},
                //{ 0,1,1,0,1,0},
            };
            Console.WriteLine("Line with 1 zero:  " + GetLongestLineLength(arr, zerosCount: 1));
            Console.WriteLine("Line with 2 zeros: " + GetLongestLineLength(arr, zerosCount: 2));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetLongestLineLength(int[,] arr, byte zerosCount)
        {
            int rowMaxLength = 0;

            // search in rows
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (zerosCount == 1)
                    rowMaxLength = Math.Max(rowMaxLength, GetRowMaxLengthOneZero(arr, i));
                else if (zerosCount == 2)
                    rowMaxLength = Math.Max(rowMaxLength, GetRowMaxLengthTwoZeros(arr, i));

            }

            // search in columns
            int colMaxLength = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                if (zerosCount == 1)
                    colMaxLength = Math.Max(colMaxLength, GetColMaxLengthOneZero(arr, i));
                else if (zerosCount == 2)
                    colMaxLength = Math.Max(colMaxLength, GetColMaxLengthTwoZeros(arr, i));
            }

            return Math.Max(rowMaxLength, colMaxLength);
        }

        #region search for one zero max sequence

        private static int GetRowMaxLengthOneZero(int[,] arr, int row)
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

        private static int GetColMaxLengthOneZero(int[,] arr, int col)
        {
            int maxLength = 0;
            int prevZeroIndex = -1;
            int prevPrevZeroIndex = -1;
            for (int j = 0; j < arr.GetLength(0); j++)
            {
                if (arr[j, col] == 0)
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

        #endregion

        #region search for two zeros max sequence

        private static int GetRowMaxLengthTwoZeros(int[,] arr, int row)
        {
            int maxLength = 0;
            int prevZeroIndex = -1;
            int prevPrevZeroIndex = -1;
            int prevPrevPrevZeroIndex = -1;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[row, j] == 0)
                {
                    if (j - prevPrevPrevZeroIndex - 1 > maxLength)
                    {
                        maxLength = j - prevPrevPrevZeroIndex - 1;
                    }

                    prevPrevPrevZeroIndex = prevPrevZeroIndex;
                    prevPrevZeroIndex = prevZeroIndex;
                    prevZeroIndex = j;
                }
            }

            if (arr.GetLength(1) - prevPrevPrevZeroIndex - 1 > maxLength)
            {
                maxLength = arr.GetLength(1) - prevPrevPrevZeroIndex - 1;
            }
            return maxLength;
        }

        private static int GetColMaxLengthTwoZeros(int[,] arr, int col)
        {
            int maxLength = 0;
            int prevZeroIndex = -1;
            int prevPrevZeroIndex = -1;
            int prevPrevPrevZeroIndex = -1;
            for (int j = 0; j < arr.GetLength(0); j++)
            {
                if (arr[j, col] == 0)
                {
                    if (j - prevPrevPrevZeroIndex - 1 > maxLength)
                    {
                        maxLength = j - prevPrevPrevZeroIndex - 1;
                    }

                    prevPrevPrevZeroIndex = prevPrevZeroIndex;
                    prevPrevZeroIndex = prevZeroIndex;
                    prevZeroIndex = j;
                }
            }

            if (arr.GetLength(0) - prevPrevPrevZeroIndex - 1 > maxLength)
            {
                maxLength = arr.GetLength(0) - prevPrevPrevZeroIndex - 1;
            }
            return maxLength;
        }

        #endregion
    }


}
