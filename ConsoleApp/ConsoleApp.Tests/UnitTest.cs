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
            int? res = Program.FindUnpaired(new int[] { 1, 2, 2, 3, 3, 4, 5, 5 });
            Assert.AreEqual(1, res);

            res = Program.FindUnpaired(new int[] { 2, 2, 3, 3, 5, 5 });
            Assert.AreEqual(null, res);

            res = Program.FindUnpaired(new int[] { 2, 2, 3, 3, 4, 5, 5 });
            Assert.AreEqual(4, res);

            res = Program.FindUnpaired(new int[] { 2, 2, 3, 3, 4, 4, 5 });
            Assert.AreEqual(5, res);

            res = Program.FindUnpaired(new int[] { 1, 2 });
            Assert.AreEqual(1, res);

            res = Program.FindUnpaired(new int[] { 1 });
            Assert.AreEqual(1, res);
        }
    }
}
