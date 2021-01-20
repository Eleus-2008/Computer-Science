using System;
using System.Collections;
using System.Collections.Generic;

namespace DijkstrasAlgorithm
{
    class Program
    {
        public static IEnumerable<string> FindShortestPath(Dictionary<string, Dictionary<string, int>> graph, string start, string finish)
        {
            var costs = new Dictionary<string, int>();
            var parents = new Dictionary<string, string>();
            var processed = new List<string>();
            foreach (var key in graph.Keys)
            {
                if (key == start)
                {
                    costs.Add(key, 0);
                }
                else
                {
                    costs.Add(key, int.MaxValue);
                }
                parents.Add(key, null);
            }

            var node = FindLowestCostNode();
            while (node != null)
            {
                foreach (var neighbour in graph[node])
                {
                    var newCost = costs[node] + neighbour.Value;
                    if (newCost < costs[neighbour.Key])
                    {
                        costs[neighbour.Key] = newCost;
                        parents[neighbour.Key] = node;
                    }
                }
                processed.Add(node);
                node = FindLowestCostNode();
            }
            
            var path = new List<string>();
            path.Add(finish);
            node = parents[finish];
            while (node != null)
            {
                path.Add(node);
                node = parents[node];
            }
            path.Reverse();
            return path;

            string FindLowestCostNode()
            {
                var lowestCost = int.MaxValue;
                string lowestCostNode = null;
                foreach (var node in costs)
                {
                    if (node.Value < lowestCost && !processed.Contains(node.Key))
                    {
                        lowestCost = node.Value;
                        lowestCostNode = node.Key;
                    }
                }

                return lowestCostNode;
            }
        }
        static void Main(string[] args)
        {
            var graph = new Dictionary<string, Dictionary<string, int>>
            {
                ["a"] = new Dictionary<string, int>{{"aa",8},{"bb",3},{"cc",3}},
                ["aa"] = new Dictionary<string, int>{{"bbb",6}},
                ["bb"] = new Dictionary<string, int>{{"aa", 1}},
                ["cc"] = new Dictionary<string, int>{{"bb",1},{"ccc",7}},
                ["bbb"] = new Dictionary<string, int>{{"q",5},{"ccc",7},{"fffff",9}},
                ["ccc"] = new Dictionary<string, int>{{"fffff",10}},
                ["q"] = new Dictionary<string, int>{},
                ["fffff"] = new Dictionary<string, int>{}
            };
            var path = FindShortestPath(graph, "a", "fffff");
            foreach (var node in path)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("##############");
            path = FindShortestPath(graph, "a", "q");
            foreach (var node in path)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("##############");
            path = FindShortestPath(graph, "cc", "fffff");
            foreach (var node in path)
            {
                Console.WriteLine(node);
            }
        }
    }
}