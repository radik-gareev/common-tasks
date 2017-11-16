using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
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
        /// http://www.spoj.com/problems/PIGBANK/
        /// Piggy-Bank
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                Dictionary<int, int> coinsPtoW = new Dictionary<int, int>
                {
                    {1, 1 },
                    {50, 30 }
                };

                int weight = 100;

                Dictionary<int, int> memory = new Dictionary<int, int>(coinsPtoW);
                int res = GetMinimumAmount(weight, coinsPtoW);

                int res2 = GetMinimumAmount_Recursive(weight, coinsPtoW);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int GetMinimumAmount(int weight, Dictionary<int, int> coinsPtoW)
        {
            int[] weights = new int[weight + 1];
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = int.MaxValue;
            }

            foreach (int p in coinsPtoW.Keys)
            {
                int coinWeight = coinsPtoW[p];
                if (weights[coinWeight] > p)
                {
                    weights[coinWeight] = p;

                    for (int i = coinWeight + 1; i <= weight; i++)
                    {
                        weights[i] = Math.Min(weights[i], weights[coinWeight] + weights[i - coinWeight]);
                    }
                }
            }

            return weights[weight];
        }

        private static int GetMinimumAmount_Recursive(int weight, Dictionary<int, int> coinsPtoW)
        {
            if (weight < 0)
            {
                return int.MaxValue;
            }

            if (weight == 0)
            {
                return 0;
            }

            List<int> amounts = new List<int>();

            foreach (int p in coinsPtoW.Keys)
            {
                int amount = GetMinimumAmount_Recursive(weight - coinsPtoW[p], coinsPtoW);

                amount = amount == int.MaxValue ? amount : amount + p;
                amounts.Add(amount);
            }

            return amounts.Min();
        }
    }
}
