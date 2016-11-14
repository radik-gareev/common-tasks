using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test()
        {
            int n = 5;
            Assert.AreEqual(Convert.ToString(n, 2), Program.IntToBinary(n));

            n = 0;
            Assert.AreEqual(Convert.ToString(n, 2), Program.IntToBinary(n));

            n = 1;
            Assert.AreEqual(Convert.ToString(n, 2), Program.IntToBinary(n));

            n = 8;
            Assert.AreEqual(Convert.ToString(n, 2), Program.IntToBinary(n));

            n = 100;
            Assert.AreEqual(Convert.ToString(n, 2), Program.IntToBinary(n));

            n = 1000;
            Assert.AreEqual(Convert.ToString(n, 2), Program.IntToBinary(n));

            n = 512;
            Assert.AreEqual(Convert.ToString(n, 2), Program.IntToBinary(n));

            n = 71;
            Assert.AreEqual(Convert.ToString(n, 2), Program.IntToBinary(n));
        }
    }
}
