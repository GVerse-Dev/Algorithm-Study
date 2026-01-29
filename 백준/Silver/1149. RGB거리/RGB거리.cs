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
    static int n = 0;

    static void Main()
    {
        n = int.Parse(Console.ReadLine());

        int[,] graph = new int[n, 3];

        for (int i = 0; i < n; i++)
        {
            string[] inputRGB = Console.ReadLine().Split(" ");

            graph[i, 0] = int.Parse(inputRGB[0]);
            graph[i, 1] = int.Parse(inputRGB[1]);
            graph[i, 2] = int.Parse(inputRGB[2]);

            if (i > 0)
            {
                graph[i, 0] += Math.Min(graph[i - 1, 1], graph[i - 1, 2]);
                graph[i, 1] += Math.Min(graph[i - 1, 0], graph[i - 1, 2]);
                graph[i, 2] += Math.Min(graph[i - 1, 0], graph[i - 1, 1]);
            }
            
        }

        int min = Math.Min(Math.Min(graph[n - 1, 0], graph[n - 1, 1]), graph[n - 1, 2]);

        Console.WriteLine(min.ToString());
    }
}
