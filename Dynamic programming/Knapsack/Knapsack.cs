using System;
using System.Linq;

namespace Knapsack
{
    public static class Knapsack
    {
        public static int FindMaxWeight(int maxWeight, int[] weights)
        {
            var array = new int[weights.Length + 1, maxWeight + 1];
            for (var i = 1; i < array.GetLength(0); i++)
            {
                for (var w = 1; w < array.GetLength(1); w++)
                {
                    array[i, w] = array[i - 1, w];
                    if (weights[i - 1] <= w)
                    {
                        array[i, w] = Math.Max(array[i, w], array[i - 1, w - weights[i - 1]] + weights[i - 1]);
                    }
                }
            }

            return array[weights.Length, maxWeight];
        }
    }
}