using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class BOJ
{
    static void DFS(List<int>[] graph, bool[] visited, int node)
    {
        if (visited[node])
            return; 

        visited[node] = true;

        for (int i = 0; i < graph[node].Count; i++)
        {
            DFS(graph, visited, graph[node][i]);
        } 
        
    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        string[] inputNM = Console.ReadLine().Split(' ');

        int n = int.Parse(inputNM[0]);
        int m = int.Parse(inputNM[1]);

        List<int>[] graph = new List<int>[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < m; i++)
        {
            string[] nodes = Console.ReadLine().Split(' ');
            int node1 = int.Parse(nodes[0]) - 1;
            int node2 = int.Parse(nodes[1]) - 1;

            if (graph[node1] == null)
            {
                graph[node1] = new List<int>();
            }
            if (graph[node2] == null)
            {
                graph[node2] = new List<int>();
            }

            graph[node1].Add(node2);
            graph[node2].Add(node1);

        }

        int count = 0;
        for (int y = 0; y < n; y++)
        {
            if (graph.Length < y || graph[y] == null)
            {
                count++;
                continue;
            }


            for (int  x = 0; x < graph[y].Count; x++)
            {
                int node = graph[y][x];

                if (visited[node] == false)
                {
                    DFS(graph, visited, node);
                    count++;
                }
            }
        }

        sb.AppendLine(count.ToString()); 

        Console.WriteLine(sb.ToString());
    }
}
