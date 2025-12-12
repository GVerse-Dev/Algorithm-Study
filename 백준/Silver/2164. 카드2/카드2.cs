using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static void Main()
    {
        int inputCnt = int.Parse(Console.ReadLine());
        Queue<int> ints = new Queue<int>();

        for (int i = 1; i <= inputCnt; i++)
        {
            ints.Enqueue(i);
        }


        bool move = false;
        while (ints.Count > 1)
        {
            if (move == false)
            {
                ints.Dequeue();
                move = true;
            }
            else
            {
                int temp = ints.Dequeue();
                ints.Enqueue(temp);
                move= false;
            }
        }

        Console.WriteLine(ints.Dequeue());

    }

}

