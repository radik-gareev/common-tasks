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
        private const string RoleInstallRootPathKeyword = "[RoleInstallRootPath]";
        private static List<string> messages = new List<string>();
        private static readonly string CheckLastExitCode =
            "if ($LASTEXITCODE -eq $null) { Write-Output 0 } else { Write-Output $LASTEXITCODE }";

        /// <summary>
        /// https://www.hackerrank.com/challenges/matrix-rotation-algo/problem
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                int[,] matrix = new[,]
                {
                    {1, 2, 3, 4},
                    {5, 6, 7, 8},
                    {9, 10, 11, 12},
                    {13, 14, 15, 16},
                    {17, 18, 19, 20}
                };

                int rotation = 2;

                int[,] rotated = RotateMatrix(matrix, rotation);
                for (int i = 0; i < rotated.GetLength(0); i++)
                {
                    for (int j = 0; j < rotated.GetLength(1); j++)
                    {
                        Console.Write(rotated[i, j] + " ");
                    }
                    Console.WriteLine();
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

        private static int[,] RotateMatrix(int[,] matrix, int rotation)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int i_start = 0;
            int j_start = 0;
            int i_end = n - 1;
            int j_end = m - 1;

            while (i_start < n/2 && j_start < m/2)
            {
                List<int> tempQueue = new List<int>();

                for (int i = i_start; i < i_end; i++)
                {
                    tempQueue.Add(matrix[i, j_start]);
                }

                for (int i = j_start; i < j_end; i++)
                {
                    tempQueue.Add(matrix[i_end, i]);
                }

                for (int i = i_end; i > i_start; i--)
                {
                    tempQueue.Add(matrix[i, j_end]);
                }

                for (int i = j_end; i > j_start; i--)
                {
                    tempQueue.Add(matrix[i_start, i]);
                }

                int offset = rotation%tempQueue.Count;
                Queue<int> shiftedQueue = new Queue<int>(tempQueue.Count);

                for (int i = tempQueue.Count - offset; i < tempQueue.Count; i++)
                {
                    shiftedQueue.Enqueue(tempQueue[i]);
                }

                for (int i = 0; i < tempQueue.Count - offset; i++)
                {
                    shiftedQueue.Enqueue(tempQueue[i]);
                }


                for (int i = i_start; i < i_end; i++)
                {
                    matrix[i, j_start] = shiftedQueue.Dequeue();
                }

                for (int i = j_start; i < j_end; i++)
                {
                    matrix[i_end, i] = shiftedQueue.Dequeue();
                }

                for (int i = i_end; i > i_start; i--)
                {
                    matrix[i, j_end] = shiftedQueue.Dequeue();
                }

                for (int i = j_end; i > j_start; i--)
                {
                    matrix[i_start, i] = shiftedQueue.Dequeue();
                }

                i_start++;
                j_start++;
                i_end--;
                j_end--;
            }

            return matrix;
        }

        internal static bool InvokeScriptFile(string scriptFilePath, IDictionary<string, object> parameters)
        {
            RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();

            using (Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration))
            {
                runspace.Open();
                PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();
                outputCollection.DataAdded += OutputDataAdded;

                string script = File.ReadAllText(scriptFilePath);

                PowerShell ps = CreatePowerShell(runspace, script, parameters, isScript: true, checkExitCode: false);
                ps.InvocationStateChanged += new EventHandler<PSInvocationStateChangedEventArgs>(
                InvocationStateChanged);

                ps.Invoke(null, outputCollection);

                PowerShell powershell = PowerShell.Create();

                powershell.Runspace = runspace;
                powershell.Commands.AddCommand(new Command(CheckLastExitCode, true, false));
                Collection<PSObject> result = powershell.Invoke();
            }

            return false;
        }

        private static void InvocationStateChanged(object sender, PSInvocationStateChangedEventArgs e)
        {
            StringBuilder logData = new StringBuilder();
            logData.AppendFormat(
                "PowerShell object state changed: state: [{0}] Reason: [{1}]",
                 e.InvocationStateInfo.State,
                 e.InvocationStateInfo.Reason);

            if ((e.InvocationStateInfo.State == PSInvocationState.Completed) ||
                (e.InvocationStateInfo.State == PSInvocationState.Failed))
            {
            }
        }

        private static PowerShell CreatePowerShell(
            Runspace runspace,
            string script,
            IDictionary<string, object> parameters,
            bool isScript,
            bool checkExitCode)
        {
            PowerShell powershell = PowerShell.Create();

            powershell.Runspace = runspace;

            Command command = new Command(script, isScript);
            StringBuilder parameterInfo = new StringBuilder();

            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    command.Parameters.Add(key, parameters[key]);

                    parameterInfo.Append(key);
                    parameterInfo.Append("='");
                    parameterInfo.Append(parameters[key].ToString());
                    parameterInfo.Append("';");
                }
            }

            // Rewrite "write-host" cmdlet so we can get messages in the pipeline.
            powershell.Commands.AddCommand(new Command("function write-host($out) { write-verbose $out }", true));
            powershell.Commands.AddCommand(command);

            if (checkExitCode)
            {
                powershell.Commands.AddCommand(new Command(CheckLastExitCode, true));
            }

            if (parameterInfo.Length > 0)
            {
               Console.WriteLine("Specified script parameters: {0}", parameterInfo);
            }

            return powershell;
        }

        internal static List<CommandParameter> GetScriptParameters(string parameters, string roleInstallRootPath)
        {
            List<CommandParameter> result = new List<CommandParameter>();

            if (string.IsNullOrEmpty(parameters))
            {
                return result;
            }

            string[] parametersList = parameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string parameter in parametersList)
            {
                string[] parameterWithValue = parameter.Split('=');

                // Handle switches
                if (parameterWithValue.Length == 1)
                {
                    CommandParameter commandParameter = new CommandParameter(parameterWithValue[0], true);
                    result.Add(commandParameter);
                }
                else if (parameterWithValue.Length == 2)
                {
                    string value = parameterWithValue[1];

                    // Build full path if needed
                    if (value.IndexOf(
                        RoleInstallRootPathKeyword,
                        StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        value = Path.Combine(
                            roleInstallRootPath,
                            Path.GetFileName(value));
                    }

                    CommandParameter commandParameter = new CommandParameter(parameterWithValue[0], value);
                    result.Add(commandParameter);
                }
            }

            return result;
        }

        /// <summary>
        /// Event handler for when data is added to the output stream.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private static void OutputDataAdded(object sender, DataAddedEventArgs e)
        {
            PSObject record = ((PSDataCollection<PSObject>)sender)[e.Index];
            messages.Add("OUTPUT: " + record.ToString());
        }


        /// <summary>
        /// Event handler for DataAdded event on Error Stream.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private static void ErrorDataAdded(object sender, DataAddedEventArgs e)
        {
            ErrorRecord record = ((PSDataCollection<ErrorRecord>)sender)[e.Index];
            messages.Add("ERROR: " + record.ToString());
        }

        /// <summary>
        /// Event handler for DataAdded event on Error Stream.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private static void WarningDataAdded(object sender, DataAddedEventArgs e)
        {
            WarningRecord record = ((PSDataCollection<WarningRecord>)sender)[e.Index];
            messages.Add("WARNING: " + record.Message);
        }

        /// <summary>
        /// Event handler for DataAdded event on Verbose Stream.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private static void VerboseDataAdded(object sender, DataAddedEventArgs e)
        {
            VerboseRecord record = ((PSDataCollection<VerboseRecord>)sender)[e.Index];
            messages.Add("VERBOSE: " + record.Message);

        }

        /// <summary>
        /// Event handler for DataAdded event on Progress Stream.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private static void ProgressDataAdded(object sender, DataAddedEventArgs e)
        {
            ProgressRecord record = ((PSDataCollection<ProgressRecord>)sender)[e.Index];
            messages.Add("PROGRESS: " + record.ToString());
        }
    }
}
