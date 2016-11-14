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
        /// Mirror a binary tree.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Tree tree = Tree.GetSampleTree();

            Tree mirroredTree = MirrorBinaryTree(tree);
            Print(tree);
            Console.WriteLine();
            Print(mirroredTree);
            Console.WriteLine();
            MirrorBinaryTree_InPlace(tree);
            Print(tree);
            Console.WriteLine();
            Console.WriteLine("Press ENTER...");
            Console.Read();
        }

        public static Tree MirrorBinaryTree(Tree root)
        {
            if (root == null)
                return null;


            Tree newTree = new Tree(root.Value);
            newTree.Right = MirrorBinaryTree(root.Left);
            newTree.Left = MirrorBinaryTree(root.Right);

            return newTree;
        }

        public static void MirrorBinaryTree_InPlace(Tree root)
        {
            if (root == null)
                return;

            var tmpLeft = root.Left;
            var tmpRight = root.Right;

            if (tmpLeft != null)
            {
                if (root.Right != null)
                    root.Right.Value = tmpLeft.Value;
                else
                {
                    root.Right = new Tree(tmpLeft.Value);
                }
            }
            else
            {
                root.Right = null;
            }

            if (tmpRight != null)
            {
                if (root.Left != null)
                    root.Left.Value = tmpRight.Value;
                else
                    root.Left = new Tree(tmpRight.Value);
            }
            else
            {
                root.Left = null;
            }

            MirrorBinaryTree_InPlace(tmpLeft);
            MirrorBinaryTree_InPlace(tmpRight);
        }

        private static void Print(Tree tree)
        {
            if (tree != null)
            {
                Console.Write("{0} ", tree.Value);
                Print(tree.Left);
                Print(tree.Right);
            }
        }
    }
}
