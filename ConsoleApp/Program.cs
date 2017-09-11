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
        /// https://www.hackerrank.com/challenges/ctci-array-left-rotation/problem
        /// A left rotation operation on an array of size  shifts each of the array's elements unit to the left. 
        /// For example, if left rotations are performed on array , then the array would become .
        /// Given an array of  integers and a number, , perform  left rotations on the array.Then print the updated array as a single line of space-separated integers.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            int[] newArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                newArray[Program.GetNewIndex(i, k, n)] = a[i];
            }

            Console.WriteLine(string.Join(" ", newArray));

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int GetNewIndex(int oldIndex, int rotations, int length)
        {
            if (oldIndex - rotations < 0)
            {
                return length - rotations + oldIndex;
            }
            else
            {
                return oldIndex - rotations;
            }
        }
    }
}
