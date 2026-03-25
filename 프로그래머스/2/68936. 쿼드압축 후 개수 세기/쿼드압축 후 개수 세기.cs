using System;

public class Solution 
{
    int[] answer = new int[] {0 ,0};
    
     public bool Check(int[,] arr, int startY, int startX, int size)
     {
         int target = arr[startY, startX];
         for (int y = startY; y < startY + size; ++y)
         {
             for (int x = startX; x < startX + size; ++x)
             {
                 if(arr[y,x] != target)
                     return false;
             }
         }

         return true;
     }

 public void Find(int[,] arr, int startY, int startX,  int size)
 {
     if (Check(arr, startY, startX, size))
     {
         answer[arr[startY, startX]]++;
     }
     else
     {
         int newSize = size / 2;
         Find(arr, startY, startX, newSize);
         Find(arr, startY, startX + newSize, newSize);
         Find(arr, startY + newSize, startX, newSize);
         Find(arr, startY + newSize, startX + newSize, newSize);
     }
 }
    
    public int[] solution(int[,] arr) {
        
        Find(arr,0,0,arr.GetLength(0));
        
        return answer;
    }
}