using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;


public class Solution {
    public int[] solution(string[,] places)
{
    int[] answer = new int[] {1,1,1,1,1 };
    //P는 응시자, O는 빈테이블, X는 파티션
    for(int i = 0; i < places.GetLength(0); ++i)
    {
        for(int y =0; y< places.GetLength(1); ++y)
        {
            for(int x = 0; x< places[i, y].Length; ++x)
            {
                if (places[i, y][x] == 'P')
                {
                    if (y > 0) 
                    { if (places[i, y - 1][x] == 'P') 
                        { answer[i] = 0; break; } }
                    if (y > 0 && y < places.GetLength(1) - 1) 
                    { if (places[i, y - 1][x] == 'P') 
                        { answer[i] = 0; break; } }
                    if (x > 0) 
                    { if (places[i, y][x - 1] == 'P') 
                        { answer[i] = 0; break; } }
                    if (x < places.GetLength(0) - 1) 
                    { if (places[i, y][x + 1] == 'P') 
                        { answer[i] = 0; break; } }
                    
                    
                    if (x  + 2 < places.GetLength(0) - 1)
{
    if (places[i, y][x + 2] == 'P')
    {
        if(places[i, y][x + 1] != 'X')
            answer[i] = 0; break;
    }
}
if (x - 2 > 0)
{
    if (places[i, y][x - 2] == 'P')
    {
        if (places[i, y][x - 1] != 'X')
            answer[i] = 0; break;
    }
}
if (y + 2 < places.GetLength(0) - 1)
{
    if (places[i, y + 2][x] == 'P')
    {
        if (places[i, y + 1][x] != 'X')
            answer[i] = 0; break;
    }
}
if (y - 2 > 0)
{
    if (places[i, y - 2][x] == 'P')
    {
        if (places[i, y - 1][x] != 'X')
            answer[i] = 0; break;
    }
}
                    
                    
                    
                    

                    if (y > 0 && x > 0)
                        if (places[i, y - 1][x - 1] == 'P')
                            if ((places[i, y - 1][x] != 'X') || (places[i, y][x - 1] != 'X'))
                            { answer[i] = 0; break; }

                    if (y < places.GetLength(1) - 1 && x > 0)
                        if (places[i, y + 1][x - 1] == 'P')
                            if ((places[i, y + 1][x] != 'X') || (places[i, y][x - 1] != 'X'))
                            { answer[i] = 0; break; }

                    if (y > 0 && x < places.GetLength(1) - 1)
                        if (places[i, y - 1][x + 1] == 'P')
                            if ((places[i, y - 1][x] != 'X') || (places[i, y][x + 1] != 'X'))
                            { answer[i] = 0; break; }

                    if (y < places.GetLength(1) - 1 && x < places.GetLength(1) - 1)
                        if (places[i, y + 1][x + 1] == 'P')
                            if ((places[i, y + 1][x] != 'X') || (places[i, y][x + 1] != 'X'))
                            { answer[i] = 0; break; }
                }
            }

            if (answer[i] == 0)
                break;
        }
    }

    foreach(int i in answer)
        Console.WriteLine(i);

    return answer;
}
}