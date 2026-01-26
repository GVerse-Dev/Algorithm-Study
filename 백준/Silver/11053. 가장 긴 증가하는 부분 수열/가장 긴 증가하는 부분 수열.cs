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

    //static int DFS(int[] ints, int idx, int count)
    //{
    //    int max = 0;
    //    int longest = 0;
    //    for (int i = idx; i < ints.Length; ++i)
    //    {
    //        if (ints[i] <= max)
    //            continue;

    //        max = ints[i];
    //        count++;

    //        int result = DFS(ints, i + 1, count);

    //        if(count < result)
    //            longest = result;
    //    }

    //    return longest;
    //}
   

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] input = Console.ReadLine().Split(' ');

        int[] ints = new int[n];
        int[] longest = new int[n];

        for (int i = 0; i < n; i++)
        {
            ints[i] = int.Parse(input[i]);
        }

        longest[n - 1] = 1;

        for (int i = n - 1; i > 0; i--)
        {
            int prevIdx = i - 1;
            for (int j = i; j < n; j++)
            {
                if (ints[prevIdx] < ints[j])
                {
                    if (longest[prevIdx] < longest[j] + 1)
                        longest[prevIdx] = longest[j] + 1;
                }
            }

            if (longest[prevIdx] == 0)
                longest[prevIdx] = 1;
        }

        int max = 0;
        foreach (int i in longest)
        {
            if(max < i)
                max = i;
        }

        Console.WriteLine(max.ToString());
    }
}
