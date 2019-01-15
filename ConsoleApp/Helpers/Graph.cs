using System.Collections.Generic;

namespace ConsoleApp.Helpers
{
    public class Graph
    {
        private readonly List<int>[] childNodes;

        public Graph(int size)
        {
            this.childNodes = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                this.childNodes[i] = new List<int>();
            }
        }

        public Graph(List<int>[] childNodes)
        {
            this.childNodes = childNodes;
        }

        public int Size => this.childNodes.Length;

        public void AddEdge(int u, int v)
        {
            childNodes[u].Add(v);
        }

        public void RemoveEdge(int u, int v)
        {

            childNodes[u].Remove(v);
        }

        public bool HasEdge(int u, int v)
        {
            bool hasEdge = childNodes[u].Contains(v);

            return hasEdge;
        }

        public IList<int> GetSuccessors(int v)
        {
            return childNodes[v];
        }
    }
}
