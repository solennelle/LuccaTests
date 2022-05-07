using System;
using System.Collections.Generic;
using LuccaDevises.Models;

namespace LuccaDevises
{
    static public class ShortestPath
    {
        static public int GetCurrencyExchange(Dictionary<string, Dictionary<string, decimal>> graph, Instructions instructions) {
            var queue = new Queue<string>();
            var visited = new HashSet<string>();
            var parents = new Dictionary<string, string>();

            queue.Enqueue(instructions.InitialCurrency);

            // start bfs, looping over children of the graph
            while (queue.Count > 0) {
                var node = queue.Dequeue();
                visited.Add(node);
                try {
                    foreach (var child in graph[node])
                    {
                        // if node hasn't been visited before, we add it to the queue
                        if (!visited.Contains(child.Key))  {
                            queue.Enqueue(child.Key);
                            parents.Add(child.Key, node);
                        }
                    }
                } catch (Exception ex){
                    Console.WriteLine(ex.Message);
                }
            }

            var current = instructions.GoalCurrency;
            var initial = instructions.InitialCurrency;
            var result = instructions.Amount;

            // current starts as the goal currency and we go back to the initial currency 
            // while converting the currency with each step
            while (current != initial) {
              var parent = parents[current];
              result *= graph[parent][current];
              current = parent;
            }

            return (int)Math.Ceiling(result);
        }
    }
}