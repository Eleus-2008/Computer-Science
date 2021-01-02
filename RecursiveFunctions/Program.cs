using System;
using System.Collections.Generic;

namespace RecursiveFunctions
{
    class Program
    {
        public static int Sum(List<int> list)
        {
            if (list.Count == 0)
            {
                return 0;
            }
            else
            {
                var x = list[0];
                list.RemoveAt(0);
                return x + Sum(list);
            }
        }
        static void Main(string[] args)
        {
            var list = new List<int>{1,2,3,4,5,6,7,8,9,-10}; //35
            Console.WriteLine(Sum(list));
        }
    }
}