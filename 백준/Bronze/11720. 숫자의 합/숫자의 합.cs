using System;
class BOJ
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string str = Console.ReadLine();
        int result = 0;

        for (int i = 0; i < n; i++) 
        {
            result += str[i] % 48;
        }

        Console.WriteLine(result);
    }
}