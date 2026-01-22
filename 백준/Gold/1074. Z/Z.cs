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

    static ulong DFS( ulong x, ulong y, ulong count ,ulong n, ulong r, ulong c)
    {

        ulong size = (ulong)(MathF.Pow(2, n));

        if (size > 2)
        {
            ulong newSize = size / 2;

            ulong newCount = newSize * newSize;
            ulong area = 0;
            //1~4사분면 재귀탐색
            for (ulong nextY = 0; nextY < 2; nextY++)
            {
                for (ulong nextX = 0; nextX < 2; nextX++)
                {
                    ulong newX = x + (nextX * newSize);
                    ulong newY = y + (nextY * newSize);

                    //x,y 가 범위를 벗어나면 탐색할 필요 없음
                    if ((newY < r && r > (newY + newSize)) || (newX < c && c > (newX + newSize)))
                    {
                        area++;
                        continue;
                    }

                    ulong result = DFS( x + (nextX * newSize), y + (nextY * newSize), count +  (newCount * area), n - 1, r, c);

                    if (result > 0)
                    {
                        return result;
                    }
                    area++;
                }
            }
           
        }

        for (ulong i = y; i < y + size; ++i)
        {
            for (ulong j = x; j < x + size; ++j)
            {
                if (i == r  && j == c )
                    return count;

                count++;
            }
        }

        return 0;
    }
  
    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        string[] inputNRC = Console.ReadLine().Split(' ');

        ulong n = ulong.Parse(inputNRC[0]);
        ulong r = ulong.Parse(inputNRC[1]);
        ulong c = ulong.Parse(inputNRC[2]);

        sb.Append(DFS(0, 0, 0, n, r, c));

        Console.WriteLine(sb.ToString());
    }
}
