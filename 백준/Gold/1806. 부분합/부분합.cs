using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static void Main()
    {
        string[] inputNS = Console.ReadLine().Split(" ");

        int n = int.Parse(inputNS[0]);
        int s = int.Parse(inputNS[1]);

        string[] inputCN = Console.ReadLine().Split(" ");
        int[] ints = new int[n];

        for (int i = 0; i < n; i++)
        {
            ints[i] = int.Parse(inputCN[i]);
        }

        int result = n + 1;
        int left = 0;
        int right = 0;
        int sum = 0;

        while ((left <= right))
        {
            if (sum >= s)
            {
                if (result > right - left)
                {
                    result = right - left;
                }
                sum -= ints[left];
                left++;
            }
            else if (right == n)
                break;
            else
            {
                sum += ints[right];
                right++;
            }

          
        }

        if (result == n + 1)
            result = 0;

        sb.Append(result);


        Console.WriteLine(sb.ToString());
    }

 
}
