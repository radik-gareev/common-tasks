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

                Debug.WriteLine("{0}. Testing multiplication of a={1} and b={2}...", i + 1, a, b);

                ulong result = Program.MultiplicationUlong(a, b);
                ulong expectedResult = a*b;
                Debug.WriteLine("{0}. ER={1}, AR={2}", i + 1, expectedResult, result);

                Assert.AreEqual(expectedResult, result);
            }
        }

    }
}
