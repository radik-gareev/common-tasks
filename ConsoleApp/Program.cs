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
        private static int combinationsCount;

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

            int height = 80;
            int count1 = GetNumberOfCombinations(height);
            Console.WriteLine("Total count #1: " + count1);

            int count2 = GetNumberOfCombinations_Improved(height);
            Console.WriteLine("Total count #2: " + count2);
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int GetNumberOfCombinations(int height)
        {
            if (height >= 10)
            {
                GetNumberOfCombinations(height, 10, 0, string.Empty);
            }

            return combinations.Count * 2;
        }

        public static int GetNumberOfCombinations_Improved(int height)
        {
            if (height >= 10)
            {
                GetNumberOfCombinations_Improved_Recursive(height);
            }

            return combinationsCount*2;
        }

        private static void GetNumberOfCombinations(int height, int previousHeight, byte previousOrientation, string combination)
        {
            combination += previousOrientation + " ";
            if (previousHeight > height)
            {
                return;
            }

            if (previousHeight == height)
            {
                combinations.Add(combination);
            }
            else
            {
                GetNumberOfCombinations(height, previousHeight + 1, previousOrientation, combination);
                GetNumberOfCombinations(height, previousHeight + 10, (byte)(previousOrientation ^ 1), combination);
            }
        }

        private static void GetNumberOfCombinations_Improved_Recursive(int height)
        {
            if (height == 0)
            {
                combinationsCount++;
                return;
            }

            // wrong combination
            if (height < 10)
            {
                return;
            }

            GetNumberOfCombinations_Improved_Recursive(height - 1);
            GetNumberOfCombinations_Improved_Recursive(height - 10);
        }
    }
}
