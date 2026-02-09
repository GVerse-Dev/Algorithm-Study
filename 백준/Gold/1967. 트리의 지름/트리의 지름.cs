using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static int idx = 0;
    static int result = 0;
    static void DFS(List<(int linkNode, int edgeWeight)>[] edges, bool[] visited, int node, int dist)
    {
        if (visited[node])
            return;


        visited[node] = true;

        if (dist > result)
        {
            idx = node;
            result = dist;
        }

        if (edges[node] == null)
            return;


        for (int i = 0; i < edges[node].Count; i++) 
        {
            DFS(edges, visited,  edges[node][i].linkNode, dist + edges[node][i].edgeWeight);
        }
        
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<(int linkNode, int edgeWeight)>[] edges = new List<(int linkNode, int edgeWeight)>[n + 1];
       
        for (int i = 0; i < n - 1; i++)
        {
            string[] inpuEdge = Console.ReadLine().Split(" ");
            int parentNode = int.Parse(inpuEdge[0]);
            int childNode = int.Parse(inpuEdge[1]);
            int edgeWeight = int.Parse(inpuEdge[2]);

            if (edges[parentNode] == null)
                edges[parentNode] = new List<(int linkNode, int edgeWeight)>();

            edges[parentNode].Add((childNode, edgeWeight));

            if (edges[childNode] == null)
                edges[childNode] = new List<(int linkNode, int edgeWeight)>();

            edges[childNode].Add((parentNode, edgeWeight));
        }

        bool[] visited = new bool[n + 1];
        DFS(edges, visited, 1, 0);
        visited = new bool[n + 1];
        DFS(edges, visited, idx, 0);



        Console.WriteLine(result.ToString());
    }
}
