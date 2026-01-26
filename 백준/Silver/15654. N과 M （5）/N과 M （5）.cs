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

    static void DFS(int n, int m, int[] ints, int idx, HashSet<int> temp)
    {
        if (temp.Count >= m)
        {
            foreach (int i in temp)
            {
                sb.Append(i +  " ");
            }
            sb.AppendLine();
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if (temp.Contains(ints[i]))
                continue;

            HashSet<int> next = new HashSet<int>();
            foreach (int j in temp)
            {
                next.Add(j);
            }
            next.Add(ints[i]);
            //다음 인덱스로 이동
            DFS(n, m, ints, idx, next);
        }
    }

   

    static void Main()
    {
        string[] inputNM = Console.ReadLine().Split(' ');

        int n = int.Parse(inputNM[0]);
        int m = int.Parse(inputNM[1]);

        string[] input = Console.ReadLine().Split(' ');

        int[] ints = new int[n];

        for (int i = 0; i < n; i++)
        {
            ints[i] = int.Parse(input[i]);
        }

        Array.Sort(ints);

        DFS(n, m, ints, 0, new HashSet<int>());

        Console.WriteLine(sb.ToString());
    }
}
