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
            int x = 244;
            int p = 511456452;
            int m = 1001;
            int c1 = PowerOf_Ver1(x, p, m);
            Console.WriteLine(c1);
            int c2 = PowerOf_Ver2(x, p, m);
            Console.WriteLine(c2);

            BigInteger bigIntLibrary = BigInteger.ModPow(x, p, m);
            Console.WriteLine(bigIntLibrary.ToString());
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int PowerOf_Ver1(int x, int p, int m)
        {
            int c = 1;
            for (int i = 1; i <= p; i++)
                c = (c * x) % m;

            return c;
        }

        public static int PowerOf_Ver2(int x, int p, int m)
        {
            if (p <= 1)
                return x;
            bool isPowerEven = p % 2 == 0;

            int prevX = x;

            x = (x * (x % m)) % m;
            if (isPowerEven)
            {
                return PowerOf_Ver2(x, p/2, m);
            }
            else
            {
                return (PowerOf_Ver2(x, p/2, m)*(prevX % m)) % m;
            }
        }
    }
}
