using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp
{
    [TestClass]
    public class UnitTests
    {
        private static readonly Random random = new Random();

        [TestMethod]
        public void Comparison_GetNumberOfCombinations()
        {
            List<int> randomHeights = new List<int>();
            int testCases = 10;
            for (int i = 0; i < testCases; i++)
            {
                randomHeights.Add(random.Next(30, 50));
            }

            for (int i = 0; i < randomHeights.Count; i++)
            {
                int height = randomHeights[i];
                Debug.WriteLine("{0}. Testing with X={1}...", i + 1, height);

                Stopwatch stopwatch = Stopwatch.StartNew();
                int count1 = Program.GetNumberOfCombinations(height);
                stopwatch.Stop();
                Debug.WriteLine("{0}. GetNumberOfCombinations finished in {1}ms, result={2}", i + 1, stopwatch.ElapsedMilliseconds, count1);

                stopwatch = Stopwatch.StartNew();
                uint count2 = Program.GetNumberOfCombinations_Improved(height);
                stopwatch.Stop();
                Debug.WriteLine("{0}. GetNumberOfCombinations_Improved finished in {1}ms, result={2}", i + 1, stopwatch.ElapsedMilliseconds, count2);

                Assert.AreEqual(count1, count2);
            }
        }

    }
}
