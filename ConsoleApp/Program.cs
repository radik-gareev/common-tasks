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
        /// Calculate Fibonacci Series 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int length = 100;
            List<double> fibonacci = Fibonacci(length);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static List<double> Fibonacci(int length)
        {
            List<double> result = new List<double>();
            double a = 0;
            double b = 1;
            double c = 0;

            for (int i = 2; i <= length; i++)
            {
                c = a + b;
                a = b;
                b = c;
                result.Add(c);
            }

            return result;
        }
    }
}
