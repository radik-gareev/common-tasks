using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Helpers
{
    public static class Print
    {
        public static void LinkedList(LinkedList node)
        {
            string result = string.Empty;
            while (node != null)
            {
                result += "->" + node.Value;
                node = node.Next;
            }

            Console.WriteLine(result.Substring(2));
        }

        public static void Array<T>(T[] arr)
        {
            foreach (T t in arr)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }
}
