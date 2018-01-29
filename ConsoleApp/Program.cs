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
        /// Write a method to encode the binary tree to an array of strings and
        /// to decode this array back to the tree maintaining the initial tree structure
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                Tree tree1 = new Tree(1,
                        new Tree(2,
                            new Tree(3,
                                new Tree(4),
                                new Tree(5)),
                            new Tree(6)),
                        new Tree(7,
                            new Tree(8),
                            new Tree(9,
                                new Tree(10),
                                null)));

                Tree tree2 = new Tree(1,
                        new Tree(2,
                            new Tree(3,
                                new Tree(4),
                                null),
                            new Tree(5)),
                        new Tree(6,
                            new Tree(7),
                            new Tree(8)));

                List<string> res = SerializeTree(tree2);
                Tree deserializedTree = DeserializeTree(res.ToArray());
            }
            catch (Exception e)
            {
                throw;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int index = 0;
        private static Tree DeserializeTree(string[] s)
        {
            if (index == s.Length || s[index] == "#")
            {
                index++;
                return null;
            }

            int value = Convert.ToInt32(s[index++]);
            Tree tree = new Tree(value);
            tree.Left = DeserializeTree(s);
            tree.Right = DeserializeTree(s);

            return tree;
        }

        private static List<string> SerializeTree(Tree tree)
        {
            List<string> result = new List<string>();

            TraverseDfs(tree, result);

            return result;
        }

        private static void TraverseDfs(Tree tree, List<string> s)
        {
            if (tree == null)
            {
                s.Add("#");
                return;
            }

            s.Add(tree.Value.ToString());

            TraverseDfs(tree.Left, s);
            TraverseDfs(tree.Right, s);
        }
    }
}
