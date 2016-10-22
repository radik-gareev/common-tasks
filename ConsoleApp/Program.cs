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
        /// Given two strings find if we can get B from A by add, remove, replace only 1 character.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string a = "abcde";
            string b = "abde";

            bool result = AreStringsConverted(a, b);
            Console.WriteLine(result);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static bool AreStringsConverted(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b) || Math.Abs(a.Length - b.Length) > 1)
                return false;

            char[] str1 = a.ToCharArray();
            Array.Sort(str1);
            char[] str2 = b.ToCharArray();
            Array.Sort(str2);

            int endIndex1 = a.Length - 1, endIndex2 = b.Length - 1;
            int startIndex1 = 0, startIndex2 = 0;
            int numberOfDiffences = 0;
            while (endIndex1 > startIndex1 && endIndex2 > startIndex2 && numberOfDiffences <= 1)
            {
                if (str1[startIndex1] != str2[startIndex2])
                {
                    if (str1[startIndex1] > str2[startIndex2])
                    {
                        startIndex2++;
                    }
                    else
                    {
                        startIndex1++;
                    }
                    numberOfDiffences++;
                }

                if (str1[endIndex1] != str2[endIndex2])
                {
                    if (str1[endIndex1 - 1] > str2[endIndex2 - 1])
                    {
                        endIndex1--;
                    }
                    else
                    {
                        endIndex2--;
                    }
                    numberOfDiffences++;
                }

                startIndex1++;
                startIndex2++;
                endIndex1--;
                endIndex2--;
            }

            return numberOfDiffences <= 1;
        }
    }
}
