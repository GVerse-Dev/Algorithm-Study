using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{
    static void Main()
    {
        int inputCnt = int.Parse(Console.ReadLine());
        int set = 0;
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < inputCnt; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            int num = input.Length > 1 ? int.Parse(input[1]) : 0;

            switch (input[0])
            {
                case "add":
                    set |= (1 << num);
                    break;
                case "remove":
                    set &= ~(1 << num);
                    break;
                case "check":
                    sb.Append((((set & (1 << num)) != 0) ? 1 : 0 ) + "\n");
                    break;
                case "toggle":
                    set ^= (1 << num);
                    break;
                case "all":
                    set = ~0;
                    break;
                case "empty":
                    set = 0;
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine(sb.ToString());

    }
}

