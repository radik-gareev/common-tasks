using System;
using System.Collections;
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
        /// https://www.hackerrank.com/challenges/ctci-ransom-note/problem
        /// Hash Tables: Ransom Note
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                string magazine = "give me one grand today night";
                string note = " give one grand today";

                CanMakeNote(magazine, note);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static bool CanMakeNote(string magazine, string note)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>(StringComparer.InvariantCulture);

            string[] array = magazine.Split(' ');

            foreach (string s in array)
            {
                if (dict.ContainsKey(s))
                {
                    dict[s]++;
                }
                else
                {
                    dict[s] = 1;
                }
            }

            array = note.Split(' ');
            bool result = true;

            foreach (string word in array)
            {
                if (dict.ContainsKey(word) && dict[word] > 0)
                {
                    dict[word]--;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
