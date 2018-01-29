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
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Win32;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// https://www.hackerrank.com/challenges/largest-permutation/problem
        /// You are given an array of  integers which is a permutation of the first  natural numbers.
        ///  You can swap any two elements of the array. You can make at most  swaps.
        ///  What is the largest permutation, in numerical order, you can make?
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                var res = largestPermutation(1, new[] {4, 2, 3, 5, 1});
            }
            catch (Exception e)
            {
                throw;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        static int[] largestPermutation(int k, int[] arr)
        {
            int n = arr.Length;
            int swaps = 0;

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                dict[arr[i]] = i;
            }

            for (int i = 0; i < arr.Length && swaps < k; i++)
            {
                if (arr[i] == n - i)
                    continue;

                int indexToSwap = dict[n - i];

                int tmp = arr[i];
                arr[i] = n - i;
                arr[indexToSwap] = tmp;
                dict[tmp] = indexToSwap;
                swaps++;
            }

            return arr;
        }
    }
}
