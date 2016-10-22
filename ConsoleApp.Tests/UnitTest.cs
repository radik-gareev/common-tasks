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
            bool res = Program.AreStringsConverted("a", "b");
            Assert.IsTrue(res);

            res = Program.AreStringsConverted("ab", "b");
            Assert.IsTrue(res);

            res = Program.AreStringsConverted("abcpo", "opcba");
            Assert.IsTrue(res);

            res = Program.AreStringsConverted("abpo", "opcba");
            Assert.IsTrue(res);

            res = Program.AreStringsConverted("abpteo", "opcba");
            Assert.IsTrue(res);

            res = Program.AreStringsConverted("ab", "opcba");
            Assert.IsFalse(res);

            res = Program.AreStringsConverted("qwer", "zxcv");
            Assert.IsFalse(res);
        }
    }
}
