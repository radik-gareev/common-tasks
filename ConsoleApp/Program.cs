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
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int[] arr = Generator.ArrayFixedLength(20);
            Print.Array(arr);
            int[] temp = new int[arr.Length];
            MergeSort(arr, temp, 0, arr.Length - 1);
            Console.WriteLine("Sorted:");
            Print.Array(arr);

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }


        private static void MergeSort(int[] arr, int[] temp, int left, int right)
        {
            if (left >= right)
                return;

            int middle = (left + right) / 2;
            MergeSort(arr, temp, left, middle);
            MergeSort(arr, temp, middle+1, right);
            Merge(arr, temp, left, middle, right);
        }

        private static void Merge(int[] arr, int[] temp, int left, int middle, int right)
        {
            int leftStart = left;
            int rightStart = middle + 1;
            int index = left;

            while(leftStart <= middle && rightStart <= right)
            {
                if(arr[leftStart] <= arr[rightStart])
                {
                    temp[index] = arr[leftStart];
                    leftStart++;
                }
                else
                {
                    temp[index] = arr[rightStart];
                    rightStart++;
                }

                index++;
            }

            if(leftStart <= middle)
            {
                for(int i = leftStart; i <= middle; i++)
                {
                    temp[index] = arr[i];
                    index++;
                }
            }

            if (rightStart <= right)
            {
                for (int i = rightStart; i <= right; i++)
                {
                    temp[index] = arr[i];
                    index++;
                }
            }

            for (int i = left; i <= right; i++)
            {
                arr[i] = temp[i];
            }
        }
    }
}
