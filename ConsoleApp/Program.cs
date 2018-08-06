using System;
using System.Collections;
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
        /// BST enumerator
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                Tree tree = Tree.GetSampleTree();

                var e = new TreeEnumerator(tree);
                e.GetNext();
            }
            catch (Exception e)
            {
                throw;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private class TreeEnumerator
        {
            private Tree _root;
            private int _lastValue;

            public TreeEnumerator(Tree tree)
            {
                _root = tree;
                _lastValue = int.MinValue;
            }

            public int GetNext()
            {
                Stack<Tree> stack = new Stack<Tree>();

                Tree curr = _root;

                // traverse the tree
                while (curr != null || stack.Count > 0)
                {

                    /* Reach the left most Node of the
                    curr Node */
                    while (curr != null)
                    {
                        /* place pointer to a tree node on
                           the stack before traversing
                          the node's left subtree */
                        stack.Push(curr);
                        curr = curr.Left;
                    }

                    /* Current must be NULL at this point */
                    curr = stack.Pop();

                    Console.WriteLine(curr.Value);

                    /* we have visited the node and its
                       left subtree.  Now, it's right
                       subtree's turn */
                    curr = curr.Right;
                }


                return 0;
            }
        }
    }
}
