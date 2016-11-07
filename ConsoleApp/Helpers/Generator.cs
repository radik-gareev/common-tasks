using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Helpers
{
    public static class Generator
    {
        private static readonly Random random = new Random();

        public static LinkedList CreateLinkedListFromArray(int[] arr)
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

        public static int[] CreateRandomArrayWithRandomLength(int minLength = 10, int maxLength = 50, int minValue = 0, int maxValue = 5000)
        {
            int[] arr = new int[random.Next(minLength, maxLength)];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(minValue, maxValue);
            }

            return arr;
        }

        public static int[] CreateRandomArray(int length, int minValue = 0, int maxValue = 5000)
        {
            int[] arr = new int[length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(minValue, maxValue);
            }

            return arr;
        }
    }
}
