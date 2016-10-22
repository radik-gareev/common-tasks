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
        /// Array with 0<=a[i]<=array.Length
        /// Output duplicates
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] array = new[] {0, 5, 2, 4, 5, 1, 4, 7, 2};
            OutputDuplicates(array);

            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static void OutputDuplicates(int[] array)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (dict.ContainsKey(array[i]))
                    Console.WriteLine("Duplicates at " + dict[array[i]] + " and at " + i + " postions");
                else
                    dict[array[i]] = i;
            }
        }
    }
}
