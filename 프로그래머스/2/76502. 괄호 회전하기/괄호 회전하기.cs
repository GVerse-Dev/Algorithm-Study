using System;
using System.Collections.Generic;
public class Solution {
    public int solution(string s)
{
    int answer = 0;

 

    //회전
    for(int i = 0; i < s.Length ; ++i)
    {
        Queue<char> queue = new Queue<char>();
        Stack<char> stack = new Stack<char>();

        string temp = s;

        foreach(var item in s)
        {
            queue.Enqueue(item);
        }

        for(int j = 0; j < i; ++j)
        {
            var o = queue.Dequeue();
            queue.Enqueue((char)o);
        }

      


        bool check = true;
        while(queue.Count > 0)
        {
            char c = queue.Dequeue();

            if (c == '[' || c == '{' || c == '(')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count <= 0)
                {
                    check = false;
                    break;
                }

                var tempStack = stack.Pop();

                if (c == ']')
                {
                    if (tempStack != '[')
                    {
                        check = false;
                        break;
                    }
                }
                else if (c == '}')
                {
                    if (tempStack != '{')
                    {
                        check = false;
                        break;
                    }
                }
                else if (c == ')')
                {
                    if (tempStack != '(')
                    {
                        check = false;
                        break;
                    }
                }

            }
        }


        if (check && stack.Count <= 0)
            answer += 1;
    }

    return answer;
}
}