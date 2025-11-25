using System;

public class Solution {
    public int solution(string skill, string[] skill_trees)
{
    int answer = 0;

    
    foreach (var t in skill_trees) 
    {
        string temp = string.Empty;

        foreach (var t2 in t) 
        {
            if (skill.Contains(t2))
            {
                temp += t2;
            }
        }

        bool equal = true;
        for (int i = 0; i < temp.Length; i++) 
        {
            if(temp[i] != skill[i])
            {
                equal = false;
                break;
            }
        }

        if (equal) 
        {
            answer++; 
        }
    }

            

    Console.WriteLine(answer);


    return answer;
}
}