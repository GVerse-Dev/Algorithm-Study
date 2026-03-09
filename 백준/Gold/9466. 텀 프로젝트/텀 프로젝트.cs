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

    /// <summary>
    /// 탐색 도중 다른 사이클이 나오면 그 사이클 구간의 상태값을 변경하여 더 이상 탐색하지않게 하는 방식
    /// </summary>
    /// <param name="ints"></param>
    /// <param name="idx"></param>
    /// <param name="state"></param>
    static void DFS(int[] ints ,int idx, int[] state)
    {
        state[idx] = 1;

        int next = ints[idx];

        if (state[next] == 0)
        {
            DFS(ints, next, state);
        }
        else if (state[next] == 1)
        {
            int temp = next;
            while (true)
            {
                state[temp] = 3;
                if (temp == idx)
                    break;
                temp = ints[temp];
            }
            return;
        }

        if(state[idx] != 3) 
            state[idx] = 2;
    }
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(" ");
            int[] ints = new int[input.Length + 1];
            int[] state = new int[input.Length + 1];

            for (int j = 1; j < ints.Length; j++)
            {
                ints[j] = int.Parse(input[j - 1]);
            }

            int result = 0;

            for (int j = 1; j < ints.Length; ++j)
            {
                if (state[j] == 0)
                    DFS(ints, j, state);
            }


            for (int j = 1; j < state.Length; ++j)
            {
                if (state[j] != 3)
                    result++;
            }

          
            sb.AppendLine(result.ToString());
        }
      
        Console.WriteLine(sb.ToString());

      

    }

 
}
