using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

class BOJ
{

    static StringBuilder sb = new StringBuilder();

    static void DFS(int n, int m, int[] ints, bool[] visited, int[] result, int cnt)
    {
        if (cnt >= m)
        {
            for (int i = 0; i < result.Length; ++i)
            {
                sb.Append(result[i] +  " ");
            }
            sb.AppendLine();
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if (visited[i])
                continue;

            visited[i] = true;
            result[cnt] = ints[i];
            cnt++;

            //다음 인덱스로 이동
            DFS(n, m, ints, visited, result, cnt);

            visited[i] = false;
            cnt--;
        }
    }

   

    static void Main()
    {
        string[] inputNM = Console.ReadLine().Split(' ');

        int n = int.Parse(inputNM[0]);
        int m = int.Parse(inputNM[1]);

        string[] input = Console.ReadLine().Split(' ');

        int[] ints = new int[n];
        bool[] visited = new bool[n];
        int[] result = new int[m];

        for (int i = 0; i < n; i++)
        {
            ints[i] = int.Parse(input[i]);
        }

        Array.Sort(ints);

        DFS(n, m, ints, visited, result, 0);

        Console.WriteLine(sb.ToString());
    }
}
