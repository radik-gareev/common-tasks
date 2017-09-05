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
            string s1 = "aacdb";
            string s2 = "gafd";
            string result = Program.ConcatenateWithUncommonChars(s1, s2);

            Assert.AreEqual("cbgf", result);

            s1 = "abcs";
            s2 = "cxzca";
            result = Program.ConcatenateWithUncommonChars(s1, s2);

            Assert.AreEqual("bsxz", result);
        }

    }
}
