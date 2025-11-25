using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;


public class Solution
{
    Queue<(int[], int)> ints = new Queue<(int[], int)>();
    bool[,] visit = new bool[101 ,101];
    bool[,] map = new bool[101, 101];

    public int solution(int[,] rectangle, int characterX, int characterY, int itemX, int itemY)
    {
        int answer = 0;


        SetDouble(rectangle);
        SetMap(rectangle);

        ints.Enqueue((new int[] { characterX * 2, characterY * 2 }, 0));



        while (ints.Count > 0) 
        {
            var position = ints.Dequeue();
            
            var positionX = position.Item1[0];
            var positionY = position.Item1[1];
            var positionLevel = position.Item2;

            if (visit[positionX,positionY])
                continue;

            if (map[positionX, positionY])
                continue;

            visit[positionX, positionY] = true;

            Console.WriteLine($"visit {positionX},{positionY}, {positionLevel}");

            for (int i = 0; i < rectangle.GetLength(0); ++i)
            {
                int[] rect = new int[] { rectangle[i, 0], rectangle[i, 1], rectangle[i, 2], rectangle[i, 3] };

                //현재 캐릭터의 위치가 외곽인 도형이 있는가?
                if (IsOutside(rect, positionX, positionY))
                {
                    int[,] result = GetAvailablePosition(rect, positionX, positionY);
                  
                    ints.Enqueue((new int[] { result[0, 0], result[0, 1] }, positionLevel + 1));
                    ints.Enqueue((new int[] { result[1, 0], result[1, 1] }, positionLevel + 1));

                    Console.WriteLine($"\t goto {result[0, 0]},{result[0, 1]}, {positionLevel + 1}");
                    Console.WriteLine($"\t goto {result[1, 0]},{result[1, 1]}, {positionLevel + 1}");
                    if (result[0, 0] == itemX * 2 && result[0, 1] == itemY * 2)
                    {
                        Console.WriteLine((positionLevel + 1) / 2);
                        return (positionLevel + 1) / 2;
                    }
                        
                    if (result[1, 0] == itemX * 2 && result[1, 1] == itemY * 2)
                    {
                        Console.WriteLine((positionLevel + 1)/2);
                        return (positionLevel + 1) / 2;
                    }
                        
                }
            }
        }

        return answer;
    }

    public void SetDouble(int[,] rectangle)
    {
        for (int i = 0; i < rectangle.GetLength(0); ++i)
        {
            for(int j =0; j < rectangle.GetLength(1); ++j)
            {
                rectangle[i, j] *= 2;
            }
        }
    }

    public void SetMap(int[,] rectangle)
    {
        for(int i =0;i < rectangle.GetLength(0); ++i)
        {
            int x1 = rectangle[i, 0];
            int y1 = rectangle[i, 1];
            int x2 = rectangle[i, 2];
            int y2 = rectangle[i, 3];

            for (int x = x1 + 1; x < x2; ++x)
            {
                for(int y = y1 + 1; y < y2; ++y)
                {
                    map[x, y] = true;
                }
            }
        }
    }

    //현재위치에서 이동 가능한 위치 반환  (무조건 2개인가?)
    public int[,] GetAvailablePosition(int[] rectangle, int characterX, int characterY)
    {
        int x1 = 0, x2 = 0;
        int y1 = 0, y2 = 0;

        //4way
        //characterX, characterY + 1  상
        //characterX, characterY - 1  하
        //characterX - 1, characterY  좌
        //characterX + 1, characterY  우

        if ((characterX == rectangle[0] || characterX == rectangle[2]) && (rectangle[1] < characterY && characterY < rectangle[3]))
        {
            x1 = characterX; y1 = characterY + 1;       //상
            x2 = characterX; y2 = characterY - 1;       //하
        }
        else if ((characterY == rectangle[1] || characterY == rectangle[3]) && (rectangle[0] < characterX && characterX < rectangle[2]))
        {
            x1 = characterX - 1; y1 = characterY;       //좌
            x2 = characterX + 1; y2 = characterY;       //우
        }
        else
        {
            //상
            if ((characterY + 1 < rectangle[3]))
            {
                x1 = characterX; y1 = characterY + 1;       

                //좌
                if (characterX - 1 > rectangle[0])
                {
                    x2 = characterX - 1; y2 = characterY;       
                }
                //우
                else
                {
                    x2 = characterX + 1; y2 = characterY;       
                }
            }
            //하
            else
            {
                x1 = characterX; y1 = characterY - 1;
                 //좌
                if (characterX - 1 > rectangle[0])
                {
                    x2 = characterX - 1; y2 = characterY;       
                }
                //우
                else
                {
                    x2 = characterX + 1; y2 = characterY;       
                }
            }
        }
       



        return new int[,] { { x1,y1 },{ x2,y2 } };
    }

    //현재 위치가 도형의 외곽인지 반환
    public bool IsOutside(int[] rectangle, int characterX, int characterY)
    {
        if (rectangle[0] == characterX)
        {
            if (rectangle[1] <= characterY && rectangle[3] >= characterY) 
            {
                return true; 
            }
        }
        if(rectangle[2] == characterX)
        {
            if (rectangle[1] <= characterY && rectangle[3] >= characterY)
            {
                return true;
            }
        }
        if (rectangle[1] == characterY)
        {
            if (rectangle[0] <= characterX && rectangle[2] >= characterX)
            {
                return true;
            }
        }
        if (rectangle[3] == characterY)
        {
            if (rectangle[0] <= characterX && rectangle[2] >= characterX)
            {
                return true;
            }
        }

        return false;
    }
}
