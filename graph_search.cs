using System;
using System.Collections.Generic;

namespace c_sharp_test
{
    class GraphSearch
    {
        private static Dictionary<char, char[]> Graph = new Dictionary<char, char[]>();
        private static List<char> visited_dfs = new List<char>();
        private static List<char> visited_bfs = new List<char>();
        private static Queue<char> queue = new Queue<char>();
        private static string result_dfs = "Path in depth from vertex D: ";
        private static string result_bfs = "Path in width from vertex F: ";
        static void Main(string[] args)
        {
            Graph.Add('D', new char[] {'J', 'G', 'F'});
            Graph.Add('J', new char[] {'D'});
            Graph.Add('G', new char[] {'D', 'E', 'H'});
            Graph.Add('H', new char[] {'I', 'G'});
            Graph.Add('I', new char[] {'H'});
            Graph.Add('E', new char[] {'G'});
            Graph.Add('F', new char[] {'M', 'K', 'D'});
            Graph.Add('M', new char[] {'F'});
            Graph.Add('K', new char[] {'F'});

            dfs(Graph, 'D');
            for (int i = 0; i < visited_dfs.Count; i++)
            {
                result_dfs += i == 0 ? $"{visited_dfs[i]}" : $"-{visited_dfs[i]}";
            }

            bfs(Graph, 'F');
            for (int i = 0; i < visited_bfs.Count; i++)
            {
                result_bfs += i == 0 ? $"{visited_bfs[i]}" : $"-{visited_bfs[i]}";
            }

            Console.WriteLine(result_dfs);
            Console.WriteLine(result_bfs);
        }


        // Depth-first search
        static void dfs(Dictionary<char, char[]> graph, char node)
        {
            // if not visited
            if (!isVisited(node, visited_dfs))
            {
                visited_dfs.Add(node);
                // visiting other nodes
                foreach (char neighbor in Graph[node])
                {
                    dfs(Graph, neighbor);
                }
            }
        }

        // Breadth-first search
        static void bfs(Dictionary<char, char[]> graph, char node)
        {
            visited_bfs.Add(node);
            queue.Enqueue(node);

            // while queque not empty
            while (queue.Count != 0)
            {
                char s = queue.Dequeue();

                // for every branch
                foreach (char neighbor in Graph[s])
                {
                    if (!isVisited(neighbor, visited_bfs))
                    {
                        visited_bfs.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                    
                }
            }
        }

        // Check node visit status
        static bool isVisited(char node, List<char> visited)
        {
            foreach (var element in visited)
            {
                if (node == element)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
