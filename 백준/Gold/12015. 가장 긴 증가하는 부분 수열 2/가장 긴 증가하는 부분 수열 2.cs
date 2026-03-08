using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.Arm;

class BOJ
{
    static StringBuilder sb = new StringBuilder();
    static int[] parent;
   

    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(" ");
        int[] ints = new int[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            ints[i] = int.Parse(input[i]);
        }

        List<int> list = new List<int>();
        for (int i = 0; i < ints.Length; i++)
        {
            /*
             * BinarySearch
             * item이 있으면 정렬된 List<T>에 있는 item의 인덱스(0부터 시작)이고, 
             * 그렇지 않으면 item보다 큰 다음 요소의 인덱스에 대한 비트 보수인 음수이거나 
             * 더 큰 요소가 없는 경우 Count의 비트 보수입니다.
             */
            int idx = list.BinarySearch(ints[i]);
            if (idx < 0)
                idx = ~idx;
            

            if(idx == list.Count)
                list.Add(ints[i]);
            else
                list[idx] = ints[i];
        }


        Console.WriteLine(list.Count.ToString());
        
    }

 
}
