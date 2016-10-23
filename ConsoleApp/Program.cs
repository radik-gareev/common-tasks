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
        /// Binary search
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            int elem = 10;
            int index = BinarySearch(arr, elem);
            Console.WriteLine(index);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int BinarySearch(int[] arr, int elementToFind)
        {
            int left = 0;
            int right = arr.Length - 1;
            int mid = (right + left) / 2;

            while (left <= right)
            {
                if (arr[mid] == elementToFind)
                    return mid;

                if (arr[mid] > elementToFind)
                {
                    right = mid + 1;
                }
                else
                {
                    left = mid + 1;
                }

                mid = (right + left) / 2;
            }

            return -1;
        }
    }
}
