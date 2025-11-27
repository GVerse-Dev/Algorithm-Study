using System;
using System.Text;
class BOJ
{
    static void Main()
    {
        string[] inputCardArr = Console.ReadLine().Split(' ');
        string[] inputNumberArr = Console.ReadLine().Split(' ');

        int cnt = int.Parse(inputCardArr[0]);
        int maxNumber = int.Parse(inputCardArr[1]);

        int[] numbers = new int[cnt];

        int result = 0;
        int cardCnt = 0;

        for (int i = 0; i < cnt; i++)
        {
            numbers[i] = int.Parse(inputNumberArr[i]);
        }

        for (int i = numbers.Length - 1; i >= 2; i--)
        {
            for (int j = i - 1; j >= 1; j--)
            {
                for (int k = j - 1; k >= 0; k--)
                {
                    if (numbers[i] + numbers[j] + numbers[k] <= maxNumber)
                    {
                        if (result < numbers[i] + numbers[j] + numbers[k])
                        {
                            result = numbers[i] + numbers[j] + numbers[k];
                        }
                    }
                }
            }
        }


        Console.WriteLine(result);
    }
}