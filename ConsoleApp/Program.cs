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
        /// Restore valid brackets sequence by adding necessary count of '(' and ')'
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string str = ")(((";

            Console.WriteLine(str);
            Console.WriteLine(BuildValidBracketsSequence(str));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static string BuildValidBracketsSequence(string str)
        {
            int balance = 0;
            if (string.IsNullOrEmpty(str))
                return str;

            string result = string.Empty;

            foreach (char c in str)
            {
                if (c == '(')
                {
                    balance++;
                }
                else if (c == ')')
                {
                    balance--;

                    if (balance < 0)
                    {
                        result += "(";
                        balance++;
                    }
                }
                result += c;
            }

            // need to add ')'
            if (balance > 0)
            {
                result = result + new string(')', balance);
            }

            return result;
        }
    }
}
