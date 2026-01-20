using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection;

class BOJ
{

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        string[] inputNK = Console.ReadLine().Split(' ');
        int n = int.Parse(inputNK[0]);
        int k = int.Parse(inputNK[1]);

        Queue<(int, int)> queue = new Queue<(int, int)>();
        bool[] visited = new bool[100001];

        if (n != k)
        {
            visited[n] = true;
            queue.Enqueue((n, 0));
        }
        else
        {
            sb.AppendLine("0");
        }
        

        while (queue.Count > 0)
        {
            var value = queue.Dequeue();

            int position = value.Item1;
            int level = value.Item2;

            int nextValue = 0;
            int nextLevel = level + 1;

            nextValue = position - 1;
            if ((position - 1) == k)
            {
                sb.AppendLine(nextLevel.ToString()); break;
            }
            else if (nextValue >= 0 && !visited[nextValue])
            {
                visited[nextValue] = true;
                queue.Enqueue((nextValue, nextLevel));
            }

            nextValue = position + 1;
            if (nextValue == k)
            {
                sb.AppendLine(nextLevel.ToString());
                break;
            }
            else if (nextValue <= 100000 && !visited[nextValue])
            {
                visited[nextValue] = true;
                queue.Enqueue((nextValue, nextLevel));
            }
            


            nextValue = position * 2;
            if (nextValue == k)
            {
                sb.AppendLine(nextLevel.ToString());
                break;
            }
            else if (nextValue <= 100000 && !visited[nextValue])
            {
                visited[nextValue] = true;
                queue.Enqueue((nextValue, nextLevel));
            }
        }

    

        Console.WriteLine(sb.ToString());
    }
}
