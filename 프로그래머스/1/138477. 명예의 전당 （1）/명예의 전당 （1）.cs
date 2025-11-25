using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Collections.Generic;
public class Solution {
    public int[] solution(int k, int[] score)
{
    int[] answer = new int[score.Length];
 
    List<int> result = new List<int>();


    for (int i = 0; i < score.Length; ++i)
    {
        result.Add(score[i]);
        result.Sort();

        if(result.Count > k)
        {
            result.RemoveAt(0);
        }
        
        answer[i] = result[0];
    }

    return answer;
}
}