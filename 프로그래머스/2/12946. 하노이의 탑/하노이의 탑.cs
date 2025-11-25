using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Collections.Generic;

public class Solution {
  public int[,] solution(int n)
{
    int[,] answer = new int[,] { { } };

    List<int[]> answer2 = new List<int[]>();

    Hanoi(n, 1, 3, 2, answer2);

    answer = new int[answer2.Count, 2];

    for (int i = 0; i < answer2.Count; ++i)
    {
        answer[i, 0] = answer2[i][0];
        answer[i, 1] = answer2[i][1];

    }

    return answer;
}

void Hanoi(int n, int from, int to, int via, List<int[]> answer)
{
   if(n == 1)
    {
         answer.Add(new int[] { from, to });
        return;
    }

    Hanoi(n - 1, from, via, to, answer);

    answer.Add(new int[] { from, to });

    Hanoi(n - 1, via, to, from, answer);
}
}