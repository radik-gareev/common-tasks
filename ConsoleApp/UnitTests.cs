using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConsoleApp.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void MultiplicationUlong_Test()
        {
            int testCases = 100;
            int[] arr = Generator.ArrayFixedLength(testCases * 2, 5000, 100000); ;

            for (int i = 0; i < arr.Length; i = i + 2)
            {
                ulong a = Convert.ToUInt64(arr[i]);
                ulong b = Convert.ToUInt64(arr[i + 1]);

                Debug.WriteLine("{0}. Testing MultiplicationUlong of a={1} and b={2}...", i + 1, a, b);

                ulong result = Program.MultiplicationUlong(a, b);
                ulong expectedResult = a*b;
                Debug.WriteLine("{0}. ER={1}, AR={2}", i + 1, expectedResult, result);

                Assert.AreEqual(expectedResult, result);
            }
        }

        [TestMethod]
        public void MultiplicationEnormousNumbers_WithComparison()
        {
            int testCases = 100;
            int[] arr = Generator.ArrayFixedLength(testCases * 2, 5000, 100000); ;

            for (int i = 0; i < arr.Length; i = i + 2)
            {
                string a = arr[i].ToString();
                string b = arr[i + 1].ToString();

                Debug.WriteLine("{0}. Testing MultiplicationEnormousNumbers of a={1} and b={2}...", i + 1, a, b);

                string result = Program.MultiplicationEnormousNumbers(a, b);
                ulong expectedResult = Convert.ToUInt64(a) * Convert.ToUInt64(b);
                Debug.WriteLine("{0}. ER={1}, AR={2}", i + 1, expectedResult, result);

                Assert.AreEqual(expectedResult.ToString(), result);
            }
        }

        [TestMethod]
        public void MultiplicationEnormousNumbers_WithoutComparison()
        {
            int testCases = 100;

            for (int i = 0; i < testCases; i++)
            {
                string a = Generator.StringRandomLength(100, 1000, new[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"});
                string b = Generator.StringRandomLength(100, 1000, new[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"});
                Debug.WriteLine("{0}. Testing MultiplicationEnormousNumbers of a={1} and b={2}...", i + 1, a, b);

                string result = Program.MultiplicationEnormousNumbers(a, b);
                Debug.WriteLine("{0}. Result={1}", i + 1, result);
            }
        }

    }
}
