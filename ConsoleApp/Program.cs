using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    public class Program
    {
        private static List<string> combinations = new List<string>();
        private static Dictionary<int, uint> heights = new Dictionary<int, uint>();

        /// <summary>
        /// You have cups of height 10. You can put it one upon another and get tower of length 20 or 11 depending on cup orientation. 
        /// Find the number of possible combinations of building tower of length X using cups. 
        /// Two combinations are equal if Nth cup is oriented equally in both combinations for each N meaning count of cup from bottom
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //if (_towerHeight >= 10)
            //{
            //    GetNumberOfCombinations(10, 0, string.Empty);
            //    GetNumberOfCombinations_Improved(_towerHeight);
            //}

            //bool isUnique = combinations.Distinct().Count() == combinations.Count();
            //for (int i = 0; i < combinations.Count; i++)
            //{
            //    //Console.WriteLine(i + 1 + ": " + combinations[i]);
            //}

            int height = 800;
            //int count1 = GetNumberOfCombinations(height);
            //Console.WriteLine("Total count #1: " + count1);

            uint count2 = GetNumberOfCombinations_Improved(height);
            Console.WriteLine("Total count #2: " + count2);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetNumberOfCombinations(int towerHeight)
        {
            if (towerHeight >= 10)
            {
                GetNumberOfCombinations(towerHeight, 10, 0, string.Empty);
            }

            return combinations.Count * 2;
        }

        public static uint GetNumberOfCombinations_Improved(int height)
        {
            uint count = 0;
            if (height >= 10)
            {
                count = GetNumberOfCombinations_Improved_Recursive(height);
            }

            return count * 2;
        }

        private static void GetNumberOfCombinations(int towerHeight, int previousHeight, byte previousOrientation, string combination)
        {
            combination += previousOrientation + " ";
            if (previousHeight > towerHeight)
            {
                return;
            }

            if (previousHeight == towerHeight)
            {
                combinations.Add(combination);
            }
            else
            {
                GetNumberOfCombinations(towerHeight, previousHeight + 1, previousOrientation, combination);
                GetNumberOfCombinations(towerHeight, previousHeight + 10, (byte)(previousOrientation ^ 1), combination);
            }
        }

        private static uint GetNumberOfCombinations_Improved_Recursive(int height)
        {
            if (height == 0)
            {
                return 1;
            }

            // wrong combination
            if (height < 10)
            {
                return 0;
            }

            if (heights.ContainsKey(height))
                return heights[height];

            uint count = GetNumberOfCombinations_Improved_Recursive(height - 1);
            count += GetNumberOfCombinations_Improved_Recursive(height - 10);

            heights.Add(height, count);
            return count;
        }
    }
}
