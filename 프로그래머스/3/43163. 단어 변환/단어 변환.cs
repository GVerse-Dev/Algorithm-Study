using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

public class Solution {
    List<KeyValuePair<string,int>> result = new List<KeyValuePair<string,int>>();
bool[] visit = new bool[50];
public int solution(string begin, string target, string[] words)
{
    int answer = 0;
    int level = 1;

    for (int i = 0; i < words.GetLength(0); ++i)
    {
        if (CheckDiffOneChar(begin, words[i]))
        {
            visit[i] = true;
            result.Add(new KeyValuePair<string, int>(words[i], level));
            if (words[i] == target)
            {
                answer = level;
                Console.WriteLine(answer);
                return answer;
            }
                
        }
    }

    if (result.Count == 0) { return answer; }

    for (int i =0; i<result.Count; ++i)
    {
        for (int j = 0; j < words.GetLength(0); ++j)
        {
            if (visit[j])
                continue;

            if (CheckDiffOneChar(result[i].Key, words[j]))
            {
                result.Add(new KeyValuePair<string, int>(words[j], result[i].Value + 1));
                visit[j] = true;

                if (words[j] == target)
                {
                    answer = result[i].Value + 1;
                    Console.WriteLine(answer);
                    return answer;
                }
                    
            }
        }
    }

    Console.WriteLine(answer);
    return answer;
}
   

public bool CheckDiffOneChar(string a, string b)
{
    int count = 0;
    for (int i = 0; i < a.Length; ++i)
    {
        if (a[i] != b[i])
            count++;

        if (count > 1)
            return false;
    }

    return true;
}
}