using System;
using System.Text;
class BOJ
{
    static void Main()
    {
        int inputCnt = int.Parse(Console.ReadLine());

        for(int cnt = 0; cnt<inputCnt; ++cnt)
        {
            string[] inputArr = Console.ReadLine().Split(' ');

            StringBuilder stringBuilder = new StringBuilder();
            int loopCnt = int.Parse(inputArr[0]);
            string str = inputArr[1];

            for (int i = 0; i < str.Length; i++)
            {
                stringBuilder.Append(new string(str[i], loopCnt));
            }

            Console.WriteLine(stringBuilder);
        }
    }
}