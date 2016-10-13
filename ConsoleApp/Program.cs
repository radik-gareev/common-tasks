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
        /// Sherlock and Array
        /// https://www.hackerrank.com/challenges/sherlock-and-array
        /// Watson gives Sherlock an array A of length N. 
        /// Then he asks him to determine if there exists an element in the array such that the sum of the elements on its left is equal to the sum of the elements on its right. 
        /// If there are no elements to the left/right, then the sum is considered to be zero. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new[] { 1, 2, 3, 1, 1, 2, 3 };
            int? result = Method(arr);


            Console.WriteLine("Result: " + (result?.ToString() ?? "n/a"));

            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int? Method(int[] arr)
        {
            if (arr == null || arr.Length < 3)
                return null;

            int leftSum = 0;
            int rightSum = arr.Sum();
            if(leftSum == rightSum)
                return null;

            int? result = null;

            for (int i = 0; i < arr.Length; i++)
            {
                rightSum = rightSum - arr[i];
                if(i > 0)
                    leftSum = leftSum + arr[i - 1];

                if (leftSum == rightSum)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}
