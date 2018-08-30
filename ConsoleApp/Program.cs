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
        /// 2.4 Write code to partition a linked list around a value x, such that all nodes less than
        /// x come before all nodes greater than or equal to x.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var list = Generator.LinkedListFromArray(new[] { 9, 4, 6, 3, 9, 5, 6, 0 });
            list = ReorderList(list, 5);
            Print.LinkedList(list);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static LinkedList ReorderList(LinkedList head, int x)
        {
            if (head == null)
                return null;

            LinkedList less = null;
            LinkedList greater = null;
            LinkedList list1 = null;
            LinkedList list2 = null;

            while (head != null)
            {
                if (head.Value < x)
                {
                    if (less == null)
                    {
                        less = new LinkedList(head.Value);
                        list1 = less;
                    }
                    else
                    {
                        less.Next = new LinkedList(head.Value);
                        less = less.Next;
                    }
                }
                else
                {
                    if (greater == null)
                    {
                        greater = new LinkedList(head.Value);
                        list2 = greater;
                    }
                    else
                    {
                        greater.Next = new LinkedList(head.Value);
                        greater = greater.Next;
                    }
                }

                head = head.Next;
            }

            if (list1 != null)
            {
                LinkedList runner = list1;
                while (runner.Next != null)
                {
                    runner = runner.Next;
                }

                runner.Next = list2;
                return list1;
            }
            else
            {
                return list2;
            }
        }
    }
}
