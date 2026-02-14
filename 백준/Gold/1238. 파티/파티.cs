using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static void Main()
    {
        string[] inputNMX = Console.ReadLine().Split(" ");

        int n = int.Parse(inputNMX[0]);
        int m = int.Parse(inputNMX[1]);
        int x = int.Parse(inputNMX[2]);

        //N = 1000
        //플로이드 와샬 알고리즘은 O(N^3) = 1000 * 1000 * 1000 = 10억 
        //다익스트라 알고리즘은 ?


        //간선 정보
        List<(int end, int cost)>[] frontGraph = new List<(int end, int cost)>[n + 1];
        List<(int end, int cost)>[] backGraph = new List<(int end, int cost)>[n + 1];

        //특정노드에서 가장 저렴한 비용을 꺼내기 위한용도
        PriorityQueue<(int end, int cost), int> pq = new PriorityQueue<(int end, int cost), int>();

        //A노드에서 X노드까지의 비용 저장
        int[] dpAtoX = new int[n + 1];
        //X노드에서 A노드까지의 비용 저장
        int[] dpXtoA = new int[n + 1];

        for (int i = 0; i < n + 1; i++)
        {
            frontGraph[i] = new List<(int end, int cost)>();
            backGraph[i] = new List<(int end, int cost)>();
        }

        for (int i = 0; i < n + 1; i++)
        {
            dpAtoX[i] = int.MaxValue;
            dpXtoA[i] = int.MaxValue;
        }
        dpAtoX[x] = 0;
        dpXtoA[x] = 0;

        for (int i = 0; i < m; i++)
        {
            string[] inputEdge = Console.ReadLine().Split(" ");

            int start = int.Parse(inputEdge[0]);
            int end = int.Parse(inputEdge[1]);
            int cost = int.Parse(inputEdge[2]);

            frontGraph[start].Add((end, cost));
            backGraph[end].Add((start, cost));
        }


        //간선 방향을 반대로 뒤집은 후 X(도착노드를 시작지점으로 잡음) -> 모든지점 다익스트라 알고리즘 실행
        //그럼 X 에서 시작한 모든 비용이 나오는데 방향만 달라졌을뿐 비용이 같으니 모든지점 -> X 까지의 최소비용과 동일하다.
        pq.Enqueue((x, 0), 0);
        while (pq.Count > 0)
        {
            (int end, int cost) edge = pq.Dequeue();

            if (dpAtoX[edge.end] < edge.cost)
                continue;

            int b = edge.end;

            //X에서 B를 거쳐 C로 가는
            for (int i = 0; i < backGraph[edge.end].Count; i++)
            {
                int c = backGraph[edge.end][i].end;
                int newCost = backGraph[edge.end][i].cost + edge.cost;

                if (dpAtoX[c] < newCost)
                    continue;

                //c 노드에서 연결된 노드들을 찾기위해 c 를 pq에 넣어준다.
                dpAtoX[c] = newCost;
                pq.Enqueue((c, newCost), newCost);
            }
        }

        //정방향으로 X에서부터 모든지점으로 돌아가는 길에 대해 알고리즘 실행
        pq.Enqueue((x, 0), 0);
        while (pq.Count > 0)
        {
            (int end, int cost) edge = pq.Dequeue();

            if (dpXtoA[edge.end] < edge.cost)
                continue;

            int b = edge.end;

            for (int i = 0; i < frontGraph[edge.end].Count; i++)
            {
                int c = frontGraph[edge.end][i].end;
                int newCost = frontGraph[edge.end][i].cost + edge.cost;

                if (dpXtoA[c] < newCost)
                    continue;

                dpXtoA[c] = newCost;
                pq.Enqueue((c, newCost), newCost);
            }
        }



        int result = 0;

        for (int i = 1; i <= n; i++)
        {
            if (dpAtoX[i] + dpXtoA[i] > result)
                result = dpAtoX[i] + dpXtoA[i];
        }


        Console.WriteLine(result.ToString());
    }
}
