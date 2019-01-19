using System;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// 4.6 Write an algorithm to find the 'next' node (i.e., in-order successor) of a given node in
        /// a binary search tree. You may assume that each node has a link to its parent.
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

            Tree tree = Generator.SampleTree();
            Tree node = tree.Right.Right.Right;
            Tree result = GetNext(node);

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static Tree GetNext(Tree node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Right == null)
            {
                Tree parent = node.Parent;
                while (parent != null && parent.Left != node)
                {
                    node = parent;
                    parent = parent.Parent;
                }
                return parent;
            }

            Tree next = node.Right;
            while (next.Left != null)
            {
                next = next.Left;
            }

            return next;
        }
    }
}
