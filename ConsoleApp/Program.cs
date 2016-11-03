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
        /// Sort an array with length N where 0 <= a[i] < N
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new[] { 0, 4, 5, 5, 4, 2, 1, 2 };
            CountingSort(arr);
            Console.WriteLine(string.Join(", ", arr));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int[] CountingSort(int[] arr)
        {
            int[] counting = new int[arr.Length];
            int[] sortedArray = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                counting[arr[i]]++;
            }

            int sortedIndex = 0;
            for (int i = 0; i < counting.Length; i++)
            {
                for (int j = 0; j < counting[i]; j++)
                {
                    arr[sortedIndex++] = i;
                }
            }

            return sortedArray;
        }
    }
}
