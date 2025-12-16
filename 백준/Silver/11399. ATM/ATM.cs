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
        string[] inputStr = Console.ReadLine().Split();
        int[] ints = new int[input];

        for (int i = 0; i < ints.Length; i++)
        {
            ints[i] = int.Parse(inputStr[i]);
        }
       
        Array.Sort(ints);
        int result = 0;
        int sum = 0;
        for (int i = 0; i < ints.Length; ++i)
        {
            sum += ints[i];
            result = (result + sum);
        }

        Console.WriteLine(result.ToString());

    }
}

