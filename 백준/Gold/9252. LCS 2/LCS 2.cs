using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();


    static void Main()
    {

        string a = Console.ReadLine();
        string b = Console.ReadLine();

        int[,] dp = new int[b.Length + 1, a.Length + 1];

        for (int i = 1; i < dp.GetLength(0); i++)
        {
            for (int j = 1; j < dp.GetLength(1); j++)
            {
                if (a[j - 1] == b[i - 1])
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j- 1]);
            }
        }

        List<char> list = new List<char>();

        int idxi = dp.GetLength(0) - 1;
        int idxj = dp.GetLength(1) - 1;

        while (idxi > 0 && idxj > 0)
        {
            if (a[idxj - 1] == b[idxi - 1])
            {
                list.Add(a[idxj - 1]);
                idxi--;
                idxj--;
            }
            else
            {
                if (dp[idxi - 1, idxj] > dp[idxi, idxj - 1])
                    idxi--;
                else
                    idxj--;
            }
        }

        list.Reverse();

        foreach(char c in list)
            sb.Append(c);

        Console.WriteLine(dp[dp.GetLength(0)-1, dp.GetLength(1)-1].ToString());
        Console.WriteLine(sb.ToString());
    }
}