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
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Win32;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// https://www.hackerrank.com/challenges/ctci-is-binary-search-tree/problem
        /// Trees: Is This a Binary Search Tree?
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                Tree tree1 = new Tree(4,
                    new Tree(2,
                        new Tree(1),
                        new Tree(3)),
                    new Tree(6,
                        new Tree(5),
                        new Tree(7)));

                Tree tree = new Tree(8,
                    new Tree(6,
                        new Tree(4,
                            new Tree(2,
                                new Tree(1),
                                new Tree(3)),
                            null),
                        new Tree(7,
                            new Tree(5),
                            null)),
                    new Tree(10,
                        new Tree(9),
                        new Tree(11)));

                bool result = IsTreeBinarySearchTree(tree1, int.MinValue, int.MaxValue);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static bool IsTreeBinarySearchTree(Tree tree, int min, int max)
        {
            if (tree == null)
            {
                return true;
            }


            bool result = tree.Value > min && tree.Value < max;

            return result && IsTreeBinarySearchTree(tree.Left, min, tree.Value) &&
                   IsTreeBinarySearchTree(tree.Right, tree.Value, max);
        }
    }
}
