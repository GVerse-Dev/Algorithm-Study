using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Collections.Generic;

class BOJ
{


    // 쪼개진 보드를 체크
    static int Check(List<List<int>> list)
    {
        int target = list[0][0];

        for (int y =0; y<list.Count; ++y)
        {
            for (int x = 0; x < list.Count; ++x)
            {
                if (list[y][x] != target)
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

        List<List<int>> board = new List<List<int>>();

        Queue<List<List<int>>> queue = new Queue<List<List<int>>>();

        int white = 0;
        int blue = 0;
        for (int y = 0; y < inputN; y++)
        {
            string[] input = Console.ReadLine().Split(' ');
            board.Add(new List<int>());

            for (int x = 0; x < inputN; x++)
            {
                board[y].Add(int.Parse(input[x]));

            }
        }

        int n = inputN;
        queue.Enqueue(board);

        while (queue.Count > 0)
        {
            var papers = queue.Dequeue();

            n = papers.Count();

            //N까지 체크
            int value = Check(papers);

            //false 면 반으로 쪼개서 다시 인큐
            if (value == -1)
            {
                for (int yy = 0; yy < n; yy += (n / 2))
                {
                    for (int xx = 0; xx < n; xx += (n / 2))
                    {
                        List<List<int>> temp = new List<List<int>>();
                        for (int y = 0; y < (n / 2); y++)
                        {
                            temp.Add(new List<int>());
                            for (int x = 0; x < (n / 2); x++)
                            {
                                temp[y].Add(papers[y + yy][x + xx]); 
                            }
                        }

                        queue.Enqueue(temp);
                    }
                }

            }
            //true 면 그 값의 종이 + 1
            else
            {
                if (value == 1)
                {
                    blue++;
                }
                else if((value == 0))
                {
                    white++;
                }
            }
        }


        sb.AppendLine(white.ToString());
        sb.AppendLine(blue.ToString());

        Console.WriteLine(sb.ToString());
    }
}

