using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    //행
    static bool[,] c1 = new bool[9, 10];

    //열
    static bool[,] c2 = new bool[9, 10];

    //스퀘어
    static bool[,] c3 = new bool[9, 10];

    static int[,] sudoku = new int[9, 9];

    static int square(int x, int y)
    {
        //x
        //0,1,2 = 0 //3,4,5 = 1  //6,7,8 = 2

        //y
        //0,1,2 = 0 //3,4,5 = 1  //6,7,8 = 2

        //square
        // 0(0,0) 1(1,0) 2(2,0)
        // 3(0,1) 4(1,1) 5(2,1)
        // 6(0,2) 7(1,2) 8(2,2)

        return (x / 3) + ((y / 3) * 3);
    }

    static bool DFS(int x, int y)
    {
        if (x >= 9 || y >= 9)
            return true;

        int nextX = (x + 1) % 9;
        int nextY = (nextX == 0) ? y + 1 : y;

        //이미 값이 들어가있다면 패스
        if (sudoku[y, x] != 0)
            return DFS(nextX, nextY);


        for (int num = 1; num <= 9; num++)
        {
            //행, 열, 스퀘어 모두 num 이 없다면
            if (!c1[y, num] && !c2[x, num] && !c3[square(x, y), num])
            {
                //문제가 없어보인다면 값을 넣고 
                c1[y, num] = true;
                c2[x, num] = true;
                c3[square(x, y), num] = true;
                sudoku[y, x] = num;

                //마지막이라면
                if (x == 8 && y == 8)
                    return true;

                //다음칸으로 이동해보고 문제가 없었다면
                if (DFS(nextX, nextY))
                    return true;
                //문제가 있었다면 초기화
                else
                {
                    c1[y, num] = false;
                    c2[x, num] = false;
                    c3[square(x, y), num] = false;
                    sudoku[y, x] = 0;
                }
            }
        }

        return false;
    }

    static void Main()
    {
        for (int y = 0; y < 9; y++)
        {
            string s = Console.ReadLine();

            for (int x = 0; x < 9; x++)
            {
                int num = s[x] - '0';
                
                sudoku[y, x] = num;

                if (num > 0)
                {
                    c1[y, num] = true;
                    c2[x, num] = true;
                    c3[square(x, y), num] = true;
                }
            }
        }

        DFS(0, 0);

        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                sb.Append(sudoku[y, x]);
            }
            sb.AppendLine();
        }


        Console.WriteLine(sb.ToString());
    }

 
}
