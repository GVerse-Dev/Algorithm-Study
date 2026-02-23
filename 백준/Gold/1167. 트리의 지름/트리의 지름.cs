using System.Diagnostics.CodeAnalysis;
using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static (int node, ulong cost) BFS(List<(int node, ulong cost)>[] edgeList, int start)
    {
        ulong[] board = new ulong[edgeList.Length + 1];
        bool[] visited = new bool[edgeList.Length + 1];
        Queue<(int node, ulong cost)> queue = new Queue<(int node, ulong cost)>();
        queue.Enqueue((start, 0));
        visited[start] = true;

        while (queue.Count > 0)
        {
            (int node, ulong cost) current = queue.Dequeue();

            for (int i = 0; i < edgeList[current.node].Count; i++)
            {
                (int node, ulong cost) next = edgeList[current.node][i];

                if (visited[next.node])
                    continue;

                board[next.node] = current.cost + next.cost;

                visited[next.node] = true;
                queue.Enqueue((next.node, board[next.node]));
            }
        }

        (int node, ulong cost) result = (start, 0);
        for (int i = 1; i < board.Length; i++)
        {
            if (result.cost < board[i])
            {
                result.cost = board[i];
                result.node = i;
            }
        }

        return result;

    }

    static void Main()
    {
        int inputV = int.Parse(Console.ReadLine());

        List<(int node, ulong cost)>[] edgeList = new List<(int node, ulong cost)>[inputV + 1];

        for(int i =0; i<edgeList.Length; ++i)
        {
            edgeList[i] = new List<(int node, ulong cost)>();
        }

        for (int i = 0; i < inputV; i++)
        {
            string[] inputEdges = Console.ReadLine().Split(" ");

            int start = int.Parse(inputEdges[0]);
            for (int j = 1; j < inputEdges.Length; j+=2)
            {
                if (inputEdges[j] == "-1")
                    break;

                int node = int.Parse(inputEdges[j]);
                ulong cost = ulong.Parse(inputEdges[j+1]);

                edgeList[start].Add((node, cost));
            }
        }

        (int node, ulong dist) longestNode = BFS(edgeList, 1);
        (int node, ulong dist) result = BFS(edgeList, longestNode.node);


        Console.WriteLine(result.dist.ToString());
    }
}
