using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();


    static void FloydWarshall(int[,] graph)
    {
        //경유지점
        for (int j = 1; j < graph.GetLength(0); j++)
        {
            //시작지점
            for (int i = 1; i < graph.GetLength(0); i++)
            {
                if (i == j)
                    continue;

                if (graph[i, j] == 0)
                    continue;

                //도착지점
                for (int k = 1; k < graph.GetLength(0); k++)
                {
                    if (j == k || i == k)
                        continue;

                    if (graph[j, k] == 0)
                        continue;

                    if (graph[i, k] == 0)
                        graph[i, k] = graph[i, j] + graph[j, k];
                    else if (graph[i, j] + graph[j, k] < graph[i, k])
                        graph[i, k] = graph[i, j] + graph[j, k];
                }
            }
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        
        int[,] graph = new int[n + 1, n + 1];

        for (int i = 0; i < m; i++)
        {
            string[] input = Console.ReadLine().Split(" ");

            int start = int.Parse(input[0]);
            int end = int.Parse(input[1]);
            int cost = int.Parse(input[2]);

            if (graph[start, end] > 0)
            {
                graph[start, end] = Math.Min(cost, graph[start, end]);
            }
            else
            {
                graph[start, end] = cost;
            }
        }


        FloydWarshall(graph);

      

        for (int i = 1; i <= n; ++i)
        {
            for (int j = 1; j <= n; ++j)
                sb.Append(graph[i, j] + " ");

            sb.AppendLine();
        }



        Console.WriteLine(sb.ToString());
    }
}
