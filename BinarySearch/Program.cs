using System;
using System.Collections;

namespace BinarySearch
{
    class Program
    {
        public static int BinarySearch<T>(T[] array, T item) where T : IComparable
        {
            var low = 0;
            var high = array.Length - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;
                var guess = array[mid];

                var compared = guess.CompareTo(item);
                if (compared == 0)
                {
                    return mid;
                }
                if (compared > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
        static void Main(string[] args)
        {
            int[] intArray = new[] {1, 3, 5, 10, 150, 160, 170};
            
            Console.WriteLine(BinarySearch(intArray, 160)); // 5
            Console.WriteLine(BinarySearch(intArray, 16)); // -1
            Console.ReadLine();

            string[] stringArray = new[] {"aaa", "aab", "bbb", "bbc", "ccc"};

            Console.WriteLine(BinarySearch(stringArray, "aab")); // 1
            Console.WriteLine(BinarySearch(stringArray, "ddd")); // -1
            Console.ReadLine();
        }
    }
}