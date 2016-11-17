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
        /// Multiplication of large numbers
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ulong a = 100;
            ulong b = 550;

            Console.WriteLine(MultiplicationUlong(a, b));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static ulong MultiplicationUlong(ulong a, ulong b)
        {
            ulong result = 0;

            if (b < 10)
                return a * b;

            int rank = 0;
            while (b > 0)
            {
                ulong digit = b % 10;
                ulong power = Convert.ToUInt64(Math.Pow(10, rank));
                result += a * digit * power;
                b = b/10;
                rank++;
            }

            return result;
        }
    }
}
