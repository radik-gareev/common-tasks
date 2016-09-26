using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        private static int[] array = new[] {1, 2, 2, 3, 3, 4, 5, 5};

        /// You've got an asc sorted array of ints like 2,2,3,3,4,5,5... Find an element without a pair.
        static void Main(string[] args)
        {
            int? unpaired = FindUnpaired(array);
            Console.WriteLine(unpaired);

            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int? FindUnpaired(int[] arr)
        {
            if (arr == null)
            {
                return null;
            }

            int? res = null;
            for (int i = 0; i < arr.Length; i = i + 2)
            {
                if (i == arr.Length - 1 && arr.Length%2 != 0)
                    return arr[i];

                if (arr[i] != arr[i + 1])
                {
                    res = arr[i];
                    break;
                }
            }

            return res;
        }
    }
}
