using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
public class Solution {
    public int solution(int[] numbers, int target)
{
    int answer = 0;

    Queue<(int sum, int level)> queue = new Queue<(int sum, int level)>();


    queue.Enqueue((numbers[0], 0));
    queue.Enqueue((numbers[0] * -1, 0));

    while (queue.Count > 0) 
    {
        var item = queue.Dequeue();

        if (item.level == numbers.Length - 1) 
        {
            if(item.sum == target)
            {
                answer++;
            }
        }


        if (item.level + 1 < numbers.Length) 
        {
            queue.Enqueue((item.sum + numbers[item.level + 1], item.level + 1));
            queue.Enqueue((item.sum - numbers[item.level + 1], item.level + 1));
        }
    }
  

    return answer;
}
}