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
        /// Two array: one is twice longer than another.
        /// In longer array right half is empty. Both arrays are sorted.
        /// Fill long array with elements from both, so it is sorted.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] first = new[] {1, 3, 5, 7, 0, 0, 0, 0 };
            int[] second = new[] {9, 9, 9, 9 };

            MergeTwoArrays(first, second);

            Console.WriteLine(string.Join(",", first));
            Console.WriteLine(string.Join(",", second));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static void MergeTwoArrays(int[] first, int[] second)
        {
            int index1 = second.Length - 1;
            int index2 = index1;
            for (int i = first.Length - 1; i >= 0; i--)
            {
                if (GetByIndexOrMinValue(second, index2) > GetByIndexOrMinValue(first, index1))
                {
                    first[i] = second[index2];
                    index2--;
                }
                else
                {
                    first[i] = first[index1];
                    index1--;
                }
            }
        }

        private static int GetByIndexOrMinValue(int[] arr, int index)
        {
            if (index >= 0)
                return arr[index];
            else return int.MinValue;
        }
    }
}
