using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static void MergeSort((int age, string name)[] arrOrigin, (int age, string name)[] tempArr, int l, int r)
    {
        if (l < r)
        {
            int m = (l + r) / 2;
            MergeSort(arrOrigin, tempArr, l, m );
            MergeSort(arrOrigin, tempArr, m + 1, r);
            Merge(arrOrigin, tempArr, l, r, m + 1);
        }
    }

    static void Merge((int age, string name)[] arr, (int age, string name)[] tempArr, int start, int end, int mid)
    {
        if (start < end)
        {
            int tmp1 = start;       //왼쪽
            int tmp2 = mid;         //오른쪽
            int index = start;      //합친 배열의 인덱스
            while (tmp1 < mid && tmp2 <= end)
            {
                if (arr[tmp1].age <= arr[tmp2].age)
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

    static void Main()
    {
        int inputCnt = int.Parse(Console.ReadLine());
        (int age, string name)[] inputArr = new (int age, string name)[inputCnt];

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < inputCnt; i++)
        {
            string[] str = Console.ReadLine().Split(" ");
            inputArr[i].age = int.Parse(str[0]);
            inputArr[i].name = str[1];
        }

        (int age, string name)[] tempArr = new (int age, string name)[inputCnt];
        MergeSort(inputArr, tempArr, 0, inputCnt - 1);


        for (int i = 0; i < inputCnt; i++)
        {
            sb.Append(inputArr[i].age + " " + inputArr[i].name + "\n");
        }

        Console.WriteLine(sb.ToString());
    }

}

