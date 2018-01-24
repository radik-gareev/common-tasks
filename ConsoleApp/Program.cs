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
        /// Find the water capacity given an array of border heights
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                int res = Foo(new int[] { 1, 5, 3, 7, 2, 3 });
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int Foo(int[] arr)
        {
            int[] hl = new int[arr.Length];
            int[] hr = new int[arr.Length];

            // the highest tower to the left of each position
            for (int i = 0; i < arr.Length; i++)
            {
                hl[i] = Math.Max(arr[i], i != 0 ? hl[i - 1] : 0);
            }

            // the highest tower to the right of each position
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                hr[i] = Math.Max(arr[i], i < arr.Length - 1 ? hr[i + 1] : 0);
            }

            int res = 0;

            // take the minimum at each position and add them all up.
            for (int i = 0; i < arr.Length; i++)
            {
                res += Math.Min(hl[i], hr[i]) - arr[i];
            }

            return res;
        }
    }
}
