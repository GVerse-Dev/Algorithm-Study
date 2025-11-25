using System;
using System.Collections.Generic;

class BOJ
{

    static void Main()
    {
        string[] str = Console.ReadLine().Split(' ');

        double A = double.Parse(str[0]);
        double B = double.Parse(str[1]);

        Console.WriteLine(A/B);
    }
}