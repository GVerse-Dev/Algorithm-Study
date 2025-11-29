using System;
using System.Text;
class BOJ
{
    static void Main()
    {

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "0")
                break;
            for (int i = 0; i <= input.Length / 2; i++)
            {
                if ((i == (input.Length / 2)) && (input[i] == input[input.Length - i - 1]))
                {
                    Console.WriteLine("yes");
                }

                if (input[i] == input[input.Length - i - 1])
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("no");
                    break;
                }
            }
        }
       
        
    }
}