using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static int DFS(int[,] board, bool[,] visited, int x, int y)
    {
        int[] dirX = { -1, 0, 1, 0 };
        int[] dirY = { 0, -1, 0, 1 };

        if (x < 0 || board.GetLength(1) <= x)
            return 0;
        if (y < 0 || board.GetLength(0) <= y)
            return 0;

        if (visited[y, x])
            return 0;

        visited[y, x] = true;

        if (board[y, x] == 1)
        {
            for (int i = 0; i < dirX.Length; i++)
            {
                DFS(board, visited, x + dirX[i], y + dirY[i]);
            }
            return 1;
        }

        return 0;
    }

    static int BFS(int[,] board, bool[,] visited, int x, int y)
    {
        int[] dirX = { -1, 0, 1, 0 };
        int[] dirY = { 0, -1, 0, 1 };

        Queue<(int curX, int curY)> queue = new Queue<(int curX, int curY)>();
        
        visited[y, x] = true;

        if (board[y, x] == 1)
        {
            queue.Enqueue((x, y));

            while (queue.Count > 0)
            {
                (int curX, int curY) pos = queue.Dequeue();

                if (board[pos.curY, pos.curX] == 1)
                {
                    for (int i = 0; i < dirX.Length; i++)
                    {
                        int moveX = pos.curX + dirX[i];
                        int moveY = pos.curY + dirY[i];

                        if (moveX < 0 || board.GetLength(1) <= moveX)
                            continue;
                        if (moveY < 0 || board.GetLength(0) <= moveY)
                            continue;

                        
                        if (board[moveY, moveX] == 1 && visited[moveY, moveX] == false)
                            queue.Enqueue((moveX, moveY));


                        visited[moveY, moveX] = true;
                    }
                }
            }

            return 1;
        }
        else
            return 0;
    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        int inputT = int.Parse(Console.ReadLine());
       
        for (int i = 0; i < inputT; ++i)
        {
            string[] inputMNK = Console.ReadLine().Split(' ');

            int m = int.Parse(inputMNK[0]);
            int n = int.Parse(inputMNK[1]);
            int k = int.Parse(inputMNK[2]);

            int[,] board = new int[n, m];
            bool[,] visited = new bool[n, m];

            int result = 0;

            for (int j = 0; j < k; ++j)
            {
                string[] inputXY = Console.ReadLine().Split(' ');
                int x = int.Parse(inputXY[0]);
                int y = int.Parse(inputXY[1]);

                board[y, x] = 1;
            }

            for (int targetX = 0; targetX < m; ++targetX)
            {
                for (int targetY = 0; targetY < n; ++targetY)
                {
                    if (visited[targetY, targetX] == false)
                    {
                        result += BFS(board, visited, targetX, targetY);
                    }
                }
            }


            sb.Append(result.ToString() + "\n");

        }



        Console.WriteLine(sb.ToString());
    }
}

