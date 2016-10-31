using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Find number of inversion in an array using merge sort.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = new[] { 2, 1, 0 };
            Console.WriteLine(string.Join(", ", arr));
            int inversionsCount = MergeSort(arr, 0, arr.Length - 1);
            Console.WriteLine(inversionsCount);
            Console.WriteLine(string.Join(", ", arr));
            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static int MergeSort(int[] arr, int start, int end)
        {
            int inversionsCount = 0;
            if (start < end)
            {
                int mid = (end + start) / 2;
                inversionsCount = MergeSort(arr, start, mid);
                inversionsCount += MergeSort(arr, mid + 1, end);

                inversionsCount += DoMerge(arr, start, end, mid + 1);
            }

            return inversionsCount;
        }

        private static int DoMerge(int[] arr, int start, int end, int mid)
        {
            int i, j, k;
            int inversionsCount = 0;
            int[] temp = new int[25];

            i = start;
            j = mid;
            k = start;

            while ((i <= mid - 1) && (j <= end))
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                    inversionsCount = inversionsCount + (mid - i);
                }
            }

            while (i <= mid - 1)
                temp[k++] = arr[i++];
            while (j <= end)
                temp[k++] = arr[j++];

            for (i = start; i <= end; i++)
                arr[i] = temp[i];

            return inversionsCount;
        }
    }
}
