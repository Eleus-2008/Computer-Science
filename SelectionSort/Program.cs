using System;
using System.Collections.Generic;

namespace SelectionSort
{
    class Program
    {
        public static int FindMinimal(IList<int> array)
        {
            var min = array[0];
            var minIndex = 0;
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public static List<int> SelectionSort(IList<int> list)
        {
            var newList = new List<int>(list.Count);
            var listLength = list.Count;
            for (int i = 0; i < listLength; i++)
            {
                var minIndex = FindMinimal(list);
                newList.Add(list[minIndex]);
                list.RemoveAt(minIndex);
            }

            return newList;
        }
        
        static void Main(string[] args)
        {
            var list = new List<int> {2, 0, -15, 43, 2525, 1, 4, -14, -1};
            foreach (var item in SelectionSort(list))
            {
                Console.Write(item + " ");   
            }

            Console.ReadLine();
        }
    }
}