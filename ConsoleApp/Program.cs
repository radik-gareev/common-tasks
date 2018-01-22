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
        /// Write code to remove duplicates from an unsorted linked list.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                LinkedList list = Generator.LinkedListFromArray(new[] {1, 2, 5, 4, 6, 2, 5});
                Print.LinkedList(list);
                RemoveDuplicates(list);
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

        private static void RemoveDuplicates(LinkedList head)
        {
            LinkedList current = head;

            while (current != null)
            {
                LinkedList inner = current;

                while (inner.Next != null)
                {
                    if (current.Value == inner.Next.Value)
                    {
                        inner.Next = inner.Next.Next;
                    }
                    else
                    {
                        inner = inner.Next;
                    }
                }

                current = current.Next;
            }
        }
    }
}
