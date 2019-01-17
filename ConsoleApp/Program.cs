using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// 4.1 Implement a function to check if a binary tree is balanced. For the purposes of this
        /// question, a balanced tree is defined to be a tree such that the heights of the two
        /// subtrees of any node never differ by more than one.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var res = IsBalanced(Generator.SampleTree());
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static bool IsBalanced(Tree root)
        {
            if (CheckHeight(root) == -1)
                return false;

            return true;
        }

        public static bool IsBalanced2(Tree root)
        {
            if (root == null)
                return true;

            int leftHeight = GetHeight(root.Left);
            int rightHeight = GetHeight(root.Right);
            if (Math.Abs(leftHeight - rightHeight) > 1)
                return false;

            return IsBalanced(root.Left) && IsBalanced(root.Right);
        }

        private static int GetHeight(Tree root)
        {
            if (root == null)
                return 0;

            return Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
        }

        private static int CheckHeight(Tree root)
        {
            if (root == null)
                return 0;

            int leftHeight = CheckHeight(root.Left);

            if (leftHeight == -1)
                return -1;

            int rightHeight = CheckHeight(root.Right);

            if (rightHeight == -1)
                return -1;

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1;
            else
                return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
