using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static void Main()
    {
        string[] inputStr = Console.ReadLine().Split(' ');

        StringBuilder stringBuilder = new StringBuilder();

        Queue<int> queue = new Queue<int>();
        int inputCnt = int.Parse(inputStr[0]);
        int inputK = int.Parse(inputStr[1]);
        for (int i = 1; i <= inputCnt; ++i)
        {
            queue.Enqueue(i);
        }

        stringBuilder.Append("<");

        int cnt = 0;
        while (queue.Count > 1)
        {
            cnt++;
            if (cnt < inputK)
                queue.Enqueue(queue.Dequeue());
            else if (cnt == inputK)
            {
                stringBuilder.Append(queue.Dequeue() + ", ");
                cnt = 0;
            }
        }

        stringBuilder.Append(queue.Dequeue() + ">");


        Console.WriteLine(stringBuilder.ToString());
    }

}

