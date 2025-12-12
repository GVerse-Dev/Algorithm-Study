using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{
   
    static void Main()
    {
        int inputNCnt = int.Parse(Console.ReadLine());
        string[] inputNStr = Console.ReadLine().Split(' ');

        int inputMCnt = int.Parse(Console.ReadLine());
        string[] inputMStr = Console.ReadLine().Split(' ');

        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < inputNCnt; ++i)
        {
            if (keyValuePairs.ContainsKey(inputNStr[i]))
                keyValuePairs[inputNStr[i]]++;
            else
                keyValuePairs[inputNStr[i]] = 1;
        }

        int[] ints = new int[inputMCnt];
        for (int i = 0; i < inputMCnt; i++)
        {
            if (keyValuePairs.ContainsKey(inputMStr[i]))
                ints[i] = keyValuePairs[inputMStr[i]];
            else
                ints[i] = 0;

        }

        for (int i = 0; i < ints.Length; ++i)
        {
            stringBuilder.Append(ints[i] + " ");
        }

        Console.WriteLine(stringBuilder.ToString());
      
    }

}

