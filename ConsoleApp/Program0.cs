//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.IO;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Security;
//using System.Text;
//using System.Threading.Tasks;
//using ConsoleApp.Helpers;
//using System.Management.Automation;
//using System.Management.Automation.Runspaces;
//using System.Security.Cryptography;
//using System.Security.Cryptography.X509Certificates;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Auth;
//using Microsoft.WindowsAzure.Storage.Blob;
//using Microsoft.Deployment.WindowsInstaller;
//using Microsoft.Win32;

//namespace ConsoleApp
//{
//    public class Program
//    {
//        private const string ServiceFabricRegistryKey = @"SOFTWARE\Microsoft\Service Fabric";

//        /// <summary>
//        /// Registry key for upgrade codes of installed applications.
//        /// </summary>
//        private const string ServiceFabricUpgradeCodeRegistryKey =
//            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UpgradeCodes\006139A7B0712CD3886E570C6AB09E66";

//        /// <summary>
//        /// String template for registry key for Install properties of the application.
//        /// </summary>
//        private const string ProductRegistryKeyTemplate =
//            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Products\{0}\InstallProperties";

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="args"></param>
//        static void Main(string[] args)
//        {
//            try
//            {
//                bool c = IsServiceFabricMsiInstalledOnNode();
//                Console.WriteLine("Result: " + c);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//            }

//            Console.WriteLine();
//            Console.Write("Press ENTER...");
//            Console.Read();
//        }

//        internal static bool IsServiceFabricMsiInstalledOnNode()
//        {
//            try
//            {
//                // Connect to the registry remotely.
//                using (RegistryKey remoteKey = RegistryKey.OpenBaseKey(
//                    RegistryHive.LocalMachine,
//                    RegistryView.Registry64))
//                {
//                    string serviceFabricProductId = string.Empty;

//                    // Open registry key with upgrade codes of Service Fabric.
//                    using (RegistryKey serviceFabricUpgradeCodeRegistry = remoteKey.OpenSubKey(
//                        ServiceFabricUpgradeCodeRegistryKey))
//                    {
//                        if (serviceFabricUpgradeCodeRegistry == null)
//                        {

//                        }

//                        string[] valueNames = serviceFabricUpgradeCodeRegistry.GetValueNames();

//                        if (valueNames.Length == 0)
//                        {

//                        }

//                        serviceFabricProductId = valueNames.First(value => !string.IsNullOrEmpty(value));
//                    }

//                    string productRegistryKey = string.Format(
//                        ProductRegistryKeyTemplate,
//                        serviceFabricProductId);

//                    // Open Service Fabric product registry key.
//                    using (RegistryKey serviceFabricRegistry = remoteKey.OpenSubKey(productRegistryKey))
//                    {
//                        if (serviceFabricRegistry == null)
//                        {
//                            return false;
//                        }

//                        int installerValue = Convert.ToInt32(serviceFabricRegistry.GetValue("WindowsInstaller"));

//                        Console.WriteLine("{0}. RegKey: '{1}', WindowsInstaller: {2}",
//                            "Succesfully read registry to define installer type",
//                            productRegistryKey,
//                            installerValue);

//                        return installerValue == 1;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }

//        private static string GetVersionOfInstalledServiceFabric()
//        {
//            try
//            {
//                using (RegistryKey remoteKey = RegistryKey.OpenBaseKey(
//                    RegistryHive.LocalMachine,
//                    RegistryView.Registry64))
//                {
//                    // Open Service Fabric registry key.
//                    using (RegistryKey serviceFabricRegistryRoot = remoteKey.OpenSubKey(
//                        ServiceFabricRegistryKey))
//                    {
//                        if (serviceFabricRegistryRoot == null)
//                        {
//                            Console.WriteLine("Key is null. Not installed");
//                            return null;
//                        }

//                        string installerVersion = serviceFabricRegistryRoot.GetValue("FabricVersion").ToString();
//                        Console.WriteLine("Version is {0}.", installerVersion);

//                        return installerVersion;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.ToString());
//                throw;
//            }
//        }
//    }
//}
