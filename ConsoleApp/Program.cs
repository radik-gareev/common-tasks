using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Win32;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// find the English pronunciation of the given number, e.g. 2012 - two thousand and twelve
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                int num = 91981;

                string res = IntToEnglish(num);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static string[] decimals = new[]
        {
            "",
            "",
            "twenty",
            "thirty",
            "forty",
            "feefty",
            "sixty",
            "seventy",
            "eighty",
            "ninety",
        };

        private static string[] teens = new[]
        {
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen",
        };

        private static string[] ones = new[]
        {
            "",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
        };

        private static string IntToEnglish(int num)
        {
            string result = "";
            int billions = num / 1000000000;

            if (billions > 0)
            {
                num = num%1000000000;
                result = IntToEnglish(billions) + " billions " + IntToEnglish(num);
                return result;
            }

            int millions = num/1000000;

            if (millions > 0)
            {
                num = num % 1000000;
                result = IntToEnglish(millions) + " millions " + IntToEnglish(num);
                return result;
            }

            int thousands = num / 1000;

            if (thousands > 0)
            {
                num = num % 1000;
                result = IntToEnglish(thousands) + " thousands " + IntToEnglish(num);
                return result;
            }

            int hundreds = num / 100;

            if (hundreds > 0)
            {
                num = num % 100;
                result = IntToEnglish(hundreds) + " hundreds " + IntToEnglish(num);
                return result;
            }

            int decs = num / 10;

            if (decs > 0)
            {
                num = num % 10;
                if (decs == 1)
                {
                    result += teens[num];

                    return result;
                }
                else
                {
                    result += decimals[decs] + " "+ ones[num];

                    return result;
                }
            }

            result = ones[num];

            return result;
        }
    }
}
