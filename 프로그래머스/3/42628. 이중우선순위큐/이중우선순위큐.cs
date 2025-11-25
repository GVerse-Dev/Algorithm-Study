using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;


public class Solution {
    public int[] solution(string[] operations) {
         int[] answer = new int[] { 0, 0};

 List<int> list = new List<int>();

 for(int i = 0; i<operations.Length; ++i)
 {
     string[] splitStr = operations[i].Split(" ");
     string oper = splitStr[0];
     int value = int.Parse(splitStr[1]);

     switch (oper) 
     {
         case "I":
             list.Add(value);
             break;
         case "D":
             if (value == 1)
            {
                if(list.Count > 0)
                    list.Remove(list.Max());
            }
            else if(value == -1) 
            {
                if (list.Count > 0)
                    list.Remove(list.Min());
            }
             break;
     }
 }

 if(list.Count() == 0)
 {
     answer[0] = 0;
     answer[1] = 0;
 }
 else
 {
     answer[0] = list.Max();
     answer[1] = list.Min();
 }
 
 Console.WriteLine($"{answer[0]},{answer[1]}");
 return answer;
    }
}


