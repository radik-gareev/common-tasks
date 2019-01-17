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
        /// 4.4 Given a binary tree, design an algorithm which creates a linked list of all the nodes at
        /// each depth (e.g., if you have a tree with depth D, you'll have D linked lists).
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var result = GetLinkedListsFromTree(Generator.SampleTree());
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static List<LinkedList> GetLinkedListsFromTree2(Tree root)
        {
            if (root == null)
                return null;

            List<LinkedList> result = new List<LinkedList>();
            Queue<Tree> q = new Queue<Tree>();
            q.Enqueue(root);
            result.Add(new LinkedList(root.Value));

            while (q.Count > 0)
            {
                Tree node = q.Dequeue();

                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }

            return result;
        }

        private static List<LinkedList> GetLinkedListsFromTree(Tree root)
        {
            if (root == null)
                return null;

            List<LinkedList> result = new List<LinkedList>();
            DFS(root, 0, result);

            return result;
        }

        private static void DFS(Tree root, int level, List<LinkedList> result)
        {
            if (root == null)
                return;

            if (result.Count == level)
            {
                result.Add(new LinkedList(root.Value));
            }
            else
            {
                LinkedList current = result[level];
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = new LinkedList(root.Value);
            }
            
            DFS(root.Left, level+1, result);
            DFS(root.Right, level+1, result);
        }
    }
}
