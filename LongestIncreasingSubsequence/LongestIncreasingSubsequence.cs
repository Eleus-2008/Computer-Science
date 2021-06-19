using System.Linq;

namespace LongestIncreasingSubsequence
{
    public static class LongestIncreasingSubsequence
    {
        public static int FindLisLength(int[] array)
        {
            var lisLengths = new int[array.Length];

            for (var i = 0; i < array.Length; i++)
            {
                lisLengths[i] = 1;
                for (var j = 0; j < i; j++)
                {
                    if (array[i] % array[j] == 0 && lisLengths[j] + 1 > lisLengths[i])
                    {
                        lisLengths[i] = lisLengths[j] + 1;
                    }
                }
            }

            return lisLengths.Max();
        }
    }
}