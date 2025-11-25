using System;
class BOJ
{
    static void Main()
    {
        int number = 0;
        int index = 0;
        int resultNumber = 0;
        int resultIndex = 0;

        while (true) 
        {
            string input = Console.ReadLine();

            if (input == null || input.Length == 0)
                break;

            number = int.Parse(input);
            index++;

            if (number > resultNumber)
            {
                resultNumber = number;
                resultIndex = index;
            }

        }
        Console.WriteLine(resultNumber);
        Console.WriteLine(resultIndex);


    }
}