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
        /// 4.7 Design an algorithm and write code to find the first common ancestor of two
        /// nodes in a binary tree. Avoid storing additional nodes in a data structure.
        /// NOTE: This is not necessarily a binary search tree.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            //      5
            //    /   \
            //    3    7
            //   / \  / \
            //  1   4 6  8
            // / \        \
            // 0  2        9

            var res = LowestCommonAncestor(Generator.SampleTree(), 7, 3);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static Tree LowestCommonAncestor(Tree root, int p, int q)
        {
            if (root == null)
                return null;

            if (root.Value == p || root.Value == q)
                return root;

            bool isPinLeftTree = IsNodeInTree(root.Left, p);
            bool isQinRightTree = IsNodeInTree(root.Right, q);

            if (isPinLeftTree && isQinRightTree || !isPinLeftTree && !isQinRightTree)
            {
                return root;
            }

            if (isPinLeftTree && !isQinRightTree)
            {
                return LowestCommonAncestor(root.Left, p, q);
            }

            if (!isPinLeftTree && isQinRightTree)
            {
                return LowestCommonAncestor(root.Right, p, q);
            }

            return null;
        }

        private static bool IsNodeInTree(Tree root, int node)
        {
            if (root == null)
            {
                return false;
            }
            if (root.Value == node)
            {
                return true;
            }

            return IsNodeInTree(root.Left, node) || IsNodeInTree(root.Right, node);
        }
    }
}
