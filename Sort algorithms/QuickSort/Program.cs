using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickSort
{
    class Program
    {
        public static List<int> QuickSort(List<int> list)
        {
            if (list.Count < 2)
            {
                return list;
            }
            else
            {
                var pivot = list[0];
                list.Remove(pivot);
                var less = list.Where(x => x <= pivot).ToList();
                var greater = list.Where(x => x > pivot).ToList();
                var resultList = QuickSort(less).Append(pivot).Concat(QuickSort(greater)).ToList();
                return resultList;
            }
        }
        static void Main(string[] args)
        {
            var list = new List<int>{5,5,0,13,4,-4,-252,43,34,6,7,23,-13,-14};
            foreach (var item in QuickSort(list))
            {
                Console.Write(item + " ");   
            }
        }
    }
}