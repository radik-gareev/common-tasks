using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test()
        {
            string a = "123456";
            string b = "123456";
            string result = Program.GetLongestCommonSubstring(a, b);
            Assert.AreEqual("123456", result);

            a = "123456";
            b = "123";
            result = Program.GetLongestCommonSubstring(a, b);
            Assert.AreEqual("123", result);

            a = "123456";
            b = "456";
            result = Program.GetLongestCommonSubstring(a, b);
            Assert.AreEqual("456", result);

            a = "456";
            b = "123456";
            result = Program.GetLongestCommonSubstring(a, b);
            Assert.AreEqual("456", result);

            a = "123";
            b = "123456";
            result = Program.GetLongestCommonSubstring(a, b);
            Assert.AreEqual("123", result);

            a = "123456";
            b = "2346";
            result = Program.GetLongestCommonSubstring(a, b);
            Assert.AreEqual("234", result);

            a = "2346";
            b = "123456";
            result = Program.GetLongestCommonSubstring(a, b);
            Assert.AreEqual("234", result);

            a = "2346";
            b = "987";
            result = Program.GetLongestCommonSubstring(a, b);
            Assert.AreEqual("", result);

            a = "xcv";
            b = "912387";
            result = Program.GetLongestCommonSubstring(a, b);
            Assert.AreEqual("", result);
        }
    }
}
