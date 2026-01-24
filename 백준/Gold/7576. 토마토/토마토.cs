using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

class BOJ
{

    static void BFS()
    {
        
    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        string[] inputNM = Console.ReadLine().Split(' ');

        int n = int.Parse(inputNM[0]);
        int m = int.Parse(inputNM[1]);

        int[,] board = new int[m, n];
        bool[,] visited = new bool[m, n];

        Queue<(int y, int x, int days)> queue = new Queue<(int y, int x, int days)>();
        int lastDay = 0;

        for (int i = 0; i < m; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
            {
                board[i, j] = int.Parse(input[j]);
                if (board[i, j] == 1)
                {
                    queue.Enqueue((i, j, 0));
                    visited[i, j] = true;
                }
            }
        }

        while (queue.Count > 0)
        {
            (int y, int x, int days) position = queue.Dequeue();

            int[] dirX = new int[] { -1, 0, 1, 0 };
            int[] dirY = new int[] { 0, -1, 0, 1 };

            for (int i = 0; i < dirX.Length; ++i)
            {
                int nextX = position.x + dirX[i];
                int nextY = position.y + dirY[i];

                if (nextX < 0 || nextX >= board.GetLength(1))
                    continue;
                if (nextY < 0 || nextY >= board.GetLength(0))
                    continue;


                if ((board[position.y, position.x] == 1) && (board[nextY, nextX] == 0))
                    board[nextY, nextX] = 1;

                if (board[nextY, nextX] > -1 && visited[nextY, nextX] == false)
                {
                    lastDay = position.days + 1;
                    queue.Enqueue((nextY, nextX, position.days + 1));
                    visited[nextY, nextX] = true;

                }
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i, j] == 0)
                {
                    lastDay = -1;
                    break;
                }
            }

            if (lastDay == -1)
                break;
        }

        sb.Append(lastDay);
        Console.WriteLine(sb.ToString());
    }
}
