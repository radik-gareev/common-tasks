using System;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Given a sorted array of n integers that has been rotated an unknown number of
        /// times, write code to find an element in the array.You may assume that the array
        ///     was originally sorted in increasing order.
        ///     EXAMPLE
        /// Input: find 5 in { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14}
        /// Output: 8 (the index of 5 in the array)
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int[] arr = new[] { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };

            int result = Search(arr, 0, arr.Length - 1, 5);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int Search(int[] arr, int left, int right, int x)
        {
            if (arr.Length == 0)
            {
                return -1;
            }

            if (left > right)
            {
                return -1;
            }

            int mid = (left + right) / 2;
            if (x == arr[mid])
            {
                return mid;
            }

            if (arr[left] < arr[mid])
            {
                if (x >= arr[left] && x <= arr[mid])
                {
                    return Search(arr, left, mid - 1, x);
                }
                else
                {
                    return Search(arr, mid + 1, right, x);
                }
            }
            else if (arr[left] > arr[mid])
            {
                if (x >= arr[mid] && x <= arr[right])
                {
                    return Search(arr, mid + 1, right, x);
                }
                else
                {
                    return Search(arr, left, mid - 1, x);
                }
            }
            else if (arr[left] == arr[mid])
            {
                if(arr[right] != arr[mid])
                    return Search(arr, mid + 1, right, x);
                else
                {
                    int result = Search(arr, left, mid - 1, x);
                    if (result != -1)
                        return result;
                    else
                    return Search(arr, mid + 1, right, x);
                }
            }

            return -1;
        }
    }
}
