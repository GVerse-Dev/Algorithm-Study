using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
     public int solution(int[] priorities, int location)
 {
     int answer = 0;

     Queue<int> queueP = new Queue<int>();
     Queue<int> queueI = new Queue<int>();

     
     for (int i = 0; i < priorities.Length; ++i)
     {
         queueP.Enqueue(i);
     }

     for(int i =0; i< priorities.Length; ++i)
     {
         queueI.Enqueue(priorities[i]);
     }

     while (queueP.Count > 0)
     {
         int highPriority = queueI.Max(q => q);

         int currentPriority = queueI.Dequeue();
         int value = queueP.Dequeue();
         if (highPriority <= currentPriority)
         {
             answer++;

             if (value == location)
                 break;
         }
         else
         {
             queueI.Enqueue(currentPriority);
             queueP.Enqueue(value);
         }
     }

     return answer;
 }
}