using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static void MergeSort(int[] arrOrigin, int[] tempArr, int l, int r)
    {
        if (l < r)
        {
            int m = (l + r) / 2;
            MergeSort(arrOrigin, tempArr, l, m);
            MergeSort(arrOrigin, tempArr, m + 1, r);
            Merge(arrOrigin, tempArr, l, r, m + 1);
        }
    }

    static void Merge(int[] arr, int[] tempArr, int start, int end, int mid)
    {
        if (start < end)
        {
            int tmp1 = start;       //왼쪽
            int tmp2 = mid;         //오른쪽
            int index = start;      //합친 배열의 인덱스
            while (tmp1 < mid && tmp2 <= end)
            {
                if (arr[tmp1] <= arr[tmp2])
                    tempArr[index++] = arr[tmp1++];
                else
                    tempArr[index++] = arr[tmp2++];
            }

            while (tmp1 < mid)
                tempArr[index++] = arr[tmp1++];
            while (tmp2 <= end)
                tempArr[index++] = arr[tmp2++];

            for (int i = start; i <= end; i++)
            {
                arr[i] = tempArr[i];
            }
        }

    }

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

        int[] tempArr = new int[inputCnt];
        MergeSort(inputArr, tempArr, 0, inputCnt - 1);


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

