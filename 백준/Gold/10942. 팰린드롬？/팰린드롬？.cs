using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

class BOJ
{
    static StringBuilder sb = new StringBuilder();


    static int Check(int[] ints, int a, int b)
    {
        for (int i = 0; i <= (b - a) / 2; i++)
        {
            if (ints[a + i] != ints[b - i])
                return 0;
        }

        return 1;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] input = Console.ReadLine().Split(" ");

        int[] ints = new int[input.Length + 1];
        for (int i = 1; i <= input.Length; i++)
        {
            ints[i] = int.Parse(input[i - 1]);
        }

        int[,] resultP = new int[ints.Length + 1, ints.Length + 1];
        for (int i = 1; i <= n; ++i)
        {
            for (int j = i; j <= n; ++j)
            {
                resultP[i, j] = Check(ints, i, j);
            }
        }

        int c = int.Parse(Console.ReadLine());

        for (int i = 0; i < c; i++)
        {
            string[] inputC = Console.ReadLine().Split(" ");
            int a = int.Parse(inputC[0]);
            int b = int.Parse(inputC[1]);

            sb.AppendLine(resultP[a,b].ToString());
        }


        Console.WriteLine(sb.ToString());
    }

 
}
