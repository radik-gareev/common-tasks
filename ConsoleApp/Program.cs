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
        /// Count the number of subarrays having OR with exact k ones.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new int[] { 0, 1, 2, 3 };
            int k = 2;

            Console.WriteLine(GetNumberOfSubarrays(arr, k));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetNumberOfSubarrays(int[] arr, int k)
        {
            if (arr == null || arr.Length < 1)
                return 0;

            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int internalSum = arr[i];
                if (NumberOfOnes(internalSum) == k)
                    result++;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    internalSum = internalSum | arr[j];
                    int numbersOfOnes = NumberOfOnes(internalSum);
                    if (numbersOfOnes == k)
                        result++;
                    else if (numbersOfOnes > k)
                        break;
                }
            }

            return result;
        }

        private static int NumberOfOnes(int n)
        {
            int count = 0;
            while (n > 0)
            {
                if (n % 2 == 1)
                    count++;
                n /= 2;
            }
            return count;
        }
    }
}
