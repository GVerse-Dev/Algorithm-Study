using System;
using System.Text;
class BOJ
{
    static void Main()
    {
        int inputN = int.Parse(Console.ReadLine());
        string[] inputNumberArr = Console.ReadLine().Split(' ');

        int[] numberArr = new int[inputNumberArr.Length];
        int result = 0;

        for (int i = 0; i < numberArr.Length; ++i)
        {
            numberArr[i] = int.Parse(inputNumberArr[i]);
        }

        for (int i = 0; i < numberArr.Length; ++i)
        {
            if (numberArr[i] <= 1)
                continue;

            bool check = true;
            for (int j = 2; j <= numberArr[i] / 2; ++j)
            {
                if (numberArr[i] % j == 0)
                {
                    check = false; break;
                }
            }

            if(check)
                result++;
        }

        Console.WriteLine(result);
    }
}