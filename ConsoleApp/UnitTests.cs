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
        public void Test()
        {

            List<int[]> randomArrays = new List<int[]>();
            int testCases = 100;
            for (int i = 0; i < testCases; i++)
            {
                int[] array = Generator.ArrayWithRandomLength(50, 100);
                randomArrays.Add(array);
            }

            for (int i = 0; i < randomArrays.Count; i++)
            {
                int[] randomArray = randomArrays[i];

                Debug.WriteLine("{0}. Testing with randomArray.Length={1}...", i + 1, randomArray.Length);

                var stopwatch = Stopwatch.StartNew();
                //Program.GetMaxSumSubarray(randomArray);
                stopwatch.Stop();
                Debug.WriteLine("{0}. GetNumberOfJumpsCombinations_Improved finished in {1}ms, result={2}", i + 1, stopwatch.ElapsedMilliseconds, "");
            }
        }

    }
}
