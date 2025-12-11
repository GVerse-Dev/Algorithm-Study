using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static void MergeSort((int num1, int num2)[] arrOrigin, (int num1, int num2)[] tempArr, int l, int r)
    {
        if (l < r)
        {
            int m = (l + r) / 2;
            MergeSort(arrOrigin, tempArr, l, m );
            MergeSort(arrOrigin, tempArr, m + 1, r);
            Merge(arrOrigin, tempArr, l, r, m + 1);
        }
    }

    static void Merge((int num1, int num2)[] arr, (int num1, int num2)[] tempArr, int start, int end, int mid)
    {
        if (start < end)
        {
            int tmp1 = start;       //왼쪽
            int tmp2 = mid;         //오른쪽
            int index = start;      //합친 배열의 인덱스
            while (tmp1 < mid && tmp2 <= end)
            {
                if (arr[tmp1].num1 < arr[tmp2].num1)
                    tempArr[index++] = arr[tmp1++];
                else if (arr[tmp1].num1 == arr[tmp2].num1)
                {
                    if (arr[tmp1].num2 <= arr[tmp2].num2)
                        tempArr[index++] = arr[tmp1++];
                    else
                        tempArr[index++] = arr[tmp2++];
                }
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

    static void Main()
    {
        int inputCnt = int.Parse(Console.ReadLine());
        (int num1, int num2)[] inputArr = new (int num1, int num2)[inputCnt];

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < inputCnt; i++)
        {
            string[] str = Console.ReadLine().Split(" ");
            inputArr[i].num1 = int.Parse(str[0]);
            inputArr[i].num2 = int.Parse(str[1]);
        }

        (int num1, int num2)[] tempArr = new (int num1, int num2)[inputCnt];
        MergeSort(inputArr, tempArr, 0, inputCnt - 1);
        //MergeSort(inputArr, tempArr, 0, inputCnt - 1);


        for (int i = 0; i < inputCnt; i++)
        {
            sb.Append(inputArr[i].num1 + " " + inputArr[i].num2 + "\n");
        }

        Console.WriteLine(sb.ToString());
    }

}

