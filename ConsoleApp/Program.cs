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
        /// Write a method to replace all spaces in a string with'%20'.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string str = "Mr John Smith";
            string newString = ReplaceSpaces(str);
            Console.WriteLine(newString);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static string ReplaceSpaces(string str)
        {
            int numberOfSpaces = 0;
            if (string.IsNullOrEmpty(str))
                return str;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    numberOfSpaces++;
            }

            int newStringLength = numberOfSpaces*3 + str.Length - numberOfSpaces;
            char[] newString = new char[newStringLength];
            int k = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    newString[k++] = '%';
                    newString[k++] = '2';
                    newString[k++] = '0';
                }
                else
                {
                    newString[k++] = str[i];
                }
            }

            return new string(newString);
        }
    }
}
