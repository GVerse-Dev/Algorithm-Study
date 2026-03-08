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
    static int[] parent;
    static int Find(int x)
    {
        int result = x;
        if (parent[x] != x)
        {
            result = Find(parent[x]);
            parent[x] = result;     //경로 압축
        }
            

        return result;
    }

    static void Union(int x1, int x2)
    {
        int a = Find(x1);
        int b = Find(x2);

        if (a != b)
        {
            parent[b] = a;
        }
    }

    static void Main()
    {
        string[] inputVE = Console.ReadLine().Split(" ");

        int v = int.Parse(inputVE[0]);
        int e = int.Parse(inputVE[1]);

        parent = new int[v + 1];
        for (int i = 0; i <= v; i++)
        {
            parent[i] = i;
        }

        List<(int a, int b, int c)> edges = new List<(int a, int b, int c)>();
        for (int i = 0; i < e; i++)
        {
            string[] inputABC = Console.ReadLine().Split(" ");
            int a = int.Parse(inputABC[0]);
            int b = int.Parse(inputABC[1]);
            int c = int.Parse(inputABC[2]);

            edges.Add((a, b, c));
        }

        edges = edges.OrderBy(o=>o.c).ToList();

        long result = 0;

        for (int i = 0; i < edges.Count; i++)
        {
            //가중치 순으로 들어갔는데 이미 같은 그룹이면 의미없다
            if (Find(edges[i].a) == Find(edges[i].b))
                continue;

            //같은 그룹으로 묶어주자
            Union(edges[i].a, edges[i].b);
            result += edges[i].c;
        }

        Console.WriteLine(result.ToString());
        
    }

 
}
