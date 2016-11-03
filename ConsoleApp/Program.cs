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
        /// Sort single linked list.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            LinkedList node = Generator.LinkedListFromArray(new[] { 2, 4, 9, 1, 2, 0, 3, 72 });
            Print.LinkedList(node);
            SortSingleLinkedList(node);
            Print.LinkedList(node);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static void SortSingleLinkedList(LinkedList node)
        {
            LinkedList outer = node;
            LinkedList inner = node;
            while (outer != null)
            {
                while (inner != null)
                {                                    
                    if (inner.Next != null && inner.Value > inner.Next.Value)
                    {
                        int temp = inner.Value;
                        inner.Value = inner.Next.Value;
                        inner.Next.Value = temp;
                    }

                    inner = inner.Next;
                }

                outer = outer.Next;
                inner = node;
            }
        }
    }
}
