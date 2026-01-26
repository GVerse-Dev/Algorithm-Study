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

    static void CreateList(int n, int m, int[] arr, int idx, List<int[]> list, int lastValue)
    {
        if (idx >= arr.Length)
        {
            int[] temp = new int[m];

            for (int j = 0; j < m; j++)
            {
                temp[j] = arr[j];
            }

            list.Add(temp);
            return;
        }
        

        //해당 index의 최대 값은  n - m + idx + 1;

        for (int i = lastValue + 1; i <= n; i++)
        {
            int maxValue = n - m + idx + 1;

            if (i > maxValue)
                return;

            //해당 인덱스의 값 변경
            arr[idx] = i;


            //다음 인덱스로 이동
            CreateList(n, m, arr, idx + 1, list, arr[idx]);
        }


    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        string[] inputNM = Console.ReadLine().Split(' ');

        int n = int.Parse(inputNM[0]);
        int m = int.Parse(inputNM[1]);

        int[] arr = new int[m];

        List<int[]> list = new List<int[]>();

        CreateList(n, m, arr, 0, list, 0);



        foreach (int[] item in list)
        {
            foreach (int item2 in item)
            {
                sb.Append(item2.ToString() + " ");
            }
            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString());
    }
}
