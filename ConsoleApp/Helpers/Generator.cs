﻿using System;
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
            //      5
            //    /   \
            //    3    7
            //   / \  / \
            //  1   4 6  8
            // / \        \
            // 0  2        9
            Tree root = new Tree(5);
            Tree left1 = new Tree(3);
            left1.Parent = root;
            root.Left = left1;
            Tree right1 = new Tree(7);
            right1.Parent = root;
            root.Right = right1;

            Tree left2 = new Tree(1);
            left2.Parent = left1;
            left1.Left = left2;
            Tree right2 = new Tree(4);
            right2.Parent = left1;
            left1.Right = right2;

            Tree left3 = new Tree(0);
            left3.Parent = left2;
            left2.Left = left3;
            Tree right3 = new Tree(2);
            right3.Parent = left2;
            left2.Right = right3;

            Tree left22 = new Tree(6);
            left22.Parent = right1;
            right1.Left = left22;
            Tree right22 = new Tree(8);
            right22.Parent = right1;
            right1.Right = right22;

            Tree right32 = new Tree(9);
            right32.Parent = right22;
            right22.Right = right32;

            return root;
        }
    }
}
