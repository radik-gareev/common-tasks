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
            int x = 5113;
            int p = 3022830;
            int m = 117;

            int c = PowerOf(x, p, m);

            BigInteger bigIntLibrary = BigInteger.ModPow(x, p, 117);
            Console.WriteLine(c);
            Console.WriteLine(bigIntLibrary.ToString());
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int PowerOf(int x, int p, int m)
        {
            int c = 1;
            for(int i=1;i<=p;i++)
                c = (c * x) % m;

            return c;
        }
    }
}
