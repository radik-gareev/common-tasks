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
        /// 4.9 You are given a binary tree in which each node contains a value.
        /// Design an algorithm to print all paths which sum to a given value.
        /// The path does not need to start or end at the root or a leaf.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            //      1
            //    /   \
            //   -2   -3
            //   / \   /
            //  1   3 -2
            // /
            //-1
            //     10
            //    /   \
            //    5   -3
            //   / \    \
            //  3   2    11
            // / \   \
            // 3 -2   1
            //var res = PathSum(SampleTree2(), -1);
            var root = SampleTree();
            int depth = GetDepth(root);
            int[] path = new int[depth];
            PathSum2(root, 8, path, 0);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int GetDepth(Tree root)
        {
            if (root == null)
                return 0;

            return Math.Max(GetDepth(root.Left), GetDepth(root.Right)) + 1;
        }

        private static int PathSum(Tree root, int sum)
        {
            if (root == null)
                return 0;

            Queue<Tree> q = new Queue<Tree>();
            q.Enqueue(root);

            int result = 0;

            while (q.Count > 0)
            {
                Tree n = q.Dequeue();

                PathSumInternal(n, sum, ref result);

                if(n.Left != null)
                    q.Enqueue(n.Left);

                if (n.Right != null)
                    q.Enqueue(n.Right);
            }

            return result;
        }

        private static List<int[]> paths = new List<int[]>();
        private static void PathSum2(Tree root, int sum, int[] path, int level)
        {
            if (root == null)
                return;

            path[level] = root.Value;

            int tmp = 0;
            for (int i = level; i >= 0; i--)
            {
                tmp += path[i];
                if (tmp == sum)
                {
                    AddPath(path, i, level);
                }
            }

            PathSum2(root.Left, sum, path, level+1);
            PathSum2(root.Right, sum, path, level+1);
        }

        private static void AddPath(int[] path, int start, int end)
        {
            int[] result = new int[end - start + 1];
            for (int i = start, k = 0; i <= end; i++, k++)
            {
                result[k] = path[i];
            }

            paths.Add(result);
        }


        //     10
        //    /   \
        //    5   -3
        //   / \    \
        //  3   2    11
        // / \   \
        // 3 -2   1
        private static int PathSumInternal(Tree tree, int sum, ref int count)
        {
            if (sum - tree.Value == 0)
                count++;

            if (tree.Left != null)
                PathSumInternal(tree.Left, sum - tree.Value, ref count);

            if (tree.Right != null)
                PathSumInternal(tree.Right, sum - tree.Value, ref count);

            return count;
        }


        private static Tree SampleTree()
        {
            //     10
            //    /   \
            //    5   -3
            //   / \    \
            //  3   2    11
            // / \   \
            // 3 -2   1
            Tree tree = new Tree(10,
                new Tree(5,
                    new Tree(3,
                        new Tree(3), new Tree(-2)),
                    new Tree(2,
                        null, new Tree(1))),
                new Tree(-3,
                    null,
                    new Tree(11)));

            return tree;
        }

        private static Tree SampleTree2()
        {
            //      1
            //    /   \
            //   -2   -3
            //   / \   /
            //  1   3 -2
            // /
            //-1
            Tree tree = new Tree(1,
                new Tree(-2,
                    new Tree(1,
                        new Tree(-1), null),
                    new Tree(3)),
                new Tree(-3,
                    new Tree(-2),
                    null));

            return tree;
        }
    }
}
