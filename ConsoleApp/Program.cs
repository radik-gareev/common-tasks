using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Concatenated string with uncommon characters of two strings
        /// Two strings are given and you have to modify 1st string such that all the common characters of the 2nd strings have to be removed and the uncommon characters of the 2nd string have to be concatenated with uncommon characters of the 1st string.
        /// http://www.geeksforgeeks.org/concatenated-string-uncommon-characters-two-strings/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string s1 = "aacdb";
            string s2 = "gafd";

            string result = ConcatenateWithUncommonChars(s1, s2);
            Console.WriteLine(result);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static string ConcatenateWithUncommonChars(string str1, string str2)
        {
            string result = string.Empty;

            foreach (char c in str1)
            {
                if (str2.IndexOf(c) < 0)
                {
                    result += c;
                }
            }

            foreach (char c in str2)
            {
                if (str1.IndexOf(c) < 0)
                {
                    result += c;
                }
            }

            return result;
        }
    }
}
