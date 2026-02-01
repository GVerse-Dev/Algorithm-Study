using System;
using System.Collections.Generic;
public class Solution {
     public int BFS(int[,] wires, List<int>[] list, int v1, int v2)
 {
     Queue<int> queue = new Queue<int>();
     bool[] visited = new bool[list.Length + 1];
     int result = 0;

     queue.Enqueue(v1);

     while (queue.Count > 0)
     {
         int node = queue.Dequeue();

         foreach (int linkNode in list[node])
         {
             if(visited[linkNode]) 
                 continue;

             if (node == v1 && linkNode == v2)
                 continue;
             if (node == v2 && linkNode == v1)
                 continue;


             visited[linkNode] = true;
             result++;
             queue.Enqueue(linkNode);
         }
     }

     return result;
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
             int linkCount = BFS(wires, list, i, list[i][j]);

             int result = Math.Abs(linkCount - (n - linkCount));

             if(answer >  result) answer = result;
         }
         
     }

     return answer;
 }
}