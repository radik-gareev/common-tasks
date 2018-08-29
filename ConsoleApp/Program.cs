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
        /// 2.1 Write code to remove duplicates from an unsorted linked list.
        /// FOLLOW UP
        /// How would you solve this problem if a temporary buffer is not allowed?
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            LinkedList list = Generator.LinkedListFromArray(new[] { 1, 8, 1, 2, 3, 0, 2, 3, 1 });
            list = RemoveDuplicatesWithoutBuffer(list);
            //list = RemoveDuplicatesWithTempBuffer(list);
            Print.LinkedList(list);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static LinkedList RemoveDuplicatesWithoutBuffer(LinkedList head)
        {
            if (head == null)
                return null;
            LinkedList outer = head;

            while (outer != null)
            {
                LinkedList inner = outer.Next;
                LinkedList prev = outer;

                while (inner != null)
                {
                    if (inner.Value == outer.Value)
                    {
                        prev.Next = inner.Next;
                    }
                    else
                    {
                        prev = inner;
                    }

                    inner = inner.Next;
                }

                outer = outer.Next;
            }

            return head;
        }

        private static LinkedList RemoveDuplicatesWithTempBuffer(LinkedList head)
        {
            if (head == null)
                return null;

            HashSet<int> values = new HashSet<int>();
            LinkedList prev = head;
            LinkedList current = head.Next;
            values.Add(head.Value);

            while (current != null)
            {
                if (!values.Contains(current.Value))
                {
                    values.Add(current.Value);
                    prev = current;
                }
                else
                {
                    prev.Next = current.Next;
                }

                current = current.Next;
            }

            return head;
        }
    }
}
