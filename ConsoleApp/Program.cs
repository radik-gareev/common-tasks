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
        /// Implement an algorithm to delete a node in the middle of a singly linked list,
        /// given only access to that node.
        /// EXAMPLE
        /// Input: the node c from the linked list a->b->c->d->e
        /// Result: nothing is returned, but the new linked list looks like a- >b- >d->e        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                LinkedList list = Generator.LinkedListFromArray(new[] { 1, 2, 5, 4 });
                Print.LinkedList(list);

                int toDelete = 5;

                DeleteNode(list, toDelete);

                Print.LinkedList(list);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static void DeleteNode(LinkedList head, int toDelete)
        {
            LinkedList node = head;

            while (node.Value != toDelete)
            {
                node = node.Next;
            }

            node.Value = node.Next.Value;
            node.Next = node.Next.Next;

            //while (node != null)
            //{
            //    node.Value = node.Next.Value;
            //    if (node.Next.Next == null)
            //    {
            //        node.Next = null;
            //    }

            //    node = node.Next;
            //}
        }
    }
}
