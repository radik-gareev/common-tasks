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
        /// Implement a method to perform basic string compression using the counts
        /// of repeated characters.For example, the string aabcccccaaa would become
        /// a2blc5a3. If the "compressed" string would not become smaller than the original
        /// string, your method should return the original string.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string str = "aabcccccaaa";
            string compressed = CompressesString(str);
            Console.WriteLine(compressed);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static string CompressesString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            int countOfRepeatedChars = 1;
            char repeatedChar = str[0];
            string compressedString = string.Empty;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == repeatedChar)
                {
                    countOfRepeatedChars++;
                }
                else
                {
                    compressedString += repeatedChar.ToString() + countOfRepeatedChars;
                    repeatedChar = str[i];
                    countOfRepeatedChars = 1;
                }
            }

            compressedString += repeatedChar.ToString() + countOfRepeatedChars;
            return compressedString.Length < str.Length ? compressedString : str;
        }
    }
}
