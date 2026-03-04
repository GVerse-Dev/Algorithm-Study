using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static int n;
    static int result ;
    static bool[] lineX ;
    static bool[] leftDiagonal;
    static bool[] rightDiagonal;

    static void DFS(int y)
    {
        if (y == n)
        {
            result++;
            return;
        }


        for (int x = 0; x < n; x++)
        {
            //row - col 이 같으면 같은 대각선
            //row + col 이 같으면 같은 대각선
            if (lineX[x] || leftDiagonal[y - x + n - 1] || rightDiagonal[y + x])
            {
                continue;
            }

            lineX[x] = true;
            leftDiagonal[y - x + n - 1] = true;
            rightDiagonal[y + x] = true;

            DFS(y + 1);

            lineX[x] = false;
            leftDiagonal[y - x + n - 1] = false;
            rightDiagonal[y + x] = false;
        }
    }

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        
        lineX = new bool[n];
        leftDiagonal = new bool[n * 2];
        rightDiagonal = new bool[n * 2];


        DFS(0);


        Console.WriteLine(result.ToString());
        
    }

 
}
