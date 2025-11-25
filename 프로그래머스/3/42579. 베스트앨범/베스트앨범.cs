using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
public class Solution {
    public int[] solution(string[] genres, int[] plays) {
        int[] answer = new int[] { };
Dictionary<string, List<KeyValuePair<int, int>>> test = new Dictionary<string, List<KeyValuePair<int, int>>>();
for(int i = 0; i < genres.Length; ++i)
{
    if(test.ContainsKey(genres[i]) == false)
        test[genres[i]]= new List<KeyValuePair<int, int>>();
    test[genres[i]].Add(new KeyValuePair<int, int>(i,plays[i]));
}
var ordered = test.OrderByDescending(a => a.Value.Sum(o=>o.Value)).ToDictionary(c=>c.Key, d=>d.Value);
foreach (var keys in ordered.Keys.ToList()) 
{
    ordered[keys] = ordered[keys].OrderByDescending(o => o.Value).Take(2).ToList();
}
List<int> result = new List<int>();
foreach (var pair in ordered)
{
    foreach(var data in pair.Value)
    {
        result.Add(data.Key);
    }
}
answer = result.ToArray();
foreach (var pair in answer)   
    Console.WriteLine(pair);
return answer;
    }
}