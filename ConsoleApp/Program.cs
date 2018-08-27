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
        /// 1.8 Assume you have a method isSubstring which checks if one word is a
        /// substring of another.Given two strings, s1 and s2, write code to check if s2 is
        /// a rotation of s1 using only one call to isSubstring(e.g.,"waterbottle"is a rotation
        /// of "erbottlewat").
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            string s1 = "waterbottle";
            string s2 = "erbottlewat";

            bool res = IsRotation(s1, s2);

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static bool IsRotation(string s1, string s2)
        {
            return IsSubstring(s2 + s2, s1);
        }

        private static bool IsSubstring(string s1, string s2)
        {
            return s1.IndexOf(s2, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }
    }
}
