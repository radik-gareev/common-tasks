using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] arr = new[] { 1, 2, 3, 1, 1, 2, 3 };
            int? res = Program.Method(arr);
            Assert.AreEqual(3, res);

            arr = new[] { 1, 2, 1, 1, 2 };
            res = Program.Method(arr);
            Assert.AreEqual(2, res);

            arr = new[] { 1000, 0, 1000 };
            res = Program.Method(arr);
            Assert.AreEqual(1, res);

            arr = new[] { 0, 100, 0 };
            res = Program.Method(arr);
            Assert.AreEqual(1, res);
        }
    }
}
