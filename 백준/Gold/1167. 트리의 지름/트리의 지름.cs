using System.Diagnostics.CodeAnalysis;
using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static (int node, ulong dist) Dijkstra(List<(int node, ulong cost)>[] edgeList, int start)
    {
        ulong[] board = new ulong[edgeList.Length];

        for (int i = 0; i < board.Length; ++i)
        {
            board[i] = ulong.MaxValue;
        }
        board[start] = 0;

        PriorityQueue<(int node, ulong cost), ulong> priorityQueue = new PriorityQueue<(int node, ulong cost), ulong>();
        priorityQueue.Enqueue((start, 0), 0);

        while (priorityQueue.Count > 0)
        {
            var current = priorityQueue.Dequeue();
            int currentNode = current.node;
            ulong currentCost = current.cost;

            //현재 방문한 노드의 비용이 이미 더 적다면
            //여기서부터 다음노드까지의 비용은 최소가 아니기 때문에 볼 필요가 없음
            if (board[currentNode] < currentCost)
            {
                continue;
            }

            foreach (var (next, nextCost) in edgeList[currentNode])
            {
                ulong newCost = currentCost + nextCost;

                if (board[next] > newCost)
                {
                    board[next] = newCost;
                    priorityQueue.Enqueue((next, newCost), newCost);
                }

            }
        }

        (int node, ulong dist) longestNode = (start,0);
        for(int i = 1; i< board.Length; ++i)
        {
            if (longestNode.dist < board[i])
            {
                longestNode.node = i;
                longestNode.dist = board[i];
            }
        }

        return longestNode; 
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

        (int node, ulong dist) longestNode = Dijkstra(edgeList, 1);
        (int node, ulong dist) result = Dijkstra(edgeList, longestNode.node);


        Console.WriteLine(result.dist.ToString());
    }
}
