using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    public class Program
    {
        private static string dfs = "";

        /// <summary>
        /// Construct sorted linked list from binary search tree
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Tree tree = new Tree(5,
                new Tree(3,
                    new Tree(1,
                        new Tree(0), new Tree(2)),
                    new Tree(4)),
                new Tree(7,
                    new Tree(6),
                    new Tree(8, null,
                        new Tree(9))));

            BinaryTreeToLinkedList(tree);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static void BinaryTreeToLinkedList(Tree root)
        {
            LinkedList list = new LinkedList(root.Value);
            Tree node = root;
            Traversal(list, node);
        }

        private static void Traversal(LinkedList list, Tree node)
        {
            if (node == null)
            {
                return;
            }

            list.Next = new LinkedList(node.Value);
            Traversal(list, node.Left);
            Traversal(list, node.Right);
        }
    }
}
