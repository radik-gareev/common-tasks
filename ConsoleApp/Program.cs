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
        /// Find the sum of contiguous subarray within a one-dimensional array of numbers which has the largest sum.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new[] {-2, -3, 4, -1, -2, 1, 5, -3};

            int res = GetMaxSumSubarray(arr);
            Console.WriteLine(res);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetMaxSumSubarray(int[] arr)
        {
            int max = 0;
            int tempMax = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                tempMax = tempMax + arr[i];

                if (tempMax < 0)
                {
                    tempMax = 0;
                }

                if (max < tempMax)
                {
                    max = tempMax;
                }
            }

            return max;
        }
    }
}
