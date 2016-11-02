using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Reverse single linked list.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Node n = new Node(1);
            n.Next = new Node(2);
            n.Next.Next = new Node(3);
            Output(n);
            Node reversed = ReverseLinkedList(n);
            Output(reversed);

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static Node ReverseLinkedList(Node n)
        {
            Node prev = null;
            Node current = n;
            while (current != null)
            {
                Node tmp = current.Next;
                current.Next = prev;
                prev = current;
                current = tmp;
            }

            return prev;
        }

        private static void Output(Node n)
        {
            string result = string.Empty;
            while (n != null)
            {
                result += "->" + n.Value;
                n = n.Next;
            }

            Console.WriteLine(result.Substring(2)); 
        }
    }

    public class Node
    {
        public Node Next;

        public int Value;

        public Node(int value)
        {
            Value = value;
        }
    }
}
