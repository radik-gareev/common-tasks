using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Assume you have a method isSubstring which checks if one word is a substring
        /// of another.Given two strings, s1 and s2, write code to check If s2 is a rotation of s1
        /// using only one call to isSubstring(e.g., "waterbottle" is a rotation of "erbottlewat").
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string s1 = "waterbottle";
            string s2 = "erbottlewat";
            bool isRotation = IsRotation(s1, s2);
            Console.WriteLine(isRotation);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static bool IsRotation(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) || s1.Length != s2.Length)
                return false;

            string s1s1 = s1 + s1;
            return IsSubstring(s1s1, s2);
        }

        private static bool IsSubstring(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return false;

            return s1.IndexOf(s2, StringComparison.Ordinal) >= 0;
        }
    }
}
