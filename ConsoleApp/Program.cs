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
        /// http://codeforces.com/problemset/problem/588/A?locale=en
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                int[] a = new int[n];
                int[] p = new int[n];

                for (int i = 0; i < n; i++)
                {
                    string str = Console.ReadLine();
                    a[i] = int.Parse(str.Split(' ')[0]);
                    p[i] = int.Parse(str.Split(' ')[1]);
                }

                Console.WriteLine(GetMinSum(a,p));
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int GetMinSum(int[] a, int[] p)
        {
            int sum = a[0]*p[0];
            int min = p[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (p[i] < min)
                    min = p[i];

                sum = sum + a[i]*min;
            }

            return sum;
        }
    }
}
