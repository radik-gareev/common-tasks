using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Find the size of longest correct bracket subsequence of array.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //string[] arr = Generator.StringArrayFixedLength(10, new[] {"(", ")"});
            //string str = "((()()()((()()()())(";
            string str = "())(())";
            Console.WriteLine(str);
            Console.WriteLine(GetSubsequenceSize_Fixed(str));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetSubsequenceSize(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            int subsequenceSize = 0;
            int maxSize = 0;
            int unclosedCount = 0;
            int startIndex = 0;

            while (startIndex < str.Length)
            {
                char c = str[startIndex];
                if (c == '(')
                {
                    unclosedCount++;
                }
                else if (c == ')')
                {
                    unclosedCount--;
                }

                // valid sequence has ended. save the size
                if (unclosedCount < 0)
                {
                    if (maxSize < subsequenceSize)
                        maxSize = subsequenceSize;
                    subsequenceSize = 0;
                    unclosedCount = 0;
                }
                else
                {
                    subsequenceSize++;
                }

                startIndex++;
            }
            
            if (unclosedCount > 0)
                maxSize = str.Length - unclosedCount;
            else if (maxSize < subsequenceSize)
                maxSize = subsequenceSize;

            return maxSize;
        }

        public static int GetSubsequenceSize_Fixed(string str)
        {
            int len = str.Length;
            int maxLen = 0;
            int last = -1;
            if (string.IsNullOrEmpty(str))
                return 0;

            // store indexes of '('
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < len; i++)
            {
                if (str[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        last = i;
                    }
                    else
                    {
                        stack.Pop();
                        
                        if (stack.Count == 0)
                        {
                            // valid sequence has ended, calc the length
                            maxLen = Math.Max(maxLen, i - last);
                        }
                        else
                        {
                            // calc the length of the current valid sequence
                            maxLen = Math.Max(maxLen, i - stack.Peek());
                        }
                    }
                }
            }

            return maxLen;
        }
    }
}
