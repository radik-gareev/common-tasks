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
        /// In sorted array find 3 numbers that add up to 0.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new[] { -2, -1, 0, 1, 2};
            int[] res = FindThreeArrayElements(arr);
            Console.WriteLine(string.Join(", ", res));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int[] FindThreeArrayElements(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Tuple<int, int> res = FindTwoArrayElements(arr, (-1) * arr[i]);
                if (res != null)
                {
                    int[] array = new[] {res.Item1, res.Item2, arr[i]};
                    return array;
                }
            }

            return null;
        }

        public static Tuple<int, int> FindTwoArrayElements(int[] arr, int sum)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(arr[i]))
                {
                    int item1 = arr[i];
                    int item2 = arr[dict[arr[i]]];
                    Tuple<int, int> result = new Tuple<int, int>(item1, item2);
                    return result;
                }

                if (!dict.ContainsKey(sum - arr[i]))
                    dict[sum - arr[i]] = i;
            }

            return null;
        }
    }
}
