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
        /// 2.2 Implement an algorithm to find the kth to last element of a singly linked list.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            LinkedList list = Generator.LinkedListFromArray(new[] {0, 1, 2, 3, 4, 5, 6, 7, 8});
            int k = 4;
            LinkedList result = GetKthFromEnd(list, k);
            NthToLast(list, k);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static LinkedList GetKthFromEnd(LinkedList head, int k)
        {
            if (head == null) return null;

            LinkedList runner = head;
            int count = 0;

            while (runner != null && count < k)
            {
                runner = runner.Next;
                count++;
            }

            LinkedList current = head;

            while (runner != null)
            {
                current = current.Next;
                runner = runner.Next;
            }

            return current;
        }

        public static int NthToLast(LinkedList head, int k)
        {
            if (head == null)
            {
                return 0;
            }

            int i = NthToLast(head.Next, k) + 1;
            if (i == k)
            {
                Console.Write(head.Value);
            }

            return i;
        }
    }
}
