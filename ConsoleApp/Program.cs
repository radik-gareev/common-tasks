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
        /// Given an array of integers, please find all divisors for each number
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new [] { 9, 12, 16 };
            var allDivisors = GetArrayDivisors(arr);

            Console.WriteLine(string.Join(", ", allDivisors));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static IEnumerable<int> GetArrayDivisors(int[] arr)
        {
            List<int> result = new List<int>();
            for(int i = 0; i < arr.Length; i++)
            {
                var elementDivisors = GetNumberDivisors(arr[i]);
                result.AddRange(elementDivisors);
            }

            return result;
        }

        private static IEnumerable<int> GetNumberDivisors(int number)
        {
            List<int> dividers = new List<int>();
            int max = (int)Math.Sqrt(number);
            for (int divider = 1; divider <= max; divider++)
            {
                if (number % divider == 0)
                {
                    dividers.Add(divider);
                    if(divider != number / divider)
                        dividers.Add(number / divider);
                }
            }
            return dividers;
        }
    }
}
