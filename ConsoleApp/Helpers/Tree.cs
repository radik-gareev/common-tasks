﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Helpers
{
    public class Tree
    {
        public Tree Left;
        public Tree Right;
        public int Value;

        public Tree(int value)
        {
            Value = value;
        }

        public Tree(int value, Tree left, Tree right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public string BFS(Tree root)
        {
            Queue<Tree> queue = new Queue<Tree>();
            queue.Enqueue(root);
            string result = "";
            while (queue.Any())
            {
                Tree node = queue.Dequeue();
                result += node.Value + " ";

                if (node.Left != null)
                    queue.Enqueue(node.Left);

                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }

            return result;
        }

        public void DFS(Tree node)
        {
            if (node == null)
                return;

            Console.Write(node.Value + " ");
            DFS(node.Left);
            DFS(node.Right);
        }

        public static void InOrderTraversal()
        {
            Tree tree = Generator.SampleTree();

            Stack<Tree> stack = new Stack<Tree>();

            Tree current = tree;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);

                    current = current.Left;
                }

                current = stack.Pop();

                Console.WriteLine(current.Value);

                current = current.Right;
            }
        }
    }
}
