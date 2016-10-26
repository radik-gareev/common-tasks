using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DirectedGraph
    {
        private LinkedList<int>[] nodes;
        private int NumberOfNodes;

        public DirectedGraph(int numberOfNodes)
        {
            nodes = new LinkedList<int>[numberOfNodes];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new LinkedList<int>();
            }

            NumberOfNodes = numberOfNodes;
        }

        public void AddEdge(int from, int to)
        {
            nodes[from].AddLast(to);
        }

        public string BreadthFirstSearch(int startNode)
        {
            string result = "";
            bool[] isNodeVisited = new bool[NumberOfNodes];
            isNodeVisited[startNode] = true;

            LinkedList<int> queue = new LinkedList<int>();
            queue.AddLast(startNode);

            while (queue.Any())
            {
                startNode = queue.First();
                result += startNode + " ";
                queue.RemoveFirst();

                LinkedList<int> list = nodes[startNode];

                foreach (var val in list)
                {
                    if (!isNodeVisited[val])
                    {
                        isNodeVisited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }

            return result;
        }

        public string DepthFirstSearch(int startNode)
        {
            string result = "";
            Stack<int> stack = new Stack<int>();
            bool[] isNodeVisited = new bool[NumberOfNodes];
            isNodeVisited[startNode] = true;
            stack.Push(startNode);

            while (stack.Any())
            {
                startNode = stack.Pop();
                result += startNode + " ";

                LinkedList<int> list = nodes[startNode];

                foreach (var val in list)
                {
                    if (!isNodeVisited[val])
                    {
                        isNodeVisited[val] = true;
                        stack.Push(val);
                    }
                }
            }

            return result;
        }
    }

    public class Program
    {
        /// <summary>
        /// Traverse a directed graph.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DirectedGraph graph = new DirectedGraph(6);
            graph.AddEdge(0,1);
            graph.AddEdge(1,0);
            graph.AddEdge(0,4);
            graph.AddEdge(4,2);
            graph.AddEdge(2,3);
            graph.AddEdge(1,5);
            graph.AddEdge(5,3);
            graph.AddEdge(5,4);
            string bfs = graph.BreadthFirstSearch(0);
            string dfs = graph.DepthFirstSearch(0);

            // should be: 0 1 5 4 2 3

            Console.WriteLine("BFS: " + bfs);
            Console.WriteLine("DFS: " + dfs);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static void Method()
        {
            
        }
    }
}
