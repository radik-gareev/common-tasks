using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// x^p mod M (p can be very large)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int x = 5621;
            int p = 50670;
            int m = 1001;

            int c1 = PowerOf1(x, p, m);
            Console.WriteLine(c1);
            int c2 = PowerOf2(x, p, m);
            Console.WriteLine(c2);

            BigInteger bigIntLibrary = BigInteger.ModPow(x, p, m);
            Console.WriteLine(bigIntLibrary.ToString());
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int PowerOf1(int x, int p, int m)
        {
            int c = 1;
            for (int i = 1; i <= p; i++)
                c = (c * x) % m;

            return c;
        }

        public static int PowerOf2(int x, int p, int m)
        {
            bool isPowerEven = p % 2 == 0;
            int power = 2;
            int c = x;
            while (power <= p)
            {
                c = (c * (c % m)) % m;
                power *= 2;
            }

            if (!isPowerEven)
                c = (c * (x % m)) % m;

            return c;
        }
    }
}
