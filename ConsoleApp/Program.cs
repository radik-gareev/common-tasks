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
        static void Main(string[] args)
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
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static void Method()
        {
            
        }

        private static string DFS(Tree node, string result)
        {
            if (node == null)
                return string.Empty;

            result += node.Value + " ";
            DFS(node.Left, result);
            DFS(node.Right, result);
        }
    }
}
