using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static void DP()
    {
        
    }

    static void Main()
    {
        int inputCnt = int.Parse(Console.ReadLine());

        int[] ints = new int[11];

        ints[0] = 0;
        ints[1] = 1;
        ints[2] = 2;
        ints[3] = 4;

        for (int i = 4; i < ints.Length; i++)
        {
            ints[i] = ints[i - 1] + ints[i - 2] + ints[i - 3];
        }

        for(int i = 0; i < inputCnt; i++) 
        {
            int target = int.Parse(Console.ReadLine());
            Console.WriteLine(ints[target]);
        }

       
    }
}

