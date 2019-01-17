using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// 4.3 Given a sorted (increasing order) array with unique integer elements,
        /// write an algorithm to create a binary search tree with minimal height.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var result = SortedArrayToBST(new int[] {-10, -3, 0, 5, 9});
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static Tree SortedArrayToBST(int[] nums)
        {
            return ArrayToBST(nums, 0, nums.Length - 1);
        }

        private static Tree ArrayToBST(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int middle = (start + end) / 2;
            Tree root = new Tree(nums[middle]);
            root.Left = ArrayToBST(nums, start, middle - 1);
            root.Right = ArrayToBST(nums, middle + 1, end);

            return root;
        }
    }
}
