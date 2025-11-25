using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;


class Solution
{

    public int solution(int[,] maps)
{
    int answer = -1;

    List<List<int>> mapList = new List<List<int>>();
    List<List<bool>> visited = new List<List<bool>>();

    for (int i =0; i< maps.GetLength(0); i++)
    {
        for(int j = 0; j<maps.GetLength(1); j++)
        {
            if(mapList.Count <= i)
            {
                mapList.Add(new List<int>());
                visited.Add(new List<bool>());
            }
            mapList[i].Add(maps[i, j]);
            visited[i].Add(false);
        }
    }

    Queue<(int[], int)> list = new Queue<(int[], int)> ();

    list.Enqueue((new int[] { 0, 0 }, 0));

    List<int> dxd = new List<int> { 0, 1, 0, -1 };
    List<int> dyd = new List<int> { -1, 0, 1, 0 };

    while (list.Count > 0) 
    {
       
       
        var pos = list.Dequeue();
        int y = pos.Item1[0];
        int x = pos.Item1[1];
        int level = pos.Item2;

        int nyCount = mapList.Count();
        int nxCount = mapList[y].Count();

        if (visited[y][x])
            continue;

        visited[y][x] = true;


        if (mapList[y][x] == 0)
            continue;

        if (y == nyCount - 1 && x == nxCount - 1) 
        {
            return level + 1;
        }

        for (int j = 0; j < 4; ++j)
        {
            int nx = x + dxd[j];
            int ny = y + dyd[j];

            if (nx >= 0 && nx < nxCount && ny >= 0 && ny < nyCount)
            {
                if (mapList[ny][nx] == 1)
                {
                    list.Enqueue((new int[] { ny, nx }, level + 1));
                }
            }
        }
    }


    return answer;
}
}