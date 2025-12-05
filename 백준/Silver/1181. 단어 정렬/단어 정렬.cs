using System;
using System.Text;
using System.Linq;
class BOJ
{
    public static int Partition(string[] arr,  int l, int r)
    {
        string pivot = arr[(l + r) / 2];

        while (l <= r)
        {
            while ((arr[l].Length < pivot.Length) || ((arr[l].Length == pivot.Length) && MyCompare(arr[l], pivot) < 0))
                l++;
            while ((arr[r].Length > pivot.Length) || ((arr[r].Length == pivot.Length) && MyCompare(arr[r], pivot) > 0))
                r--;

            if (l <= r)
            {
                string tmp = arr[l];
                arr[l] = arr[r];
                arr[r] = tmp;

                l++;
                r--;
            }
        }

        return l;
    }

    public static void QuickSort(string[] arr, int l, int r)
    {
        if (l >= r)
            return;

        int pivotIndex = Partition(arr, l, r);

        QuickSort(arr, l, pivotIndex - 1);
        QuickSort(arr, pivotIndex, r);
    }

    public static int MyCompare(string a, string b)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] < b[i])
                return -1;
            else if (a[i] > b[i])
                return 1;
        }
        return 0;
    }

    static void Main()
    {
        int inputCnt = int.Parse(Console.ReadLine());

        string[] arr = new string[inputCnt];

        for (int i = 0; i < inputCnt; ++i)
        {
            arr[i] = Console.ReadLine();
        }

        QuickSort(arr, 0, arr.Length - 1);

        Console.WriteLine(arr[0]);
        for (int i = 1; i < inputCnt; ++i)
        {
            if (arr[i] != arr[i - 1])
                Console.WriteLine(arr[i]);
        }


    }
}