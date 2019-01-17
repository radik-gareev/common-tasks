using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Helpers
{
    public static class Generator
    {
        private static readonly Random random = new Random();

        public static LinkedList LinkedListFromArray(int[] arr)
        {
            if (arr == null)
            {
                return null;
            }

            LinkedList head = new LinkedList(arr[0]);
            LinkedList current = head;
            for (int i = 1; i < arr.Length; i++)
            {
                current.Next = new LinkedList(arr[i]);
                current = current.Next;
            }

            return head;
        }

        public static int[] ArrayWithRandomLength(int minLength = 10, int maxLength = 50, int minValue = 0, int maxValue = 5000)
        {
            int[] arr = new int[random.Next(minLength, maxLength)];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(minValue, maxValue);
            }

            return arr;
        }

        public static int[] ArrayFixedLength(int length, int minValue = 0, int maxValue = 5000)
        {
            return ArrayWithRandomLength(length, length, minValue, maxValue);
        }

        public static string[] StringArray(int minLength = 10, int maxLength = 50, string[] possibleCharacters = null)
        {
            if (possibleCharacters == null)
            {
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                possibleCharacters = (alphabet + alphabet.ToLower()).ToCharArray().Select(c => c.ToString()).ToArray();
            }

            string[] arr = new string[random.Next(minLength, maxLength)];
            for (int i = 0; i < arr.Length; i++)
            {
                int randomIndex = random.Next(0, possibleCharacters.Length);
                arr[i] = possibleCharacters[randomIndex];
            }

            return arr;
        }

        public static string[] StringArrayFixedLength(int length, string[] possibleCharacters = null)
        {
            return StringArray(length, length, possibleCharacters);
        }

        public static string StringRandomLength(int minLength = 10, int maxLength = 50, string[] possibleCharacters = null)
        {
            string[] s = StringArray(minLength, maxLength, possibleCharacters);
            return string.Join("", s);
        }

        public static Graph SampleGraph()
        {
            // 0-4
            // 3-5-1
            //    \/
            //    2
            return new Graph(new List<int>[]
            {
                new List<int>() {4}, // successors of vertice 0
                new List<int>() {2, 5}, // successors of vertice 1
                new List<int>() {1, 5}, // successors of vertice 2
                new List<int>() {5}, // successors of vertice 3
                new List<int>() {0, 5}, // successors of vertice 4
                new List<int>() {1, 2, 3} // successors of vertice 5
            });
        }

        public static Tree SampleTree()
        {
            Tree tree = new Tree(5,
                new Tree(3,
                    new Tree(1,
                        new Tree(0), new Tree(2)),
                    new Tree(4)),
                new Tree(7,
                    new Tree(6),
                    new Tree(8, null,
                        new Tree(9))));

            return tree;
        }
    }
}
