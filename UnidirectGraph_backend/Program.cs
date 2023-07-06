using System;
using System.Collections.Generic;

public class Graph
{
    private int V; // Number of vertices
    private List<char>[] adj; // Adjacency list

    public Graph(int v)
    {
        V = v;
        adj = new List<char>[V];
        for (int i = 0; i < V; i++)
            adj[i] = new List<char>();
    }

    public void AddEdge(char source, char dest)
    {
        adj[source - 65].Add(dest);
        adj[dest - 65].Add(source);
    }

    public void PrintAllPaths(char source, char destination)
    {
        bool[] visited = new bool[V];
        List<char> path = new List<char>();
        path.Add(source);
        PrintAllPathsUtil(source, destination, visited, path);
    }

    private void PrintAllPathsUtil(int u, int d, bool[] visited, List<char> path)
    {
        visited[u - 65] = true;
        if (u == d)
        {
            Console.WriteLine("Path: " + string.Join(" -> ", path));
        }
        else
        {
            foreach (char i in adj[u - 65])
            {
                if (!visited[i - 65])
                {
                    path.Add(i);
                    PrintAllPathsUtil(i, d, visited, path);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
        visited[u - 65] = false;
    }

    public List<char> FindShortestPath(char source, char destination)
    {
        bool[] visited = new bool[V];
        char[] parent = new char[V];
        for (int i = 0; i < V; i++)
            parent[i] = '1';

        Queue<char> queue = new Queue<char>();
        visited[source - 65] = true;
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            char u = queue.Dequeue();

            if (u == destination)
                break;

            foreach (char v in adj[u - 65])
            {
                if (!visited[v - 65])
                {
                    visited[v - 65] = true;
                    parent[v - 65] = u;
                    queue.Enqueue(v);
                }
            }
        }

        return ReconstructPath(parent, source, destination);
    }

    private List<char> ReconstructPath(char[] parent, char source, char destination)
    {
        List<char> path = new List<char>();
        char current = destination;
        while (current != source)
        {
            path.Add(current);
            current = parent[current - 65];
        }
        path.Add(source);
        path.Reverse();
        return path;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int nodes = 8;
        Graph graph = new Graph(nodes);

        graph.AddEdge('A', 'B');
        graph.AddEdge('A', 'D');
        graph.AddEdge('A', 'H');
        graph.AddEdge('B', 'C');
        graph.AddEdge('B', 'D');
        graph.AddEdge('C', 'D');
        graph.AddEdge('C', 'F');
        graph.AddEdge('D', 'E');
        graph.AddEdge('E', 'F');
        graph.AddEdge('E', 'H');
        graph.AddEdge('H', 'G');
        graph.AddEdge('F', 'G');

        char source = 'A';
        char destination = 'H';

        Console.WriteLine("Question 1 Answer: All the possible paths paths between {0} and {1}:", source, destination);
        graph.PrintAllPaths(source, destination);



        Console.WriteLine("\nQuestion 2 Answer: Shortest path between {0} and {1}:", source, destination);
        List<char> shortestPath = graph.FindShortestPath(source, destination);
        Console.WriteLine(string.Join(" -> ", shortestPath));
    }
}
