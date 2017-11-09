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
        private const string RoleInstallRootPathKeyword = "[RoleInstallRootPath]";
        private static List<string> messages = new List<string>();
        private static readonly string CheckLastExitCode =
            "if ($LASTEXITCODE -eq $null) { Write-Output 0 } else { Write-Output $LASTEXITCODE }";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                int[] arr = Generator.ArrayFixedLength(5, 0, 10);
                Print.Array(arr);
                QuickSort(arr, 0, arr.Length - 1);
                Print.Array(arr);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            int i = start;
            int j = end;
            int pivot = arr[(i + j) / 2];

            while (i <= j)
            {
                while (arr[i] < pivot)
                    i++;

                while (arr[j] > pivot)
                    j--;

                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                    i++;
                    j--;
                }
            }

            if (start < j)
            {
                QuickSort(arr, start, j);
            }

            if (i < end)
            {
                QuickSort(arr, i, end);
            }
        }
    }
}
