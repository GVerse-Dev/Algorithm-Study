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

        string[] inputNM = Console.ReadLine().Split(' ');
        string[] inputArr = Console.ReadLine().Split(' ');
        
        long n = int.Parse(inputNM[0]);
        long getHeight = int.Parse(inputNM[1]);

        long[] arr = new long[n];

        for (long i = 0; i < n; i++)
        {
            arr[i] = long.Parse(inputArr[i]);
        }

        //n log n? (100만 x 5? = 500만 1초는 1억개니까 정렬은 전혀 문제가 안될듯)
        arr = arr.OrderByDescending(o => o).ToArray();


        long min = 1;
        long max = arr[0] - 1;
        long result = 0;

        //반씩 자르니까 log N인데 아래 for문이랑 다 합쳐도 n log n 아닌가 왜 시간초과지
        while (max >= min)
        {
            long mid = (min + max) / 2;
            long sum = 0;

            //여기는 최대 n번이고
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > mid)
                    sum += arr[i] - mid;
                else
                    break;
            }

            if (sum == getHeight)
            {
                result = mid;
                break;
            }
            else if (sum > getHeight)
            {
                result = mid;
                min = mid + 1;
            }
            else if(sum < getHeight)
            {
                 max = mid - 1;
            }
        }
        sb.AppendLine(result.ToString());
        

        Console.WriteLine(sb.ToString());
    }
}

