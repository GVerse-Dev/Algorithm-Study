using System;
using System.Collections.Generic;
public class Solution {
 public int DFS(int[,] wires, bool[] visited , List<int>[] list, int v1, int v2 ,int cur)
{
    int count = 0;

    if (visited[cur])
        return 0;

    visited[cur] = true;
    count++;


    for (int i = 0; i < list[cur].Count; i++)
    {
        if (cur == v1 && list[cur][i] == v2)
            continue;
        if (cur == v2 && list[cur][i] == v1)
            continue;

        count += DFS(wires, visited, list, v1, v2, list[cur][i]);
    }

    return count;

}



public int solution(int n, int[,] wires)
{
    int answer = n;

    List<int>[] list = new List<int>[n + 1];
    

    for (int i = 0; i <= n; i++)
    {
        list[i] = new List<int>();
    }

    for (int i = 0; i < wires.GetLength(0); ++i)
    {
        list[wires[i, 0]].Add(wires[i, 1]);
        list[wires[i, 1]].Add(wires[i, 0]);
    }

    //A에서
    for (int i = 1; i <= n; ++i)
    {
        //A랑 연결된 것들을 끊어본다.
        for (int j = 0; j < list[i].Count; ++j)
        {
            //list[j]랑 연결을 끊고 난 후 A랑 이어지는 노드의 개수를 찾는다.
            //int linkCount = BFS(wires, list, i, list[i][j]);
            bool[] visited = new bool[list.Length + 1];

            int linkCount = DFS(wires, visited, list, i, list[i][j], i);

            int result = Math.Abs(linkCount - (n - linkCount));

            if(answer >  result) answer = result;
        }
        
    }

    return answer;
}
}