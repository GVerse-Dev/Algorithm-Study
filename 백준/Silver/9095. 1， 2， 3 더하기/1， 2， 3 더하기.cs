using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static int DFS(int target, int value)
    {
        int result = 0;

        if (value == target)
            return 1;

        if (value > target)
            return 0;

        result += DFS(target, value + 1);
        result += DFS(target, value + 2);
        result += DFS(target, value + 3);

        return result; 
    }

    static void Main()
    {
        int inputCnt = int.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();

        

        for(int i = 0; i < inputCnt; i++) 
        {
            int target = int.Parse(Console.ReadLine());
            Console.WriteLine(DFS(target, 1) + DFS(target, 2) + DFS(target, 3));
        }

       
    }
}

