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
        int inputCase = int.Parse(Console.ReadLine());

        for (int cnt = 0; cnt < inputCase; cnt++)
        {
            string[] inputNK = Console.ReadLine().Split(" ");
            int n = int.Parse(inputNK[0]);
            int k = int.Parse(inputNK[1]);

            string[] inputBuildTime = Console.ReadLine().Split(" ");
            int[] buildTime = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                buildTime[i] = int.Parse(inputBuildTime[i - 1]);
            }

            List<int>[] graph = new List<int>[n + 1];
            int[] inDegree = new int[n + 1];
            int[] dp = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < k; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                int start = int.Parse(input[0]);
                int end = int.Parse(input[1]);
                inDegree[end]++;
                graph[start].Add(end);
            }

            int lastBuildNumber = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();
            for (int i = 1; i <= n; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);
                    dp[i] = buildTime[i];
                }
            }

            while (queue.Count > 0)
            {
                int currentBuildNumber = queue.Dequeue();
                
                for (int i = 0; i < graph[currentBuildNumber].Count; i++)
                {
                    inDegree[graph[currentBuildNumber][i]]--;

                    if (inDegree[graph[currentBuildNumber][i]] == 0)
                    {
                        queue.Enqueue(graph[currentBuildNumber][i]);
                    }

                    //다음 건설이 가능한것들의 최대 시간
                    dp[graph[currentBuildNumber][i]] = Math.Max(dp[graph[currentBuildNumber][i]], dp[currentBuildNumber] + buildTime[graph[currentBuildNumber][i]]);
                }
            }

            sb.AppendLine(dp[lastBuildNumber].ToString());
        }

        Console.WriteLine(sb.ToString());
        
    }

 
}
