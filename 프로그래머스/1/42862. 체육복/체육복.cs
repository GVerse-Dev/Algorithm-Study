using System;
using System.Linq;
using System.Collections.Generic;
public class Solution {
   public int solution(int n, int[] lost, int[] reserve)
 {
     int answer = 0;

     answer += n - lost.Length;

     var lostList = new SortedList<int,int>();
     var reserveList = new SortedList<int,int>();

     foreach (int item in lost)
     {
         if (reserve.Contains(item) == false)
         {
             lostList.Add(item, item);
         }
         else
         {
             answer++;
         }

     }

     foreach (int item2 in reserve)
     {
         if (lost.Contains(item2) == false)
         {
             reserveList.Add(item2,item2);
         }
     }


     foreach (var item in lostList) 
     {
         foreach (var item2 in reserveList) 
         {
             if ((item.Key == item2.Key + 1) || item.Key == item2.Key - 1) 
             {
                 reserveList.Remove(item2.Key);
                 answer++;
                 break;
             }
         }
     }

     Console.WriteLine(answer);

     return answer;
 }
}