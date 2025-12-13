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
        bool[] arr = new bool[21];
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < inputCnt; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            int num = input.Length > 1 ? int.Parse(input[1]) : 0;

            switch (input[0])
            {
                case "add":
                    arr[num] = true;
                    break;
                case "remove":
                    arr[num] = false;
                    break;
                case "check":
                    sb.Append((arr[num] ? 1 : 0)  + "\n");
                    break;
                case "toggle":
                    if (arr[num])
                        arr[num] = false;
                    else
                        arr[num] = true;
                    break;
                case "all":
                    for (int k = 0; k < arr.Length; k++)
                        arr[k] = true;
                    break;
                case "empty":
                    for (int k = 0; k < arr.Length; k++)
                        arr[k] = false;
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine(sb.ToString());

    }
}

