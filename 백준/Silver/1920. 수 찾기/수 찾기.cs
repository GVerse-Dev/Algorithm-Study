using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static int BinarySearch(int[] arr, int l, int r, int target)
    {
        int mid = (l + r) / 2;

        if (l > r)
            return 0;

        if (arr[mid] == target)
            return 1;
        else
        {
            if (l == r)
                return 0;

            if (arr[mid] < target)
            {
                return BinarySearch(arr, mid + 1, r, target);
            }
            else
            {
                return BinarySearch(arr, l, mid - 1, target);
            }
        }
    }

    static void Main()
    {
        int inputCnt = int.Parse(Console.ReadLine());
        int[] inputArr = new int[inputCnt];

        StringBuilder sb = new StringBuilder();

        string[] str = Console.ReadLine().Split(" ");
        for (int i = 0; i < inputCnt; i++)
        {
            inputArr[i] = int.Parse(str[i]);
        }

        Array.Sort(inputArr);

        int inputTargetCnt = int.Parse(Console.ReadLine());
        int[] inputTarget = new int[inputTargetCnt];
        string[] str2 = Console.ReadLine().Split(" ");
        for (int i = 0; i < inputTargetCnt; i++)
        {
            inputTarget[i] = int.Parse(str2[i]);
        }


        for (int i = 0; i < inputTargetCnt; i++)
        {
            sb.Append(BinarySearch(inputArr, 0, inputCnt - 1, inputTarget[i]) + "\n");
        }
        

        Console.WriteLine(sb.ToString());
    }

}

