using System;

public class Solution {
     public int[] solution(int brown, int yellow)
  {
       /*
  * 반례 (18, 6)
  * 24  = 6, 4 를 찾으면 반환
  * 하지만, 실제 답은 8,3 이어야함 
  */

 int[] answer = new int[] { 0, 0 };

 int max = brown > yellow ? brown : yellow;
 int sum = brown + yellow;

 for (int x = 3; x <= max; ++x)
 {
     for (int y = 3; y <= x; ++y)
     {
         if (x * y == sum && (((x - 2) * (y - 2)) == yellow))
         {
             answer[0] = x;
             answer[1] = y;

             return answer;
         }
     }
 }

 return answer;
  }
}