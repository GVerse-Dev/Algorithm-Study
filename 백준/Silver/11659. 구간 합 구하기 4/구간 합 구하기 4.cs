using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static void DP()
    {
        
    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        input = Console.ReadLine().Split(' ');

        int[] intArr = new int[n + 1];
        int[] sumArr = new int[n + 1];
        sumArr[0] = 0;

        for(int i = 0; i < n; i++)
        {
            intArr[i + 1] = int.Parse(input[i]);
            sumArr[i + 1] = sumArr[i] + intArr[i + 1];
        }

        for (int i = 0; i < m; i++)
        {
            string[] idx = Console.ReadLine().Split(' ');
            int mi = int.Parse(idx[0]);
            int mj = int.Parse(idx[1]);

            sb.Append(sumArr[mj] - sumArr[mi - 1] + "\n");

        }

        Console.WriteLine(sb.ToString());
    }
}

