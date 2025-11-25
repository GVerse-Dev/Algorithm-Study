using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;


public class Solution {
    public int solution(string[,] clothes) {
        int answer = 1;
        
        Dictionary<string, HashSet<string>> test = new Dictionary<string, HashSet<string>>();

         for (int i = 0; i < clothes.GetLength(0); i++)
         {
             if (test.ContainsKey(clothes[i,1]) == false)
             {
                 test[clothes[i, 1]] = new HashSet<string> { clothes[i, 0] };
             }
             else
             {
                 test[clothes[i, 1]].Add(clothes[i, 0]);
             }

         }

      foreach (var wear in test)
     {
         answer *= wear.Value.Count + 1;
     }
       

         return answer -1 ;
        }
}