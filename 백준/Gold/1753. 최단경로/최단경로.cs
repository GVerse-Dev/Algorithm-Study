using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();


    static void Main()
    {
        string[] inputVE = Console.ReadLine().Split(" ");
        int v = int.Parse(inputVE[0]);
        int e = int.Parse(inputVE[1]);
        int start = int.Parse(Console.ReadLine());

        List<(int linkNode, int linkWeight)>[] graph = new List<(int linkNode, int linkWeight)>[v + 1];
        int[] weights = new int[v + 1];

        //O(v)
        for (int i = 0; i < v + 1; ++i)
        {
            graph[i] = new List<(int linkNode, int linkWeight)>();

            if(i == start)
                weights[i] = 0;
            else
                weights[i] = 200000;
        }

        //O(e)
        //단방향 그래프 구성
        for (int i = 0; i < e; i++)
        {
            string str = Console.ReadLine();
            string[] inputUVW = str.Split(" ");

            int inputU = int.Parse(inputUVW[0]);
            int inputV = int.Parse(inputUVW[1]);
            int inputW = int.Parse(inputUVW[2]);

            graph[inputU].Add((inputV, inputW));
        }

        //다익스트라 알고리즘

        //최소 힙구조를 이용하여 효율적으로 연결된 노드들 중에서 가장 비용이 적은 노드를 꺼낸다.
        PriorityQueue<(int node, int w), int> priorityQueue = new PriorityQueue<(int node, int w), int>();
        priorityQueue.Enqueue((start, 0), 0);

        while (priorityQueue.Count > 0)
        {
            //현재까지 알수있는 연결된 노드들 중에서 가장 비용이 적은 노드
            (int current, int currentWeight) = priorityQueue.Dequeue();

            //start 노드에서 current 노드까지 이미 더 적은 비용의 경로를 발견했다면 스킵
            if (currentWeight > weights[current])
                continue;

            //현재 노드에서 연결된 노드들
            for (int i = 0; i < graph[current].Count; ++i)
            {
                int linkNode = graph[current][i].linkNode;
                int linkWeight = graph[current][i].linkWeight;
                if (weights[linkNode] > weights[current] + linkWeight)
                {
                    weights[linkNode] = weights[current] + linkWeight;

                    priorityQueue.Enqueue((linkNode, weights[linkNode]), weights[linkNode]);
                }

            }
        }


        for (int i = 1; i < weights.Length; ++i)
        {
            if (weights[i] >= 200000)
                sb.AppendLine("INF");
            else
                sb.AppendLine(weights[i].ToString());
        }


        Console.WriteLine(sb.ToString());
    }
}
