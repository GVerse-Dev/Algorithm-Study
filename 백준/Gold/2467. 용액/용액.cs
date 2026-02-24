using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static void Main()
    {

        int n = int.Parse(Console.ReadLine());

        string[] input = Console.ReadLine().Split(" ");

        int[] ints = new int[n];

        for (int i = 0; i < ints.Length; i++)
        {
            ints[i] = int.Parse(input[i]);
        }

        Array.Sort(ints);


        int resultLeft = 0;
        int resultRight = 0;
        int resultSum = int.MaxValue;

        int left = 0;
        int right = n - 1;

        while (left < right)
        {
            int sum = (ints[left] + ints[right]);

            if (Math.Abs(sum) < resultSum)
            {
                resultLeft = left;
                resultRight = right;
                resultSum = Math.Abs(sum);
            }

            if (sum == 0)
            {
                break;
            }
            else if (sum > 0)
            {
                right--;
            }
            else
            {
                left++;
            }
        }


        sb.Append(ints[resultLeft].ToString() + " " + ints[resultRight].ToString());

        Console.WriteLine(sb.ToString());
    }

 
}
