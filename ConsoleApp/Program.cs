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
        /// https://www.hackerrank.com/challenges/ctci-making-anagrams/problem
        /// Strings: Making Anagrams
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                string a = "fcrxzwscanmligyxyvym";
                string b = "jxwtrhvujlmrpdoqbisbwhmgpmeoke";

                int result = NumberOfCharactersToDelete(a, b);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int NumberOfCharactersToDelete(string a, string b)
        {
            int result = 0;

            Dictionary<char, int> dictA = new Dictionary<char, int>();
            Dictionary<char, int> dictB = new Dictionary<char, int>();

            foreach (char c in a)
            {
                if (dictA.ContainsKey(c))
                    dictA[c]++;
                else
                    dictA[c] = 1;
            }

            foreach (char c in b)
            {
                if (dictB.ContainsKey(c))
                    dictB[c]++;
                else
                    dictB[c] = 1;
            }

            Dictionary<char, int> copy = new Dictionary<char, int>(dictA);
            foreach (char c in copy.Keys)
            {
                if (!dictB.ContainsKey(c))
                    continue;

                dictA[c] = Math.Abs(dictA[c] - dictB[c]);
                dictB[c] = 0;
            }

            result += dictA.Values.Sum();
            result += dictB.Values.Sum();


            return result;
        }
    }
}
