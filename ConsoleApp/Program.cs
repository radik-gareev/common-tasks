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
        /// https://www.hackerrank.com/challenges/30-2d-arrays/problem
        /// Calculate the hourglass sum for every hourglass in array, then print the maximum hourglass sum.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                int[][] arr =
                {
                    new int[] {-1, -1, 0, -9, -2, -2},
                    new int[] {-2, -1, -6, -8, -2, -5},
                    new int[] {-1, -1, -1, -2, -3, -4},
                    new int[] {-1, -9, -2, -4, -4, -5},
                    new int[] {-7, -3, -3, -2, -9, -9},
                    new int[] {-1, -3, -1, -2, -4, -5}
                };

                int maxHourglassSum = CalculateMaxHourglassSum(arr);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int CalculateMaxHourglassSum(int[][] arr)
        {
            int n=arr.GetLength(0);
            int maxSum = int.MinValue;

            for (int i = 0; i <= n - 3; i++)
            {
                int m = arr[i].GetLength(0);

                for (int j = 0; j <= m - 3; j++)
                {
                    int sum = CalculateHourglassSum(arr, i, j);

                    if (maxSum < sum)
                    {
                        maxSum = sum;
                    }
                }
            }

            return maxSum;
        }

        private static int CalculateHourglassSum(int[][] arr, int i, int j)
        {
            int firstRow = arr[i][j] + arr[i][j + 1] + arr[i][j + 2];
            int secondRow = arr[i + 1][j + 1];
            int thirdRow = arr[i+2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];

            return firstRow + secondRow + thirdRow;
        }
    }
}
