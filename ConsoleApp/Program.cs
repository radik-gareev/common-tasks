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
        /// 2.5 You have two numbers represented by a linked list, where each node contains a
        /// single digit.The digits are stored in reverse order, such that the 1's digit is at the
        /// head of the list. Write a function that adds the two numbers and returns the sum
        /// as a linked list.
        ///     EXAMPLE
        ///     Input: (7-> 1 -> 6) + (5 -> 9 -> 2).That is, 617 + 295.
        /// Output: 2 -> 1 -> 9.That is, 912.
        /// FOLLOW UP
        /// Suppose the digits are stored in forward order.Repeat the above problem.
        ///     EXAMPLE
        ///     Input: (6 -> 1 -> 7) + (2 -> 9 -> 5).That is, 617 + 295.
        /// Output: 9 -> 1 -> 2.That is, 912.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            LinkedList result = SumLinkedLists(
            Generator.LinkedListFromArray(new[] { 8, 8 }),
            Generator.LinkedListFromArray(new[] { 7, 7 }));
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static LinkedList SumLinkedLists(LinkedList list1, LinkedList list2)
        {
            if (list1 == null && list2 == null)
                return null;

            LinkedList head = null;
            LinkedList current = null;
            int remain = 0;
            while (list1 != null || list2 != null || remain > 0)
            {
                int sum = remain;
                if(list1 != null)
                {
                    sum += list1.Value;
                    list1 = list1.Next;
                }

                if (list2 != null)
                {
                    sum += list2.Value;
                    list2 = list2.Next;
                }

                int digit = sum % 10;
                remain = sum / 10;

                if (head == null)
                {
                    head = new LinkedList(digit);
                    current = head;
                }
                else
                {
                    current.Next = new LinkedList(digit);
                    current = current.Next;
                }
            }

            return head;
        }
    }
}
