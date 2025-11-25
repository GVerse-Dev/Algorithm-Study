using System;
class BOJ
{
    static void Main()
    {
        string inputCnt = Console.ReadLine();
        string[] inputArr = Console.ReadLine().Split(' ');
        int min = 1000000;
        int max = -1000000;
        for (int i = 0; i < inputArr.Length; i++) 
        {
            int num = int.Parse(inputArr[i]);
            if(min > num) min = num;
            if(max < num) max = num;
        }

        Console.WriteLine($"{min} {max}");


    }
}