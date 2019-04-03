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
        /// Given a sorted array of strings which is interspersed with empty strings, write a
        /// method to find the location of a given string.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            string[] arr = new string[] {"a", string.Empty, "b", string.Empty, "c", string.Empty, "d" };
            int result = Find(arr, 0, arr.Length-1, "d");
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int Find(string[] arr, int left, int right, string x)
        {
            if (right < left) return -1;

            int mid = (left + right) / 2;
            if (string.IsNullOrEmpty(arr[mid]))
            {
                int leftMid = mid - 1;
                int rightMid = mid + 1;

                while (true)
                {
                    if (leftMid < left && rightMid > right)
                        return -1;
                    if (rightMid <= right && !string.IsNullOrEmpty(arr[rightMid]))
                    {
                        mid = rightMid;
                        break;
                    }
                    if (leftMid >= left && !string.IsNullOrEmpty(arr[leftMid]))
                    {
                        mid = leftMid;
                        break;
                    }

                    rightMid++;
                    leftMid++;
                }

            }

            if (x == arr[mid])
                return mid;
            if (string.Compare(x, arr[mid]) < 0)
                return Find(arr, left, mid, x);
            else
                return Find(arr, mid+1, right, x);

        }
    }
}
