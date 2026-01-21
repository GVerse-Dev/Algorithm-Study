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

    static void BFS(int[,] board, bool[,] visited, int[] goal)
    {
        Queue<int[]> queue = new Queue<int[]>();
        
        int[] dirX = new int[] { -1, 0, 1, 0 };
        int[] dirY = new int[] { 0, -1, 0, 1 };

        queue.Enqueue(new int[] { goal[0], goal[1] });
        board[goal[1], goal[0]] = 0;

        while (queue.Count > 0)
        {
            int[] ints = queue.Dequeue();

            if (visited[ints[1], ints[0]])
                continue;

            visited[ints[1], ints[0]] = true;

            for (int i = 0; i < dirX.Length; i++)
            {
                int nextX = ints[0] + dirX[i];
                int nextY = ints[1] + dirY[i];

                if(nextX < 0 || nextX >= board.GetLength(1) || nextY < 0 || nextY >= board.GetLength(0))
                    continue;

                if (visited[nextY, nextX] == false && board[nextY, nextX] > 0)
                {
                    queue.Enqueue(new int[] { nextX, nextY });
                    board[nextY, nextX] = board[ints[1], ints[0]] + 1;
                }
                else if (board[nextY, nextX] == 0)
                {
                    visited[nextY, nextX] = true;
                }
            }

        }
    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        string[] inputNM = Console.ReadLine().Split(' ');
        int n = int.Parse(inputNM[0]);
        int m = int.Parse(inputNM[1]);

        int[] goal = new int[2];
        int[,] board = new int[n,m];
        bool[,] visited = new bool[n,m];

        for (int y = 0; y < n; y++)
        {
            string[] inputArr = Console.ReadLine().Split(' ');
            int[] arr = new int[n];

            for (int x = 0; x < m; x++)
            {
                board[y, x] = int.Parse(inputArr[x]);
                if (board[y, x] == 2)
                {
                    goal[0] = x;
                    goal[1] = y;  
                }
            }
        }

        BFS(board, visited, goal);

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                if (visited[y, x] == false && board[y,x] == 1)
                    sb.Append(-1 + " ");
                else if(visited[y, x] == false && board[y, x] == 0)
                    sb.Append(0 + " ");
                else
                    sb.Append(board[y, x] + " ");
            }
            sb.Append("\n");
        }

        Console.WriteLine(sb.ToString());
    }
}
