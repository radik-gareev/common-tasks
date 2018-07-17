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
        /// 1.2 Implement a function void reverse(char* str) in C or C++ which reverses a nullterminated string.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                string s = Generator.StringRandomLength(2, 10);
                string reversed = Reverse2(s);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static string Reverse(string s)
        {
            if(string.IsNullOrEmpty(s))
                return String.Empty;

            StringBuilder sb = new StringBuilder();

            for (int i=s.Length - 1;i>=0;i--)
            {
                sb.Append(s[i]);
            }

            return sb.ToString();
        }

        private static string Reverse2(string s)
        {
            if (string.IsNullOrEmpty(s))
                return String.Empty;

            int start = 0;
            int end = s.Length-1;

            char[] chars = s.ToCharArray();

            while (start < end)
            {
                char tmp = chars[start];
                chars[start++] = chars[end];
                chars[end--] = tmp;
            }

            return new string(chars);
        }
    }
}
