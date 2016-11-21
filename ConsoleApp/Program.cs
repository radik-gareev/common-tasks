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
        /// Reverse words in array without additional memory
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new[] { 0, 1, 2, 3, 4, 5};
            Console.WriteLine(string.Join(",", ReverseArray(arr)));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int[] ReverseArray(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return arr;

            int i = 0;
            int n = arr.Length;
            while (i < n / 2)
            {
                int a = arr[i];
                int b = arr[n - i - 1];
                int tmp = a;
                arr[i] = b;
                arr[n - i - 1] = tmp;
                i++;
            }

            return arr;
        }
    }
}
