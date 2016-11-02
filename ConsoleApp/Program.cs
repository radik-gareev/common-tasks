using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Given two strings A and B, find the longest common substring.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string a = "asdgfbcddsgfsd";
            string b = "dsgbc123";
            string common = GetLongestCommonSubstring(a, b);
            Console.WriteLine(common);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static string GetLongestCommonSubstring(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
                return string.Empty;

            string result = string.Empty;
            string tempResult = string.Empty;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        int indexA = i;
                        int indexB = j;
                        while (indexA < a.Length && indexB < b.Length && a[indexA] == b[indexB])
                        {
                            tempResult += a[indexA];
                            indexA++;
                            indexB++;
                        }
                        j = j + tempResult.Length - 1;
                    }
                    else
                    {
                        if (tempResult.Length > result.Length)
                            result = tempResult;
                        tempResult = string.Empty;
                    }
                }
            }

            return result;
        }
    }
}
