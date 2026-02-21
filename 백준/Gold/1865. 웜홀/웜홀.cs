using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static bool BellmanFord(int[] cost, List<(int start, int end, int cost)> egdeList, int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < egdeList.Count; j++)
            {
                int s = egdeList[j].start;
                int e = egdeList[j].end;
                int t = egdeList[j].cost;

                if ((cost[s] + t) < cost[e])
                {
                    cost[e] = cost[s] + t;

                    if (i == n)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    static void Main()
    {
        int inputTC = int.Parse(Console.ReadLine());

        for (int tc = 0; tc < inputTC; tc++)
        {
            string[] inputNMW = Console.ReadLine().Split(" ");
            int n = int.Parse(inputNMW[0]);
            int m = int.Parse(inputNMW[1]);
            int w = int.Parse(inputNMW[2]);

            int[] cost = new int[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                cost[i] = 5000000;
            }
            
            List<(int start, int end, int cost)> egdeList = new List<(int start, int end, int cost)>();

            for (int i = 0; i < m; ++i)
            {
                string[] inputSET = Console.ReadLine().Split(" ");

                int s = int.Parse(inputSET[0]);
                int e = int.Parse(inputSET[1]);
                int t = int.Parse(inputSET[2]);

                egdeList.Add((s, e, t));
                egdeList.Add((e, s, t));
            }

            for (int i = 0; i < w; ++i)
            {
                string[] inputSET = Console.ReadLine().Split(" ");

                int s = int.Parse(inputSET[0]);
                int e = int.Parse(inputSET[1]);
                int t = int.Parse(inputSET[2]) * -1;

                egdeList.Add((s, e, t));
            }


            if (BellmanFord(cost, egdeList, n))
            {
                sb.AppendLine("YES");
            }
            else
            {
                sb.AppendLine("NO");
            }
        }


        Console.WriteLine(sb.ToString());
    }
}
