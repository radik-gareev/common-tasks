using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Helpers
{
    public static class Generator
    {
        public static LinkedList LinkedListFromArray(int[] arr)
        {
            if (arr == null)
                return null;
            LinkedList head = new LinkedList(arr[0]);
            LinkedList current = head;
            for (int i = 1; i < arr.Length; i++)
            {
                current.Next = new LinkedList(arr[i]);
                current = current.Next;
            }

            return head;
        }
    }
}
