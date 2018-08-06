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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// 1.3 Given two strings, write a method to decide if one is a permutation of the other
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                string a = "12a";
                string b = "a21";

                bool IsPermutationSort = IsPermutationLettersCount(a, b);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static bool IsPermutationSort(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b) || a.Length != b.Length)
                return false;

            var aArray = a.ToCharArray();
            var bArray = b.ToCharArray();
            Array.Sort(aArray);
            Array.Sort(bArray);
            return aArray.Equals(bArray);
        }

        private static bool IsPermutationDict(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b) || a.Length != b.Length)
                return false;

            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (var c in a)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                {
                    dict.Add(c, 1);
                }
            }

            foreach (var c in b)
            {
                if (dict.ContainsKey(c))
                    dict[c]--;
                else
                    return false;

                if (dict[c] < 0)
                    return false;
            }

            return true;
        }

        private static bool IsPermutationLettersCount(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b) || a.Length != b.Length)
                return false;

            int[] count = new int[256];

            foreach (char c in a)
            {
                int i = Convert.ToInt32(c);
                count[i]++;
            }

            foreach (char c in b)
            {
                int i = Convert.ToInt32(c);
                if (--count[i] < 0)
                    return false;
            }

            return true;
        }
    }
}
