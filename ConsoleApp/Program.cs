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
        /// Find the size of longest correct bracket subsequence of array.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //string[] arr = Generator.StringArrayFixedLength(10, new[] {"(", ")"});
            //string str = "((()()()((()()()())(";
            //string str = "())()";
            string str = "))()((";
            Console.WriteLine(str);
            Console.WriteLine(GetSubsequenceSize(str));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetSubsequenceSize(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            int subsequenceSize = 0;
            int unclosedCount = 0;

            foreach (char c in str)
            {
                if (c == '(')
                {
                    unclosedCount++;
                }
                else if (c == ')')
                {
                    if (unclosedCount > 0)
                    {
                        unclosedCount--;
                        subsequenceSize += 2;
                    }
                }
            }

            return subsequenceSize;
        }
    }
}
