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
        /// Split coin sequence into two heaps, making the difference minimal.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new[] {5,7,8,10,20,52,9,10,1};
            Tuple<int[], int[]> heaps = SplitIntoTwoArrays(arr);
            Console.WriteLine(string.Join(", ", heaps.Item1));
            Console.WriteLine(string.Join(", ", heaps.Item2));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static Tuple<int[], int[]> SplitIntoTwoArrays(int[] arr)
        {
            if (arr.Length < 3)
                return null;

            int[] array1 = new int[arr.Length - 1];
            int[] array2 = new int[arr.Length - 1];

            Array.Sort(arr);
            int index1 = 0;
            int index2 = 0;

            int sum1 = arr[arr.Length - 1];
            int sum2 = arr[arr.Length - 2];

            array1[index1] = sum1;
            array2[index2] = sum2;

            for (int i = arr.Length - 3; i >= 0; i--)
            {
                if (sum1 > sum2)
                {
                    array2[++index2] = arr[i];
                    sum2 += arr[i];
                }
                else
                {
                    array1[++index1] = arr[i];
                    sum1 += arr[i];
                }
            }

            return new Tuple<int[], int[]>(array1, array2);
        }
    }
}
