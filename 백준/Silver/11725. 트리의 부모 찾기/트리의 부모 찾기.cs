using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

class BOJ
{

    static StringBuilder sb = new StringBuilder();

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<List<int>> inputArr = new List<List<int>>();
        List<(int parent, List<int> childs)> list = new List<(int parent, List<int> childs)> ();
        bool[] visited = new bool[n + 1];

        for (int i = 0; i < n + 1; i++)
        {
            inputArr.Add(new List<int>());
            list.Add((0, new List<int>()));
        }

        //양방향 그래프 2차원으로 구성
        for (int i = 0; i < n - 1; i++)
        {
            string[] input = Console.ReadLine().Split(" ");

            int key = int.Parse(input[0]);
            int value = int.Parse(input[1]);

            inputArr[key].Add(value);
            inputArr[value].Add(key);
        }


        // 1의 자식 6 ,4 가 들어갔으면 다음 키는 6, 4가 되어야함 node가 아님
        //for (int node = 1; node <= n; node++)
        //{
        //    List<int> childList = new List<int>();
        //    int parent = 0;
        //    if (node > 1)
        //    {
        //        parent = node;
        //    }

        //    foreach(int child in inputArr[node])
        //    {
        //        childList.Add(child);
        //    }

        //    list[node] = (parent, childList);
        //}

        Queue<(int parent, List<int> childs)> queue = new Queue<(int parent, List<int> childs)>();
        queue.Enqueue((1, inputArr[1]));

        while (queue.Count > 0)
        {
            (int parent, List<int> childs) value = queue.Dequeue();

            foreach (int child in value.childs)
            {
                if (visited[child])
                    continue;

                visited[child] = true;

                queue.Enqueue((child, inputArr[child]));

                //자신의 부모, 자신의 자식들 추가
                list[child] = (value.parent, inputArr[child]);
            }
        }


        for (int i = 2; i <= n; i++)
        {
            sb.AppendLine(list[i].parent.ToString());
        }


        Console.WriteLine(sb.ToString());
    }
}
