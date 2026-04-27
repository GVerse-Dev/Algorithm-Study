using System;

public class Solution {
    public long solution(int a, int b, int[] g, int[] s, int[] w, int[] t)
 {
     long answer = -1;

     long timeMax = 1000000000000000;
     long timeMin = 0;

     while (timeMin < timeMax) 
     {
         long timeMid = timeMin + ((timeMax - timeMin) / 2);

         long totalLoad = 0;
         long totalGoldLoad = 0;
         long totalSilverLoad = 0;

         for (int i = 0; i < g.Length; i++)
         {
             //운반 횟수
             long carryCount = (timeMid + t[i]) / (2 * t[i]);

             //운반가능한 최대 무게
             long maxLoad = Math.Min(g[i] + s[i], carryCount * w[i]);
             long goldLoad = Math.Min(g[i], carryCount * w[i]);
             long silverLoad = Math.Min(s[i], carryCount * w[i]);

             totalLoad += maxLoad;
             totalGoldLoad += goldLoad;
             totalSilverLoad += silverLoad;
         }

         bool condition1 = (a + b) <= totalLoad;
         bool condition2 = a <= totalGoldLoad;
         bool condition3 = b <= totalSilverLoad;

         if (condition1 && condition2 && condition3)
         {
             timeMax = timeMid;
         }
         else
         {
             timeMin = timeMid + 1;
         }

     }

     answer = timeMin;

     Console.WriteLine(answer.ToString());

     return answer;
 }
}