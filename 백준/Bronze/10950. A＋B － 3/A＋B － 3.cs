using System;

class BOJ
{
    static void Main()
    {
        int cnt = int.Parse(Console.ReadLine());


        for (int i = 0; i < cnt; i++) 
        {
            string[] str = Console.ReadLine().Split(' ');
            int num1 = int.Parse(str[0]);
            int num2 = int.Parse(str[1]);

            Console.WriteLine($"{num1 + num2}");
        }
      
    }
}