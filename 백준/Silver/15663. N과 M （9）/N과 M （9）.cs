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
    static List<int[]> result = new List<int[]>();
    static int n = 0;
    static int m = 0;
    static int[] ints;
    static bool[] visited;

    static void DFS(int[] temp, int cnt)
    {
        if (cnt >= m)
        {
            int[] intsArr = new int[m];
            
            for(int i = 0; i < cnt; i++)
                intsArr[i] = temp[i];

            result.Add(intsArr);
            
            return;
        }

        int before = 0;

        for (int i = 0; i < ints.Length; i++)
        {
            if (visited[i])
                continue;

            if (ints[i] == before)
                continue;

            before = ints[i];
            temp[cnt] = ints[i];
            visited[i] = true;
            DFS(temp,cnt + 1);
            visited[i] = false;
        }

    }

    static void Main()
    {
        string[] inputNM = Console.ReadLine().Split(" ");

        n = int.Parse(inputNM[0]);
        m = int.Parse(inputNM[1]);

        string[] inputInts = Console.ReadLine().Split(" ");

        ints = new int[n];
        for(int i =0; i < n; ++i) 
        {
            ints[i] = int.Parse(inputInts[i]);
        }
        visited = new bool[n];

        Array.Sort(ints);

        int[] temp = new int[m];

        DFS(temp, 0);


        for (int i = 0; i < result.Count; ++i)
        {
            foreach (var item in result[i])
            {
                sb.Append(item + " ");
            }
            sb.AppendLine();
        }



        Console.WriteLine(sb.ToString());
    }
}
