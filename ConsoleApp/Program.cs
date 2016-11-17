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
            //string a = "8731922374567489123345674897123569482321465865487862214";
            //string b = "85323179832174568974532146879985413248572145847";
            string a = "1234";
            string b = "567";

            Console.WriteLine(MultiplicationEnormousNumbers(a, b));
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
                b = b / 10;
                rank++;
            }

            return result;
        }

        public static string MultiplicationEnormousNumbers(string a, string b)
        {
            int[] numberA = StringToIntArray(a);
            int[] numberB = StringToIntArray(b);

            string totalSum = "";
            for (int j = numberB.Length - 1; j >= 0; j--)
            {
                int remainder = 0;
                string currentMulti = "";
                for (int i = numberA.Length - 1; i >= 0; i--)
                {
                    int m = numberA[i] * numberB[j] + remainder;
                    int digit = m % 10;
                    currentMulti = digit + currentMulti;
                    remainder = m / 10;
                }

                if (remainder > 0)
                    currentMulti = remainder + currentMulti;

                // append zeros to the end of current result
                currentMulti += new string('0', numberB.Length - j - 1);
                totalSum = SumTwoStringsAsNumbers(currentMulti, totalSum);
            }

            return totalSum;
        }

        private static string SumTwoStringsAsNumbers(string a, string b)
        {
            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
                return string.Empty;

            if (string.IsNullOrEmpty(a))
                return b;

            if (string.IsNullOrEmpty(b))
                return a;

            if (a.Length > b.Length)
            {
                b = new string('0', a.Length - b.Length) + b;
            }
            else if (a.Length < b.Length)
            {
                a = new string('0', b.Length - a.Length) + a;
            }

            string result = "";
            int indexA = a.Length - 1;
            int indexB = b.Length - 1;
            int remainder = 0;

            while (indexA >= 0 && indexB >= 0)
            {
                byte numberA = Convert.ToByte(char.GetNumericValue(a[indexA]));
                byte numberB = Convert.ToByte(char.GetNumericValue(b[indexB]));

                int sum = numberA + numberB + remainder;
                int digit = sum % 10;
                result = digit + result;
                remainder = sum / 10;

                indexA--;
                indexB--;
            }

            if (remainder > 0)
                result = remainder + result;

            return result;
        }

        private static int[] StringToIntArray(string numberAsString)
        {
            if (string.IsNullOrEmpty(numberAsString))
                return null;

            int[] arr = new int[numberAsString.Length];
            for (int i = 0; i < numberAsString.Length; i++)
            {
                arr[i] = (int)char.GetNumericValue(numberAsString[i]);
            }

            return arr;
        }
    }
}
