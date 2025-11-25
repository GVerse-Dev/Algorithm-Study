using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;


public class Solution {
    public int[] solution(int[] progresses, int[] speeds)
{
    int[] answer = new int[] { };

    int next = 0;
    int complete = 0;
    List<int> list = new List<int>();

    while (next < progresses.Length)
    {
        for (int i = 0; i < progresses.Length; i++)
        {
            progresses[i] += speeds[i];
        }

        for (int i = next; i < progresses.Length; i++)
        {
            if (progresses[i] < 100)
                break;
            if (progresses[i] >= 100)
            {
                complete++;
                next = i + 1;
            }
        }

        if(complete > 0)
        {
            list.Add(complete);
            complete = 0;
        }

        if (list.Sum(i => i) >= progresses.Length)
            break;
    }

   answer = list.ToArray();

    foreach (int i in answer)
    {
        Console.WriteLine(i);
    }

    return answer;
}
}