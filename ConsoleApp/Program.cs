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
        /// 4.5 Implement a function to check if a binary tree is a binary search tree
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            bool res = IsBST(Generator.SampleTree());
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static bool IsBST(Tree root, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            if (root == null)
                return true;

            if (root.Value < minValue || root.Value > maxValue)
            {
                return false;
            }

            return IsBST(root.Left, minValue, root.Value) && IsBST(root.Right, root.Value, maxValue);
        }
    }
}
