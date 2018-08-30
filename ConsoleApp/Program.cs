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
        ///  2.3 Implement an algorithm to delete a node in the middle of a singly linked list,
        /// given only access to that node.
        ///     EXAMPLE
        /// Input: the node c from the linked list a->b->c->d->e
        ///     Result: nothing is returned, but the new linked list looks like a- >b- >d->e
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            LinkedList head = new LinkedList(0);
            head.Next = new LinkedList(1);
            LinkedList nodeToDelete = new LinkedList(2);
            head.Next.Next = nodeToDelete;
            head.Next.Next.Next = new LinkedList(3);
            head.Next.Next.Next.Next = new LinkedList(4);

            DeleteNode(nodeToDelete);
            Print.LinkedList(head);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static void DeleteNode(LinkedList nodeToDelete)
        {
            if (nodeToDelete == null || nodeToDelete.Next == null)
                return;

            nodeToDelete.Value = nodeToDelete.Next.Value;
            nodeToDelete.Next = nodeToDelete.Next.Next;
        }
    }
}
