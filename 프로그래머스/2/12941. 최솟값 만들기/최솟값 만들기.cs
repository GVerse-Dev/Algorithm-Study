using System;

public class Solution {
    public int solution(int[] A, int[] B) {
        int answer = 0;

       Array.Sort(A);
  Array.Sort(B);

  for (int i = 0; i < A.Length; ++i)
  {
      answer += (A[i] * B[B.Length - 1 - i]);
  }

       return answer;
        }
}