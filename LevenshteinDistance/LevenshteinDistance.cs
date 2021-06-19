using System.Linq;

namespace LevenshteinDistance
{
    public static class LevenshteinDistance
    {
        public static int FindLevenshteinDistance(string word1, string word2)
        {
            var array = new int[word1.Length + 1, word2.Length + 1];
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if (i == 0)
                        array[i, j] = j;
                    else if (j == 0)
                        array[i, j] = i;
                    else
                        array[i, j] = int.MaxValue;
                }
            }

            return EditDistance(array.GetLength(0) - 1, array.GetLength(1) - 1);

            int EditDistance(int i, int j)
            {
                if (array[i, j] == int.MaxValue)
                {
                    var insertion = EditDistance(i, j - 1) + 1;
                    var deletion = EditDistance(i - 1, j) + 1;
                    var substitution = EditDistance(i - 1, j - 1) + (word1[i - 1] == word2[j - 1] ? 0 : 1);
                    var operations = new[] {insertion, deletion, substitution};
                    array[i, j] = operations.Min();
                }

                return array[i, j]; 
            }
        }
    }
}