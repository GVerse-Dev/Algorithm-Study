using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int solution(int N, int number)
{
    int answer = -1;

    // 기본 경우
    if (N == number) return 1;

    Dictionary<int, HashSet<int>> calNums = new Dictionary<int, HashSet<int>>();

    calNums[0] = new HashSet<int>();
    calNums[1] = new HashSet<int>();
    calNums[2] = new HashSet<int>();

    calNums[0].Add(0);
    calNums[1].Add(N);
    calNums[2].Add((N * 10) + N);
    calNums[2].Add(N*N);
    calNums[2].Add(N/N);
    calNums[2].Add(N-N);
    calNums[2].Add(N+N);
  
   for(int i = 1; i < 8; ++i)
   {
        for(int j = 1; j <= i; ++j)
        {
            if (i + j > 8)
                continue;

            //if (calNums.ContainsKey(i + j) == false || calNums[i + j] == null)
            //    calNums[i + j] = new HashSet<int>();

            HashSet<int> set = new HashSet<int>();

            foreach (var hashOne in calNums[i])
            {
                foreach (var hashTwo in calNums[j])
                {
                    float one = (float)hashOne;
                    float two = (float)hashTwo;

                    int d = 0;
                    for (int k = 0; k < i + j; k++)
                    {
                        d = d * 10 + N;
                    }

                    set.Add(d);
                    set.Add((int)(one + two)); set.Add((int)(two + one));
                    set.Add((int)(one - two)); set.Add((int)(two - one));
                    set.Add((int)(one * two)); set.Add((int)(two * one));
                    if (two != 0) set.Add((int)(one / two)); if (one != 0) set.Add((int)(two / one));

                    //Console.Write($"{i + j} => {d}, {(int)(one + two)}, {(int)(one - two)}, {(int)(one * two)}, {(int)(one / two)}\n");

                    if (d == number) { Console.WriteLine(i + j); return i + j; }
                    if ((int)(one + two) == number) { Console.WriteLine(i + j); return i + j; }
                    if ((int)(one - two) == number) { Console.WriteLine(i + j); return i + j; }
                    if ((int)(one * two) == number) { Console.WriteLine(i + j); return i + j; }
                    if ((int)(one / two) == number) { Console.WriteLine(i + j); return i + j; }
                }
            }

          
            calNums[i+j] = set;
        }
   }


    return answer;
}
}