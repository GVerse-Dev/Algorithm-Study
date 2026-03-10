using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.Arm;
using System.ComponentModel;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

  
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] arr = Console.ReadLine().Split(" ");
        long[] ints = new long[n];

        for (int i = 0; i < ints.Length; i++)
        {
            ints[i] = long.Parse(arr[i]);
        }

        Array.Sort(ints);

      

        long[] result = new long[3];
     
        long value = long.MaxValue;

        for (int i = 0; i < ints.Length; i++)
        {
            int left = i + 1;
            int right = n - 1;

            while (left < right)
            {
                long sum = ints[i] +  ints[left] + ints[right];

                if (value > Math.Abs(sum))
                {
                    result[0] = ints[i];
                    result[1] = ints[left];
                    result[2] = ints[right];

                    value = Math.Abs(sum);
                }

                if (sum < 0)
                {
                    left++;
                }
                else if (sum > 0)
                {
                    right--;
                }
                else
                    break;
            }
        }

        sb.Append(result[0].ToString() + " ");
        sb.Append(result[1].ToString() + " ");
        sb.Append(result[2].ToString() + " ");


        Console.WriteLine(sb.ToString());

      

    }

 
}
