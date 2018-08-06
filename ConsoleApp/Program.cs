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
        /// Write a method to replace all spaces in a string with'%20'. You may assume that
        /// the string has sufficient space at the end of the string to hold the additional
        ///     characters, and that you are given the "true" length of the string. (Note: if implementing
        /// in Java, please use a character array so that you can perform this operation
        /// in place.)
        /// EXAMPLE
        ///     Input: "Mr John Smith
        /// Output: "Mr%20Dohn%20Smith"
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            string s = "Mr John Smith ";
            string result = ReplaceSpacesOneLoop(s);

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static string ReplaceSpaces(string s)
        {
            int spacesCount = 0;
            foreach (var c in s)
            {
                if (c == ' ')
                    spacesCount++;
            }

            char[] result = new char[s.Length + 2 * spacesCount];

            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    result[k++] = '%';
                    result[k++] = '2';
                    result[k++] = '0';
                }
                else
                {
                    result[k++] = s[i];
                }
            }

            return new string(result);
        }

        private static string ReplaceSpacesOneLoop(string s)
        {
            StringBuilder result = new StringBuilder();

            foreach (var c in s)
            {
                if (c == ' ')
                {
                    result.Append("%20");
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}
