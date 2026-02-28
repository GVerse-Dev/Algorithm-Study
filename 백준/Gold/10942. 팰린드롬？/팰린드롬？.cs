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

        bool[,] resultP = new bool[ints.Length + 1, ints.Length + 1];

        //길이가 1
        for (int i = 1; i <= n; i++)
        {
            resultP[i,i] = true;
        }

        //길이가 2
        for (int i = 1; i <= n - 1; i++)
        {
            resultP[i, i + 1] = ints[i] == ints[i + 1] ? true : false;
        }

        //길이가 3 이상
        for (int len = 3; len <= n; len++)
        {
            for (int start = 1; start + len - 1 <= n; start++)
            {
                int end = start + len - 1;

                resultP[start, end] = ((ints[start] == ints[end]) && resultP[start + 1, end - 1]); 
            }
        }



        int c = int.Parse(Console.ReadLine());

        for (int i = 0; i < c; i++)
        {
            string[] inputC = Console.ReadLine().Split(" ");
            int a = int.Parse(inputC[0]);
            int b = int.Parse(inputC[1]);

            sb.AppendLine(resultP[a,b] ? "1" : "0");
        }


        Console.WriteLine(sb.ToString());
    }

 
}
