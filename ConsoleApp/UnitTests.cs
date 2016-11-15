using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConsoleApp.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Comparison_GetNumberOfJumpCombinations()
        {
            List<Tuple<int[], int[]>> randomHeights = new List<Tuple<int[], int[]>>();
            int testCases = 1000;
            for (int i = 0; i < testCases; i++)
            {
                int[] randomArray = Generator.CreateRandomArrayWithRandomLength(50, 100);
                int[] randomJumps = Generator.CreateRandomArrayWithRandomLength(10, 50, 2, 10);
                randomHeights.Add(new Tuple<int[], int[]>(randomArray, randomJumps));
            }

            for (int i = 0; i < randomHeights.Count; i++)
            {
                int[] randomArray = randomHeights[i].Item1;
                int[] randomJumps = randomHeights[i].Item2;

                Debug.WriteLine("{0}. Testing with randomArray.Length={1} and randomJumps.Length={2}...", i + 1, randomArray.Length, randomJumps.Length);

                var stopwatch = Stopwatch.StartNew();
                int count = Program.GetNumberOfJumpsCombinations(randomArray, randomJumps);
                stopwatch.Stop();
                Debug.WriteLine("{0}. GetNumberOfJumpsCombinations_Improved finished in {1}ms, result={2}", i + 1, stopwatch.ElapsedMilliseconds, count);
            }
        }
    }
}
