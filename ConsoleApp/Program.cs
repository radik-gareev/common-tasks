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

                var e = new BSTIterator(tree);
                while (e.hasNext())
                {
                    Console.WriteLine(e.next().Value);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public class BSTIterator
        {
            private Tree root;
            private Tree current;
            private Tree endNode;
            //@param root: The root of binary tree.
            public BSTIterator(Tree root)
            {
                if (root == null)
                {
                    return;
                }

                this.root = root;
                this.current = root;
                this.endNode = root;

                while (endNode != null && endNode.Right != null)
                {
                    endNode = endNode.Right;
                }
                while (current != null && current.Left != null)
                {
                    current = current.Left;
                }
            }

            //@return: True if there has next node, or false
            public bool hasNext()
            {
                return current != null && current.Value <= endNode.Value;
            }

            //@return: return next node
            public Tree next()
            {
                Tree rst = current;
                //current node has right child
                if (current.Right != null)
                {
                    current = current.Right;
                    while (current.Left != null)
                    {
                        current = current.Left;
                    }
                }
                else
                {//Current node does not have right child.
                    current = findParent();
                }
                return rst;
            }

            //Find current's parent, where parent.left == current.
            public Tree findParent()
            {
                Tree node = root;
                Tree parent = null;
                int val = current.Value;
                if (val == endNode.Value)
                {
                    return null;
                }
                while (node != null)
                {
                    if (val < node.Value)
                    {
                        parent = node;
                        node = node.Left;
                    }
                    else if (val > node.Value)
                    {
                        node = node.Right;
                    }
                    else
                    {//node.val == current.val
                        break;
                    }
                }
                return parent;
            }
        }
    }
}
