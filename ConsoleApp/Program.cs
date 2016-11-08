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
            Print.LinkedList(list);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static LinkedList current;
        private static LinkedList list;

        private static void BinaryTreeToLinkedList(Tree node)
        {
            if (node == null)
            {
                return;
            }

            BinaryTreeToLinkedList(node.Left);

            if (node.Left == null && node.Right == null && list == null)
            {
                list = new LinkedList(node.Value);
                current = list;
            }
            else
            {
                current.Next = new LinkedList(node.Value);
                current = current.Next;
            }

            BinaryTreeToLinkedList(node.Right);
        }
    }
}
