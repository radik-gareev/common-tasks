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
            string str = "((((()(((";

            Console.WriteLine(str);
            Console.WriteLine(BuildValidBracketsSequence(str));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static string BuildValidBracketsSequence(string str)
        {
            int balance = 0;
            for (int i = 1; i < str.Length - 1 && str.Length > 2; i++)
            {
                if (str[i] == '(')
                    balance++;
                else if (str[i] == ')')
                    balance--;
            }

            // check first and last bracket
            if (str[0] == ')')
                str = '(' + str;
            else
                balance++;

            if (str[str.Length - 1] == '(')
                str = str + ')';
            else
                balance--;



            // need to add '('
            if (balance < 0)
            {
                str = new string('(', -1*balance) + str; 
            }

            // need to add ')'
            if (balance > 0)
            {
                str = str + new string(')', balance);
            }

            return str;
        }
    }
}
