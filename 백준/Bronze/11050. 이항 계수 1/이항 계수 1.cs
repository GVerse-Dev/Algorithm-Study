using System;
using System.Text;
class BOJ
{
    static int Factorial(int x, int cnt)
    {
        int sum = 1;
        for (int i = 0; i < cnt; i++)
        {
            sum *= x;
            x--;
        }
        return sum;
    }
    static void Main()
    {
        string[] inputArr = Console.ReadLine().Split(' ');
        int[] arr = new int[inputArr.Length];

        for (int i = 0; i < inputArr.Length; i++)
        {
            arr[i] = int.Parse(inputArr[i]);
        }

        int p = Factorial(arr[0], arr[1]);          //총 N개중에서 K개의 원소로 이루어진 순열의 경우의 수

        int c = p / (Factorial(arr[1], arr[1]));    //모든 순열의 경우의 수에서 순서만 다른 중복된 값 제거 => 조합의 경우의 수

        Console.WriteLine(c);

    }
}