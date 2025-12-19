using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{
    static void Main()
    {
        
        int input = int.Parse(Console.ReadLine());
        int[] num = new int[1000001];

        for (int i = 1; i < 1000001; i++)
        {
            if (i == 1)
                num[i] = 0;
            else if (i <= 3)
                num[i] = 1;

            if (i * 3 < 1000001)
                num[i * 3] = num[i * 3] > 0 ? Math.Min(num[i * 3], num[i] + 1) : num[i] + 1;
            if (i * 2 < 1000001)
                num[i * 2] = num[i * 2] > 0 ? Math.Min(num[i * 2], num[i] + 1) : num[i] + 1;
            if (i + 1 < 1000001)
                num[i + 1] = num[i + 1] > 0 ? Math.Min(num[i + 1], num[i] + 1) : num[i] + 1;
        }


        Console.WriteLine(num[input]);

    }
}

