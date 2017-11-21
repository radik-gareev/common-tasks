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
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Win32;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Add element to a sorted circular linked list.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                LinkedList node = Generator.LoopedLinkedListFromArray(new[] { 1, 2, 3, 4 });

                Print.LoopedLinkedList(node);
                int n = 10;
                InsertIntoSingleLinkedList(node, n);
                Print.LoopedLinkedList(node);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static void InsertIntoSingleLinkedList(LinkedList first, int n)
        {
            if (first == null)
            {
                return;
            }

            LinkedList prev = first;
            LinkedList current = first;

            while (current.Value < n || first.Value > n)
            {
                prev = current;
                current = current.Next;

                if (current.Next == first)
                {
                    prev = current;
                    break;
                }
            }

            LinkedList tmp = new LinkedList(prev.Next.Value, prev.Next.Next);
            prev.Next.Value = n;
            prev.Next.Next = tmp;
        }
    }
}
