using System;
using System.Collections.Generic;

public class Test
{
    public static void Main(string[] args)
    {
        int numberOfTests = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= numberOfTests; i++)
        {
            string[] weights = Console.ReadLine().Split(' ');
            int totalWeight = Convert.ToInt32(weights[1]) - Convert.ToInt32(weights[0]);
            int numberOfCoins = Convert.ToInt32(Console.ReadLine());

            int[] wt = new int[numberOfCoins];
            int[] val = new int[numberOfCoins];

            for (int j = 0; j < numberOfCoins; j++)
            {
                string str = Console.ReadLine();
                val[j] = int.Parse(str.Split(' ')[0]);
                wt[j] = int.Parse(str.Split(' ')[1]);
            }

            int minAmount = GetMinimumAmount(totalWeight, val, wt);

            if (minAmount == Int32.MaxValue)
            {
                Console.WriteLine("This is impossible.");
            }
            else
            {
                Console.WriteLine("The minimum amount of money in the piggy-bank is {0}.", minAmount);
            }
        }
    }

    private static int GetMinimumAmount(int totalWeight, int[] val, int[] wt)
    {
        int[] weights = new int[totalWeight + 1];
        weights[0] = 0;

        for (int i = 1; i <= totalWeight; i++)
        {
            weights[i] = Int32.MaxValue;

            for (int j = 0; j < val.Length; j++)
            //foreach (int p in coinsPtoW.Keys)
            {
                int coinWeight = wt[j];
                int coinValue = val[j];

                if (i >= coinWeight)
                    if (weights[i - coinWeight] != int.MaxValue && weights[i - coinWeight] + coinValue < weights[i])
                        weights[i] = weights[i - coinWeight] + coinValue;
            }
        }






        //for (int i = 0; i < weights.Length; i++)
        //{
        //    weights[i] = maxValue;
        //}

        //foreach (int p in coinsPtoW.Keys)
        //{
        //    int coinWeight = coinsPtoW[p];
        //    if (weights.Length >= coinWeight && weights[coinWeight] > p)
        //    {
        //        weights[coinWeight] = p;

        //        for (int i = 1; i <= totalWeight; i++)
        //        {
        //            weights[i] = Math.Min(weights[i], weights[coinWeight] + weights[i - coinWeight]);
        //        }
        //    }
        //}

        return weights[totalWeight];
    }
}