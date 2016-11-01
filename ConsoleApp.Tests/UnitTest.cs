using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
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

            arr = new[] { 11, 10, 8, 7, 6 };
            result = Program.SplitIntoTwoArrays(arr);
            Assert.AreEqual(6, (result.Item1.Sum() - result.Item2.Sum()));

            arr = new[] { 3, 1, 1, 2, 2, 1 };
            result = Program.SplitIntoTwoArrays(arr);
            Assert.AreEqual(0, (result.Item1.Sum() - result.Item2.Sum()));

            // FAILS!!!
            // Expected: {7, 8} and {4, 5, 6}. Difference is 0.
            // Actual: {4, 5, 8} and {6, 7}. Difference is 4.
            arr = new[] { 4, 5, 6, 7, 8 };
            result = Program.SplitIntoTwoArrays(arr);
            Assert.AreEqual(0, (result.Item1.Sum() - result.Item2.Sum()));
        }
    }
}
