using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Given a sequence a consisting of n integers. The player can make several steps. 
        /// In a single step he can choose an element of the sequence (let's denote it a[k]) and delete it, 
        /// at that all elements equal to a[k] + 1 and a[k] - 1 also must be deleted from the sequence. 
        /// That step brings a[k] points to the player.
        /// Find the maximum number of points that player can earn.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //int[] arr = new[] { 1, 1,2,2,3,3,4,4,4,4,5,5 };
            int[] arr = new[] { 1, 2, 1, 3, 2, 2, 2, 2, 3 };
            //int[] arr = new[] { 1, 2, 3 };

            //int[] arr = Generator.ArrayWithRandomLength(100, 10000, 1, 10000);
            Console.WriteLine(string.Join(",", arr));
            Console.WriteLine("Max points: " + GetMaxPointsBruteForce(arr));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetMaxPointsBruteForce(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return 0;

            if (arr.Length == 1)
                return arr[0];

            int maxPoints = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < arr.Length; i++)
            {
                maxPoints = Math.Max(maxPoints, GetMaxPoints_Recursive(arr, arr[i], i));
                numbersToExclude.Clear();
                indexesToExclude.Clear();
            }
            stopwatch.Stop();
            Console.WriteLine("Finished in {0}ms", stopwatch.ElapsedMilliseconds);

            return maxPoints;
        }

        private static HashSet<int> numbersToExclude = new HashSet<int>();
        private static HashSet<int> indexesToExclude = new HashSet<int>();

        private static int GetMaxPoints_Recursive(int[] arr, int value, int indexToExclude)
        {
            numbersToExclude.Add(value - 1);
            numbersToExclude.Add(value + 1);
            indexesToExclude.Add(indexToExclude);

            int points = value;
            for (int i = indexToExclude + 1; i < arr.Length; i++)
            {
                if (!numbersToExclude.Contains(arr[i]) && !indexesToExclude.Contains(i))
                {
                    points += GetMaxPoints_Recursive(arr, arr[i], i);
                }
            }

            return points;
        }
    }
}
