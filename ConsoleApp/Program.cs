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
        private static Dictionary<int, int> positionsToNumberOfCombinations = new Dictionary<int, int>();

        /// <summary>
        /// Please find number of way frog could jump from 0 cell to N with given jump sizes array.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] jumps = new int[] { 1, 2 };

            int count = GetNumberOfJumpsCombinations(array, jumps);
            Console.WriteLine(count);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetNumberOfJumpsCombinations(int[] array, int[] jumps)
        {
            int count = FindNumberOfWays_Recursive(array.Length, jumps);
            return count;
        }

        private static int FindNumberOfWays_Recursive(int remainingPositions, int[] jumps)
        {
            if (remainingPositions == 0)
            {
                return 1;
            }

            if (remainingPositions < 0)
            {
                return 0;
            }

            if (positionsToNumberOfCombinations.ContainsKey(remainingPositions))
                return positionsToNumberOfCombinations[remainingPositions];

            int count = 0;

            for (int i = 0; i < jumps.Length; i++)
            {
                count += FindNumberOfWays_Recursive(remainingPositions - jumps[i], jumps);
            }

            positionsToNumberOfCombinations.Add(remainingPositions, count);

            return count;
        }
    }
}
