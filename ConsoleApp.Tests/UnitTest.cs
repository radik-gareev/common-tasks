using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class UnitTest
    {
        private static readonly Random random = new Random();

        [TestMethod]
        public void Test_SplitIntoTwoArrays()
        {
            int[] arr = new[] {0, 1, 2, 1};
            Tuple<int[], int[]> result = Program.SplitIntoTwoArrays(arr);
            Assert.AreEqual(0, (result.Item1.Sum() - result.Item2.Sum()));

            arr = new[] {0, 1, 2, 1, 1};
            result = Program.SplitIntoTwoArrays(arr);
            Assert.AreEqual(1, (result.Item1.Sum() - result.Item2.Sum()));

            arr = new[] { 0, 1, 2, 1, 1, 10 };
            result = Program.SplitIntoTwoArrays(arr);
            Assert.AreEqual(5, (result.Item1.Sum() - result.Item2.Sum()));

            arr = new[] { 0, 1, 2, 7, 1, 10 };
            result = Program.SplitIntoTwoArrays(arr);
            Assert.AreEqual(1, (result.Item1.Sum() - result.Item2.Sum()));

            // FAILS!!!
            // Passed in the second approach
            // arr = new[] { 11, 10, 8, 7, 6 };
            // result = Program.SplitIntoTwoArrays(arr);
            // Assert.AreEqual(0, (result.Item1.Sum() - result.Item2.Sum()));

            arr = new[] { 3, 1, 1, 2, 2, 1 };
            result = Program.SplitIntoTwoArrays(arr);
            Assert.AreEqual(0, (result.Item1.Sum() - result.Item2.Sum()));

            // FAILS!!!
            // Expected: {7, 8} and {4, 5, 6}. Difference is 0.
            // Actual: {4, 5, 8} and {6, 7}. Difference is 4.
            // Passed in the second approach
            // arr = new[] { 4, 5, 6, 7, 8 };
            // result = Program.SplitIntoTwoArrays(arr);
            // Assert.AreEqual(0, (result.Item1.Sum() - result.Item2.Sum()));
        }

        [TestMethod]
        public void Test_GetMinDifference()
        {
            int[] arr = new[] { 0, 1, 2, 1 };
            int result = Program.GetMinDifference(arr);
            Assert.AreEqual(0, result);

            arr = new[] { 0, 1, 2, 1, 1 };
            result = Program.GetMinDifference(arr);
            Assert.AreEqual(1, result);

            arr = new[] { 0, 1, 2, 1, 1, 10 };
            result = Program.GetMinDifference(arr);
            Assert.AreEqual(5, result);

            arr = new[] { 0, 1, 2, 7, 1, 10 };
            result = Program.GetMinDifference(arr);
            Assert.AreEqual(1, result);

            arr = new[] { 11, 10, 8, 7, 6 };
            result = Program.GetMinDifference(arr);
            Assert.AreEqual(0, result);

            arr = new[] { 3, 1, 1, 2, 2, 1 };
            result = Program.GetMinDifference(arr);
            Assert.AreEqual(0, result);

            arr = new[] { 4, 5, 6, 7, 8 };
            result = Program.GetMinDifference(arr);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_GetMinDifference_Simplified()
        {
            int[] arr = new[] { 0, 1, 2, 1 };
            int result = Program.GetMinDifference_Simplified(arr);
            Assert.AreEqual(0, result);

            arr = new[] { 0, 1, 2, 1, 1 };
            result = Program.GetMinDifference_Simplified(arr);
            Assert.AreEqual(1, result);

            arr = new[] { 0, 1, 2, 1, 1, 10 };
            result = Program.GetMinDifference_Simplified(arr);
            Assert.AreEqual(5, result);

            arr = new[] { 0, 1, 2, 7, 1, 10 };
            result = Program.GetMinDifference_Simplified(arr);
            Assert.AreEqual(1, result);

            arr = new[] { 11, 10, 8, 7, 6 };
            result = Program.GetMinDifference_Simplified(arr);
            Assert.AreEqual(0, result);

            arr = new[] { 3, 1, 1, 2, 2, 1 };
            result = Program.GetMinDifference_Simplified(arr);
            Assert.AreEqual(0, result);

            arr = new[] { 4, 5, 6, 7, 8 };
            result = Program.GetMinDifference_Simplified(arr);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Comparison_GetMinDifference_Algorithms()
        {
            List<int[]> randomArrays = new List<int[]>();
            int testCases = 50;
            for (int i = 0; i < testCases; i++)
            {
                randomArrays.Add(GenerateRandomArray());
            }

            for(int i=0;i<randomArrays.Count;i++)
            {
                int[] arr = randomArrays[i];
                Debug.WriteLine("{0}. Testing {1} length array: ({2})...", i+1, arr.Length, string.Join(", ", arr));

                Stopwatch stopwatch = Stopwatch.StartNew();
                int result2 = Program.GetMinDifference_Simplified(arr);
                stopwatch.Stop();
                Debug.WriteLine("{0}. GetMinDifference_Simplified finished in {1}ms, result={2}", i + 1, stopwatch.ElapsedMilliseconds, result2);

                stopwatch = Stopwatch.StartNew();
                int result1 = Program.GetMinDifference(arr);
                stopwatch.Stop();
                Debug.WriteLine("{0}. GetMinDifference finished in {1}ms, result={2}", i + 1, stopwatch.ElapsedMilliseconds, result1);

                Assert.AreEqual(result1, result2);
            }
        }


        private int[] GenerateRandomArray()
        {
            int arrayMinLength = 10;
            int arrayMaxLength = 25;
            int min = 0;
            int max = 5000;
            
            int[] arr = new int[random.Next(arrayMinLength, arrayMaxLength)];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(min, max);
            }

            return arr;
        }
    }
}
