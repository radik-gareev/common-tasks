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
        /// Implement an algorithm to find the kth to last element of a singly linked list.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                LinkedList list = Generator.LinkedListFromArray(new[] { 1, 2, 5, 4 });
                Print.LinkedList(list);
                Console.WriteLine(FindKthToLastElement(list, 3));
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static int FindKthToLastElement(LinkedList head, int k)
        {
            LinkedList current = head;

            for (int i = 0; i < k; i++)
            {
                current = current.Next;
            }

            LinkedList runner = head;

            while (current.Next != null)
            {
                current = current.Next;
                runner = runner.Next;
            }

            return runner.Value;
        }
    }
}
