using System;

class BOJ
{
    static void Main()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (input == null || input.Length == 0)
                break;

            string[] str = input.Split(' ');

            int num1 = int.Parse(str[0]);
            int num2 = int.Parse(str[1]);

            if (num1 == 0 && num2 == 0)
                break;

            Console.WriteLine(num1 + num2);
        }

    }
}