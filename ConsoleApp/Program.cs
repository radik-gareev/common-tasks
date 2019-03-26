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
        /// 11.2 Write a method to sort an array of strings so that all the anagrams are next to
        /// each other.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static string[] SortByAnagram(string[] arr)
        {
            string[] result = new string[arr.Length];
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach (string s in arr)
            {
                string sortedString = SortChars(s);
                if (map.ContainsKey(sortedString))
                {
                    map[sortedString].Add(s);
                }
                else
                {
                    map.Add(sortedString, new List<string> { s });
                }
            }

            int i = 0;
            foreach (string key in map.Keys)
            {
                foreach (string s in map[key])
                {
                    result[i] = s;
                    i++;
                }
            }

            return result;
        }

        private static string SortChars(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Sort(arr);

            return new string(arr);
        }
    }
}
