using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Collections.Generic;

class BOJ
{
    static int white = 0;
    static int blue = 0;

    static void Divide(int[,] board, int x, int y, int size)
    {
        int result = Check(board, x, y, size);

        if (result >= 0)
        {
            if (result == 1)
                blue++;
            else
                white++;

            return;
        }

        int newSize = size / 2;

        Divide(board, x, y, newSize);
        Divide(board, x + newSize, y, newSize);
        Divide(board, x, y + newSize, newSize);
        Divide(board, x + newSize, y + newSize, newSize);
    }

    // 쪼개진 보드를 체크
    static int Check(int[,] board, int x, int y, int size)
    {
        int target = board[y,x];

        for (int i = y; i < y + size; ++i)
        {
            for (int j = x; j < x + size; ++j)
            {
                if (board[i,j] != target)
                {
                    return -1;
                }
            }

        }

        return target;
    }
    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        int inputN = int.Parse(Console.ReadLine());

        int[,] board = new int[inputN,inputN];

        for (int y = 0; y < inputN; y++)
        {
            string[] input = Console.ReadLine().Split(' ');

            for (int x = 0; x < inputN; x++)
            {
                board[y,x] = int.Parse(input[x]);
            }
        }


        Divide(board, 0, 0, inputN);


        sb.AppendLine(white.ToString());
        sb.AppendLine(blue.ToString());

        Console.WriteLine(sb.ToString());
    }
}

