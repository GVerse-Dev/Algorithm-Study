using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

public class Solution {
    List<bool> visit = new List<bool>();
int result = 0;
public int solution(int n, int[,] computers)
{
    int answer = 0;
    for (int i = 0; i < n; i++)
    {
        visit.Add(false);
    }

    for(int i =0; i < n; ++i)
    {
        if (visit[i])
            continue;

        Console.WriteLine($"go into {i}");
        result++;
        DFS(i, computers);
    }
        

    answer = result;
    Console.WriteLine("-----" + answer);
    return answer;
}

public void DFS(int current, int[,] computers)
{
    if (visit[current]) 
    {
        return;
    }

    for (int i = 0; i < computers.GetLength(1); ++i)
    {
        if (visit[i])
        {
            continue;
        }

        if (computers[current, i] == 0)
        {
            continue;
        }

        visit[current] = true;

        Console.WriteLine($"visit {i}");
        DFS(i, computers);

    }

}
}