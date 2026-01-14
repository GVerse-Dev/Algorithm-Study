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
        ulong n = ulong.Parse(Console.ReadLine());

        if (n <= 2)
        {
            sb.Append(n + "\n"); 
        }
        else
        {
            ulong[] sumArr = new ulong[n + 1];
            sumArr[0] = 0;
            sumArr[1] = 1;
            sumArr[2] = 2;


            for (ulong i = 3; i <= n; i++)
            {
                sumArr[i] = (sumArr[i - 1] + sumArr[i - 2]) % 10007;
            }

            sb.Append((sumArr[n] ) + "\n");
        }
       

        Console.WriteLine(sb.ToString());
    }
}

