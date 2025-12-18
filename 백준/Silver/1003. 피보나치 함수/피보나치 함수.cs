using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        int input = int.Parse(Console.ReadLine());

        int[] zeroArr= new int[41];
        int[] oneArr = new int[41];

        for (int i = 0; i < 41; i++) 
        {
            if (i == 0)
            {
                zeroArr[i] = 1;
                oneArr[i] = 0;
                continue;
            }
            else if (i == 1)
            {
                zeroArr[i] = 0;
                oneArr[i] = 1;
                continue;
            }
          
            zeroArr[i] = zeroArr[i-1] + zeroArr[i - 2];
            oneArr[i] = oneArr[i-1] + oneArr[i-2];
        }

        for (int i = 0; i < input; i++)
        {
            int value = int.Parse(Console.ReadLine());

            sb.Append($"{zeroArr[value]} {oneArr[value]}" + "\n");
        }
       
        Console.WriteLine(sb.ToString());

    }
}

