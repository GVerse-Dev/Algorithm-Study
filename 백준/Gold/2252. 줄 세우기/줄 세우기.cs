using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.Arm;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static void Main()
    {
        string[] inputNM = Console.ReadLine().Split(" ");
        int n = int.Parse(inputNM[0]);
        int m = int.Parse(inputNM[1]);

        List<int>[] graph = new List<int>[n + 1];
        int[] edges = new int[n + 1];

        for (int i = 0; i <= n; ++i)
        {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < m; ++i)
        {
            string[] input = Console.ReadLine().Split(" ");
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);

            graph[a].Add(b);
            edges[b]++;
        }

        Queue<int> queue = new Queue<int>();

        for (int i = 1; i <= n; i++)
        {
            if (edges[i] == 0)
                queue.Enqueue(i);
        }

        while (queue.Count > 0)
        {
            int cur = queue.Dequeue();

            sb.Append(cur + " ");

            for (int i = 0; i < graph[cur].Count; ++i)
            {
                edges[graph[cur][i]]--;

                if (edges[graph[cur][i]] == 0)
                    queue.Enqueue(graph[cur][i]);
            }
        }
       

        Console.WriteLine(sb.ToString());
        
    }

 
}
