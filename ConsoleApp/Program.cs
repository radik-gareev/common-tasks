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
        /// Find shortest range in array which OR is maximal.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new[] {0,3,2,1,9};

            int maxSum = GetMaxOr(arr);

            Console.WriteLine(maxSum);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetMaxOr(int[] arr)
        {
            int totalMaxSum = 0;
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum | arr[i];
                if (sum < 0)
                    sum = 0;
                if (totalMaxSum < sum)
                    totalMaxSum = sum;
            }

            return totalMaxSum;
        }
    }
}
