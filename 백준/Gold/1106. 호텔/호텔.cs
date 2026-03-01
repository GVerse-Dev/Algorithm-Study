using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static void Main()
    {
        string[] inputCN = Console.ReadLine().Split(" ");
       
        int c = int.Parse(inputCN[0]);
        int n = int.Parse(inputCN[1]);

        int[] ints = new int[c + 101];
        ints[0] = 0;
        for (int i = 1; i < c + 101; i++)
        {
            ints[i] = int.MaxValue;
        }

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" ");

            int cost = int.Parse(input[0]);
            int people = int.Parse(input[1]);

            //입력받은 비용과 인원으로 광고를 했을 때 얻을수 있는것
            for (int j = 0; j + people < ints.Length; j++)
            {
                if (ints[j] == int.MaxValue)
                    continue;

                ints[j + people] = Math.Min(ints[j + people], ints[j] + cost);
            }
        }


        int result = int.MaxValue;
        //요구인원보다 더 많은 인원을 얻지만 비용이 더 적을수 있기 때문에
        for (int i = c; i < c + 101; i++)
        {
            result = Math.Min(ints[i], result);
        }


        Console.WriteLine(result.ToString());
        
    }

 
}
