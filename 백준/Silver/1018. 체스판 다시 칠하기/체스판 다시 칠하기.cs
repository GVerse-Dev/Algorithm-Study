using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static int Check(string[] arr, int x, int y, char target)
    {
        int result = 0;
        for (int i = x; i < x + 8; ++i)
        {
            for (int j = y; j < y + 8; ++j)
            {
                if (target != arr[j][i])
                    result++;

                target = target == 'W' ? 'B' : 'W';
            }
            target = target == 'W' ? 'B' : 'W';
        }

        return result;
    }
    static void Main()
    {
        string[] inputStr = Console.ReadLine().Split(' ');

        int inputY = int.Parse(inputStr[0]);
        int inputX = int.Parse(inputStr[1]);

        string[] inputBoard = new string[inputY];
        for (int i = 0; i < inputY; ++i)
        {
            inputBoard[i] = Console.ReadLine();
        }
        

        StringBuilder stringBuilder = new StringBuilder();

        int min = 32;
        for (int i = 0; i <= inputX - 8; ++i)
        {
            for (int j = 0; j <= inputY - 8; j++)
            {
                int resultW = Check(inputBoard,i, j, 'W');
                int resultB = Check(inputBoard,i, j, 'B');
                int result = resultW < resultB ? resultW : resultB;

                if (result < min)
                    min = result;
            }
        }
        stringBuilder.Append(min);
        Console.WriteLine(stringBuilder.ToString());
    }

}

