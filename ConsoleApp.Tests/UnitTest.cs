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
            int[] arr = new[] { 0, 1, 2, 3, 4};
            int sum = 6;
            Tuple<int, int> res = Program.FindTwoArrayElements(arr, sum);
            Assert.IsNotNull(res);
            Assert.AreEqual(4, res.Item1);
            Assert.AreEqual(2, res.Item2);

            arr = new[] { -10, 0, 10, 3, 4 };
            sum = 0;
            res = Program.FindTwoArrayElements(arr, sum);
            Assert.IsNotNull(res);
            Assert.AreEqual(10, res.Item1);
            Assert.AreEqual(-10, res.Item2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] arr = new[] { -2, -1, 0, 1, 2};
            int[] res = Program.FindThreeArrayElements(arr);
            Assert.IsNotNull(res);
            Assert.AreEqual(3, res.Length);
            Assert.IsTrue(res.Contains(-2));
            Assert.IsTrue(res.Contains(0));
            Assert.IsTrue(res.Contains(2));

            arr = new[] { -10, 0, 10, 3, 4 };
            res = Program.FindThreeArrayElements(arr);
            Assert.IsNotNull(res);
            Assert.AreEqual(3, res.Length);
            Assert.IsTrue(res.Contains(-10));
            Assert.IsTrue(res.Contains(0));
            Assert.IsTrue(res.Contains(10));
        }
    }
}
