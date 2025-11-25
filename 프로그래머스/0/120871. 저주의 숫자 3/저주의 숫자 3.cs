using System;

public class Solution {
    public int solution(int n)
  {

      int answer = 0;

      for (int i = 0; i < n; ++i)
      {
          answer++;
          answer = Check(answer);
      }
      Console.WriteLine(answer);
      return answer;
  }

  public int Check(int answer)
  {
      if (answer.ToString().Contains('3'))
      {
          return Check(++answer);
      }

      if (answer % 3 == 0)
      {
          return Check(++answer);
      }

      return answer;
  }
}