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

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        int inputN = int.Parse(Console.ReadLine());
        List<List<int>> list = new List<List<int>>();
        int endTime = 0;
        int count = 1;

        for (int i = 0; i < inputN; i++)
        {
            string[] inputTime = Console.ReadLine().Split(' ');

            list.Add(new List<int>());
            list[i].Add(int.Parse(inputTime[0]));
            list[i].Add(int.Parse(inputTime[1]));
        }


        list = list.OrderBy(o => o[1]).ThenBy(o => o[0]).ToList();

        endTime = list[0][1];
        for (int i = 1; i < list.Count; i++)
        {
            if (endTime <= list[i][0])
            {
                endTime = list[i][1];
                count++;
            }
        }

        sb.Append(count.ToString());

        Console.WriteLine(sb.ToString());
    }
}
