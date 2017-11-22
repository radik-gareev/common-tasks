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
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                Tree tree = new Tree(
                    1, 
                        new Tree(2, 
                            new Tree(3,
                                new Tree(15), 
                                new Tree(16)),
                            new Tree(4)),
                        new Tree(5,
                            new Tree(6),
                            new Tree(0,
                                new Tree(11),
                                new Tree(12))));

                List<string> result = new List<string>();
                TraverseDfs(tree, result);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static string result1;

        private static void TraverseDfs(Tree root, List<string> result)
        {
            if (root == null)
                return;
            result.Add(root.Value.ToString());

            TraverseDfs(root.Left, result);
            TraverseDfs(root.Right, result);

        }
    }
}
