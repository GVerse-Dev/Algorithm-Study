using System;

class BOJ
{
    static void Main()
    {
        string[] str = Console.ReadLine().Split(' ');
        int num1 = int.Parse(str[0]);
        int num2 = int.Parse(str[1]);
        
        Console.WriteLine($"{num1 + num2}");
        Console.WriteLine($"{num1 - num2}");
        Console.WriteLine($"{num1 * num2}");
        Console.WriteLine($"{num1 / num2}");
        Console.WriteLine($"{num1 % num2}");
    }
}