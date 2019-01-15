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
        /// 4.2 Given a directed graph, design an algorithm to find out whether there is a route
        /// between two nodes.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Graph graph = Generator.SampleGraph();
            bool wayExist = DoesRouteExist(graph, 3, 4);

            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static bool DoesRouteExist(Graph graph, int start, int end)
        {
            Stack<int> q = new Stack<int>();
            q.Push(start);
            bool[] visited = new bool[graph.Size + 1];
            visited[start] = true;

            while (q.Count > 0)
            {
                int node = q.Pop();
                foreach(int n in graph.GetSuccessors(node))
                {
                    if (n == end)
                    {
                        return true;
                    }

                    if (!visited[n])
                    {
                        visited[n] = true;
                        q.Push(n);
                    }
                }
            }

            return false;
        }
    }
}
