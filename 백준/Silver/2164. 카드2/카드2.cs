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
        List<int> list = new List<int>();

        for (int i = 1; i <= inputCnt; i++)
        {
            list.Add(i);
        }

        int index = 0;
        bool move = false;
        while (index < list.Count - 1)
        {
            if (move == false)
            {
                move = true;
            }
            else
            {
                list.Add(list[index]);
                move= false;
            }

            index++;
        }

        Console.WriteLine(list[index]);

    }

}

