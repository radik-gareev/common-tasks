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
            int[] arr = new[] { 2, 5, 1, 3, 4 };

            int[] range = GetMaxOrRange(arr);

            Console.WriteLine("Range: " + string.Join(", ", range));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int[] GetMaxOrRange(int[] arr)
        {
            if(arr == null || arr.Length < 2)
                return new int[0];

            int totalOr = 0;
            int sum = 0;
            int startIndex = 0;
            int endIndex = 0;
            int prevRangeLength = arr.Length;

            for (int i = 0; i < arr.Length; i++)
                totalOr = totalOr | arr[i];

            for (int i = 0; i < arr.Length; i++)
            {
                sum = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int value = sum | arr[j];
                    if (value == totalOr)
                    {
                        if (j - i < prevRangeLength)
                        {
                            startIndex = i;
                            endIndex = j;
                            prevRangeLength = endIndex - startIndex;
                        }

                        break;
                    }
                    sum = value;
                }
            }

            if (endIndex > startIndex)
            {
                int[] result = new int[endIndex - startIndex + 1];
                Array.Copy(arr, startIndex, result, 0, result.Length);

                Console.WriteLine("Total OR: " + totalOr);
                Console.WriteLine("Range OR: " + result.Aggregate(0, (current, t) => current | t));

                return result;
            }

            return new int[0];
        }
    }
}
