using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class BOJ
{
   

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        int inputN = int.Parse(Console.ReadLine());
        string[] inputArr = Console.ReadLine().Split(' ');

        int[] originArr = new int[inputN];
        int[] arr = new int[inputN];

        for (int i = 0; i < inputN; i++)
        {
            arr[i] = int.Parse(inputArr[i]);
            originArr[i] = int.Parse(inputArr[i]);
        }

        Array.Sort(arr);

     
        Dictionary<int, int> map = new Dictionary<int, int>();
        int idx = 0;
        for(int i = 0; i < arr.Length; i++) 
        {
            if (map.ContainsKey(arr[i]) == false)
            {
                map[arr[i]] = idx;
                idx++;
            }
        }


        for (int i = 0; i < originArr.Length; i++)
        {
            sb.Append(map[originArr[i]] + " ");
        }


        Console.WriteLine(sb.ToString());
    }
}
