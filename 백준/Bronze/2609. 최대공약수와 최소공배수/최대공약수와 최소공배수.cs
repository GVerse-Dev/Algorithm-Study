using System;
using System.Text;
class BOJ
{
    static void Main()
    {
        string[] inputArr = Console.ReadLine().Split(' ');
        int[] arr = new int[inputArr.Length];

        int min = 0;
        int max = 0;
        for (int i = 0; i < inputArr.Length; i++)
        {
            arr[i] = int.Parse(inputArr[i]);
        }

        for (int i = 1; i <= arr.Min(); i++)
        {
            //최대 공약수
            if (((arr[0] % i) == 0) && ((arr[1] % i) == 0))
            {
                if (max < i)
                {
                    max = i;
                }
            }

            //최소 공배수
            if (min == 0)
            {
                if (((arr[0] * i) % arr[1] == 0))
                {
                    min = arr[0] * i;
                }
                else if (((arr[1] * i) % arr[0] == 0))
                {
                    min = arr[1] * i;
                }
            }
        }

        
        Console.WriteLine(max);
        Console.WriteLine(min);


    }
}