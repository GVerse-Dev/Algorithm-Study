using System.Diagnostics.CodeAnalysis;
using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();



    static void Main()
    {
        string[] inputNM = Console.ReadLine().Split();

        int ny = int.Parse(inputNM[0]);
        int mx = int.Parse(inputNM[1]);

        int[,] board = new int[ny + 1, mx + 1];
        bool[,,] visited = new bool[ny + 1, mx + 1, 2];

        int result = 1000000;

        for (int i = 1; i <= ny; i++)
        {
            string inputline = Console.ReadLine();

            for (int j = 1; j <= mx; j++)
            {
                board[i, j] = inputline[j - 1] - '0';
            }
        }

        int[] dx = new int[4] { -1, 0, 1, 0 };
        int[] dy = new int[4] { 0, -1, 0, 1 };

        Queue<(int y, int x, bool broken, int count)> queue = new Queue<(int y, int x, bool broken, int count)>();
        queue.Enqueue((1, 1, false, 1));

        while (queue.Count > 0)
        {
            (int y, int x, bool broken, int count) current = queue.Dequeue();

            if (current.x == mx && current.y == ny)
                if (result > current.count)
                    result = current.count;


            for (int i = 0; i < 4; ++i)
            {
                int newY = current.y + dy[i];
                int newX = current.x + dx[i];
                int curBrokenState = current.broken ? 1 : 0;
                if (newX == mx && newY == ny)
                {
                    if (result > current.count + 1)
                        result = current.count + 1;
                    break;
                }

                if ((newY > 0 && newY <= ny && newX > 0 && newX <= mx))
                {
                    //일반 미로에서 한번만 방문해도 되는 이유는
                    //어차피 도착한 위치에서 상하좌우 동일하기 때문에 다시 방문하지않아도 된다.

                    //벽을 하나 부실수 있는 미로는
                    //벽을 부수고 방문한건지, 그렇지 않고 방문한건지의 차이가 있기 때문에
                    //앞으로의 선택지가 달라진다. 상하좌우에서 또 다른 벽이 있을 때 그곳을 갈수 있을지 없을지
                    //정하는 미래가 달라지기 때문이다.

                    //현재 상태로 방문 체크를 해야하는이유 
                    //1.벽 안 부순 상태로(3, 3) 도착 → visited[3, 3, 0] = true
                    //2.벽 부순 상태로(3,3) 도착 → visited[3, 3, 0] 체크 → 이미 true → 스킵!

                    //일반
                    if (board[newY, newX] == 0)
                    {
                        //현재 상태로 방문했던적이 있는지
                        if (!visited[newY, newX, curBrokenState])
                        {
                            queue.Enqueue((newY, newX, current.broken, current.count + 1));
                            visited[newY, newX, curBrokenState] = true;
                        }
                    }
                    //벽
                    else
                    {
                        if (!visited[newY, newX, 1])
                        {
                            if (current.broken == false)
                            {
                                visited[newY, newX, 1] = true;
                                queue.Enqueue((newY, newX, true, current.count + 1));
                            }
                        }
                          
                    }
                }
            }
        }

        if (result == 1000000)
            result = -1;


        Console.WriteLine(result.ToString());
    }
}
