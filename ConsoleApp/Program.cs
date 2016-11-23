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
        /// http://codeforces.com/problemset/problem/337/A
        /// The end of the school year is near and Ms. Manana, the teacher, will soon have to say goodbye to a yet another class. 
        /// She decided to prepare a goodbye present for her n students and give each of them a jigsaw puzzle (which, as wikipedia states, is a tiling puzzle that requires the assembly of numerous small, often oddly shaped, interlocking and tessellating pieces).
        /// The shop assistant told the teacher that there are m puzzles in the shop, but they might differ in difficulty and size. 
        /// Specifically, the first jigsaw puzzle consists of f1 pieces, the second one consists of f2 pieces and so on.
        /// Ms. Manana doesn't want to upset the children, so she decided that the difference between the numbers of pieces in her presents must be as small as possible. 
        /// Let A be the number of pieces in the largest puzzle that the teacher buys and B be the number of pieces in the smallest such puzzle. 
        /// She wants to choose such n puzzles that A - B is minimum possible. Help the teacher and find the least possible value of A - B.
        /// Input
        /// The first line contains space-separated integers n and m (2 ≤ n ≤ m ≤ 50). The second line contains m space-separated integers f1, f2, ..., fm (4 ≤ fi ≤ 1000) — the quantities of pieces in the puzzles sold in the shop.
        /// Output
        /// Print a single integer — the least possible difference the teacher can obtain.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new[] {5, 7, 10, 10, 12, 22};
            int m = 4;
            Console.WriteLine(GetLeastPossibleDifference(arr, m));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetLeastPossibleDifference(int[] arr, int m)
        {
            Array.Sort(arr);
            if (arr.Length < m)
                return 0;

            int start = 0;
            int end = m - 1;
            int minDifference = int.MaxValue;


            while (end < arr.Length)
            {
                if (arr[end] - arr[start] < minDifference)
                    minDifference = arr[end] - arr[start];

                start++;
                end++;
            }

            return minDifference;

        }
    }
}
