using System;

public class Solution {
     public int[] solution(int n)
 {
     int[] answer = new int[(n * (1 + n)) / 2];
     int[,] ints = new int[n, n];

     int[] dx = new int[] { 0, 1, -1 };
     int[] dy = new int[] { 1, 0, -1 };

     int dir = 0;

     int curX = 0;
     int curY = 0;

     for (int i = 0; i< n; ++i)
     {
         for(int j = 0; j< n; ++j)
         {
             ints[i,j] = 0;
         }
     }

     for (int i = 1; i <= (n * (1 +n))/2; ++i)
     {
         ints[curY , curX] = i;

         if (curX + dx[dir % 3] >= n || curY + dy[dir % 3] >= n)
             dir++;
         else if (ints[curY + dy[dir % 3], curX + dx[dir % 3]] != 0)
             dir++;

         curX += dx[dir % 3];
         curY += dy[dir % 3];
     }

     int index = 0;
     for(int i = 0; i< ints.GetLength(0); ++i) 
     {
         for(int j = 0; j < ints.GetLength(1); ++j)
         {
             if (ints[i, j] == 0)
                 continue;

             answer[index] = ints[i, j];

             index++;
         }
     }

    

     return answer;
 }
}