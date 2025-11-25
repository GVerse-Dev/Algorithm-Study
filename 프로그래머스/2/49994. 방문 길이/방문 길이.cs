using System;
using System.Collections.Generic;
public class Solution {
    public int solution(string dirs)
{
    int answer = 0;

    int[,] board = new int[11, 11];

    HashSet<string> visited = new HashSet<string>();

    int x = 0;
    int y = 0;

    for (int i = 0; i < dirs.Length; ++i)
    {
        switch (dirs[i])
        {
            case 'U':
                if (Check(y - 1, x))
                {
                    visited.Add($"{y - 1}{x}{y}{x}");

                    y = y - 1;
                }
                break;
            case 'D':
                if (Check(y + 1, x))
                {
                    visited.Add($"{y}{x}{y+1}{x}");

                    y = y + 1;
                }
                break;
            case 'R':
                if (Check(y, x + 1))
                {
                    visited.Add($"{y}{x}{y}{x + 1}");

                    x = x + 1;
                }
                break;
            case 'L':
                if (Check(y, x - 1))
                {
                    visited.Add($"{y}{x-1}{y}{x}");

                    x = x - 1;
                }
                break;

        }
    }

    answer = visited.Count;
    Console.WriteLine(answer);

        return answer;
}

public bool Check(int y, int x)
{
    if (y < -5 || x < -5 || y > 5 || x > 5)
    {
        return false;
    }

    return true;
}
}