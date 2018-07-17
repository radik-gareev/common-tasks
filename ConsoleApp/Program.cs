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
        /// 1.1 Implement an algorithm to determine if a string has all unique characters. What
        /// if you cannot use additional data structures?
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                string s = Generator.StringRandomLength(20, 280);
                //string s = "aba";
                bool result = AllUniqueChars2(s);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static bool AllUniqueChars(string s)
        {
            HashSet<char> dict = new HashSet<char>();

            foreach(char c in s)
            {
                if (dict.Contains(c))
                    return false;
                else
                    dict.Add(c);
            }

            return true;
        }

        private static bool AllUniqueChars2(string s)
        {
            if (s.Length > 256)
                return false;

            bool[] chars = new bool[256];
            foreach(char c in s)
            {
                int k = Convert.ToInt32(c);
                if (chars[k])
                    return false;
                else chars[k] = true;
            }

            return true;
        }
    }
}
