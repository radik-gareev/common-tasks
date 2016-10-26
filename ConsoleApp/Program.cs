using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Value { get; set; }

        public TreeNode(int value)
        {
            Value = value;
        }
    }

    public class Program
    {
        private static int[] arr = new[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        /// <summary>
        /// Convert sorted array to the tree
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int left = 0;
            int right = arr.Length - 1;
            int middle = arr.Length / 2;
            TreeNode root = new TreeNode(arr[middle]);
            root.Left = AppendNode(root, left, middle - 1);
            root.Right = AppendNode(root, middle + 1, right);
            PrintTree(root);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static TreeNode AppendNode(TreeNode parent, int leftIndex, int rightIndex)
        {
            int mid = (leftIndex + rightIndex) / 2;
            int newRight = mid - 1;
            int newLeft = mid + 1;

            TreeNode node = new TreeNode(arr[mid]);

            if (newRight >= leftIndex)
            {
                node.Left = AppendNode(node, leftIndex, newRight);
            }
            if (newLeft <= rightIndex)
            {
                node.Right = AppendNode(node, newLeft, rightIndex);
            }

            return node;
        }

        public static void PrintTree(TreeNode tree)
        {
            if (tree != null)
            {

                Console.WriteLine("{0}\t", tree.Value);
                PrintTree(tree.Left);
                PrintTree(tree.Right);
            }
        }

    }
}
