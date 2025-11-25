using System;
using System.Collections.Generic;

class BOJ
{

    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        for(int cal = 1; cal <= 9; ++cal)
            Console.WriteLine($"{num} * {cal} = {num*cal}");
    }
}