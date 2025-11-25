using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Solution {
     public string solution(string number, int k)
 {
     Stack<char> stack = new Stack<char>();

     foreach (char digit in number)
     {
         // 현재 숫자가 스택 맨 위보다 크면, 작은 것들 제거
         while (stack.Count > 0 && k > 0 && stack.Peek() < digit)
         {
             stack.Pop();
             k--;
         }
         stack.Push(digit);
     }

     // 아직 k개 못 제거했으면 뒤에서 제거
     while (k > 0)
     {
         stack.Pop();
         k--;
     }

     var answer = new string(stack.ToArray().Reverse().ToArray());


     return answer;
 }
}