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
        }
    }
}
