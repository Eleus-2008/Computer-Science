using System;
using System.Collections.Generic;
using System.Linq;

namespace BreadthFirstSearch
{
    class Program
    {
        public static string BreadthFirstSearch(Dictionary<string, string[]> dict, string first)
        {
            var searchQueue = new Queue<string>();
            var searched = new List<string>();
            
            foreach (var item in dict[first])
            {
                searchQueue.Enqueue(item);
            }

            while (searchQueue.Any())
            {
                var s = searchQueue.Dequeue();
                if (!searched.Contains(s))
                {
                    if (s.Length == 5)
                    {
                        return s;
                    }
                    else
                    {
                        searched.Add(s);
                        foreach (var item in dict[s])
                        {
                            searchQueue.Enqueue(item);
                        }
                    }
                }
            }

            return null;
        }
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string[]>
            {
                ["a"] = new string[]{"aa","bb","cc"},
                ["aa"] = new string[]{"bbb","ccc"},
                ["bb"] = new string[]{},
                ["cc"] = new string[]{"q","w","e"},
                ["bbb"] = new string[]{"fffff"},
                ["ccc"] = new string[]{},
                ["q"] = new string[]{},
                ["w"] = new string[]{},
                ["e"] = new string[]{},
                ["fffff"] = new string[]{}
            };
            Console.WriteLine(BreadthFirstSearch(dict, "a"));
        }
    }
}