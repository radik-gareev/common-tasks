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
        /// 4.8 You have two very large binary trees: Tl, with millions of nodes, and T2, with
        /// hundreds of nodes.Create an algorithm to decide ifT2 is a subtree ofTl.
        /// A tree T2 is a subtree of Tl if there exists a node n in Tl such that the subtree ofn
        /// is identical to T2.That is, if you cut off the tree at node n, the two trees would be
        /// identical.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var res = IsSubtree(Generator.SampleTree(), Generator.SampleTree());
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static bool IsSubtree(Tree s, Tree t)
        {
            if (s == null)
                return false;

            if (t == null)
                return true;

            if (s.Value == t.Value && CheckStructure(s, t))
            {
                return true;
            }

            return IsSubtree(s.Left, t) || IsSubtree(s.Right, t);
        }

        private static bool CheckStructure(Tree s, Tree t)
        {
            if (s == null && t == null)
                return true;

            if (s == null || t == null || s.Value != t.Value)
                return false;

            return CheckStructure(s.Left, t.Left) && CheckStructure(s.Right, t.Right);
        }
    }
}
