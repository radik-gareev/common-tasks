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
        /// 11.1 You are given two sorted arrays, A and B, where A has a large enough buffer at
        /// the end to hold B.Write a method to merge B into A in sorted order.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int[] nums1 = new[] {1, 2, 3, 0, 0, 0};
            int[] nums2 = new[] { 2, 5, 6 };
            Merge(nums1, 3, nums2, 3);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    j--;
                }

                k--;
            }

            while (j >= 0)
            {
                nums1[k] = nums2[j];
                j--;
                k--;
            }
        }
    }
}
