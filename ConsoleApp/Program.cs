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
        /// Find binary representation of a number.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int n = 16;

            Console.WriteLine(IntToBinary(n));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static string IntToBinary(int n)
        {
            if (n == 0)
                return "0";

            string result = "";

            while (n > 0)
            {
                int remainder = n % 2;
                n = n / 2;
                result = remainder + result;
            }

            return result;

        }
    }
}
