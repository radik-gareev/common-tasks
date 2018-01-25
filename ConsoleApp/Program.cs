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
        /// Stone Division, Revisited
        /// https://www.hackerrank.com/challenges/stone-division-2/problem
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                var res = stoneDivision(64, new long[] { 2, 4, 8, 16, 32, 64 });
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        static Dictionary<long, long> dict = new Dictionary<long, long>(); 

        static long stoneDivision(long n, long[] s)
        {
            if (dict.ContainsKey(n))
                return dict[n];

            long result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < n && n % s[i] == 0)
                {
                    long temp = (n / s[i]) * stoneDivision(s[i], s) + 1;
                    if (temp > result)
                    {
                        result = temp;
                        dict[n] = result;
                    }
                }
            }

            return result;
        }
    }
}
