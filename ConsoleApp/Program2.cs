using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Win32;

namespace ConsoleApp
{
    public class Program2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main2(string[] args)
        {
            try
            {
                Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
                List<string> errors = new List<string>();

                string path = @"C:\DMS\AD\MSODS\Core\out\retail\Workflows\WinFabric.Management.WorkflowRunner-xddpkg";
                string[] allPaths = GetFiles(path, "Microsoft.Online.*.dll", SearchOption.AllDirectories);

                foreach (string dll in allPaths)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFile(dll);

                        if (assembly.FullName.Contains("Sync"))
                        {
                            
                        }

                        //List<Type> types = GetTypesWithDmsWorkflowAttribute(assembly).ToList();

                        //if (types.Any())
                        //{
                        //    result.Add(assembly.FullName, types.Select(type => type.Name).ToList());
                        //}
                    }

                    catch (ReflectionTypeLoadException ex)
                    {
                        errors.Add(dll);
                        continue;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            string[] searchPatterns = searchPattern.Split('|');
            List<string> files = new List<string>();
            foreach (string sp in searchPatterns)
                files.AddRange(System.IO.Directory.GetFiles(path, sp, searchOption));
            files.Sort();
            return files.ToArray();
        }

        //static IEnumerable<Type> GetTypesWithDmsWorkflowAttribute(Assembly assembly)
        //{
        //    foreach (Type type in assembly.GetTypes())
        //    {
        //        if (type.GetCustomAttributes(typeof(DmsWorkflowAttribute), true).Length > 0)
        //        {
        //            yield return type;
        //        }
        //    }
        //}

    }
}
