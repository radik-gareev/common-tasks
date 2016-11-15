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
            string s = "()";
            int size = Program.GetSubsequenceSize(s);
            Assert.AreEqual(2, size);

            s = ")(";
            size = Program.GetSubsequenceSize(s);
            Assert.AreEqual(0, size);

            s = ")))()";
            size = Program.GetSubsequenceSize(s);
            Assert.AreEqual(2, size);

            s = ")))()))";
            size = Program.GetSubsequenceSize(s);
            Assert.AreEqual(2, size);

            s = "(()()()))())";
            size = Program.GetSubsequenceSize(s);
            Assert.AreEqual(10, size);

            s = "(()()())";
            size = Program.GetSubsequenceSize(s);
            Assert.AreEqual(8, size);

            s = "((((";
            size = Program.GetSubsequenceSize(s);
            Assert.AreEqual(0, size);

            s = "))))";
            size = Program.GetSubsequenceSize(s);
            Assert.AreEqual(0, size);
        }

    }
}
