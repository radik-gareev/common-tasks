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
        /// 1.5 Implement a method to perform basic string compression using the counts
        /// of repeated characters.For example, the string aabcccccaaa would become
        /// a2blc5a3. If the "compressed" string would not become smaller than the original
        /// string, your method should return the original string.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            string res = Compress("aabcccccaaa");

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static string Compress(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return s;

            string result =string.Empty;
            char prev = s[0];
            int count = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (prev == s[i])
                {
                    count++;
                }
                else
                {
                    result += prev.ToString() + count;
                    count = 1;
                    prev = s[i];
                }
            }

            result += prev.ToString() + count;

            if (result.Length >= s.Length)
                return s;

            return result;
        }
    }
}
