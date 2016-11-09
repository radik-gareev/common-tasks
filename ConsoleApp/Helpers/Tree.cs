using System;
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


        public static Tree GetSampleTree()
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

            return tree;
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
    }
}
