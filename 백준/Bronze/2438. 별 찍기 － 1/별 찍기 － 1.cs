using System;
using System.Collections.Generic;

class BOJ
{

    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        for (int i = 1; i <= count; i++) 
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

    }
}