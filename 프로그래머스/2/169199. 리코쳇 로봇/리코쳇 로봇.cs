using System;
using System.Collections.Generic;
public class Solution {
   public int solution(string[] board)
{
    int answer = 0;
    bool[,] visited = new bool[100,100];
    Queue<((int y,int x) pos, int level)> queue = new Queue<((int y,int x) pos, int level)> ();

   var startPosition = GetTargetPosition(board,'R');
   var endPostion = GetTargetPosition(board, 'G');

    if ((startPosition.x == endPostion.x) && (startPosition.y == endPostion.y)) 
        { return 0; }

    queue.Enqueue(((startPosition.y,startPosition.x),0));

    while (queue.Count > 0) 
    {
        (int y, int x) movePos = (-1, -1);
        var current = queue.Dequeue();

        if (visited[current.pos.y,current.pos.x])
            continue;

        visited[current.pos.y, current.pos.x] = true;

        movePos = GetLeftMovePosition(board, current.pos);
        if (CheckPoint(movePos,endPostion)) { Console.Write(current.level + 1); return current.level + 1; }
        queue.Enqueue((movePos, current.level + 1));

        movePos = GetRightMovePosition(board, current.pos);
        if (CheckPoint(movePos, endPostion)) { Console.Write(current.level + 1); return current.level + 1; }
        queue.Enqueue((movePos, current.level + 1));
        
        movePos = GetUpMovePosition(board, current.pos);
        if (CheckPoint(movePos, endPostion)) { Console.Write(current.level + 1); return current.level + 1; }
        queue.Enqueue((movePos, current.level + 1));
        
        movePos = GetDownMovePosition(board, current.pos);
        if (CheckPoint(movePos, endPostion)) {  return current.level + 1; }
        queue.Enqueue((movePos, current.level + 1));
    }

    Console.Write("-1");
    return -1;
}

public bool CheckPoint((int y, int x) movePos, (int y, int x) endPosition)
{
    if ((movePos.x == endPosition.x) && (movePos.y == endPosition.y))
        return true;

    return false;
}

public (int y, int x) GetTargetPosition(string[] board, char target)
{
    for (int y = 0; y < board.Length; ++y)
    {
        for (int x = 0; x < board[y].Length; ++x)
        {
            if (board[y][x] == target)
            {
                return (y,x);
            }
        }
    }
    return (0,0);
}

public (int y, int x) GetLeftMovePosition(string[] board, (int y, int x) currentPostion)
{
    for (int x = currentPostion.x;  x >= 0;)
    {
        

        if (board[currentPostion.y][x] == 'D')
        {
            return (currentPostion.y, x + 1);
        }

        if (x <= 0)
        {
            return (currentPostion.y, 0);
        }
        x -= 1;
    }

    return currentPostion;
}

public (int y, int x) GetRightMovePosition(string[] board, (int y, int x) currentPostion)
{
    for (int x = currentPostion.x; x < board[currentPostion.y].Length;)
    {
       

        if (board[currentPostion.y][x] == 'D')
        {
            return (currentPostion.y, x - 1);
        }

        if (x >= board[currentPostion.y].Length - 1)
        {
            return (currentPostion.y, x);
        }
        x += 1;
    }

    return currentPostion;
}

public (int y, int x) GetUpMovePosition(string[] board, (int y, int x) currentPostion)
{
    for (int y = currentPostion.y; y >=  0;)
    {
       

        if (board[y][currentPostion.x] == 'D')
        {
            return (y + 1, currentPostion.x);
        }

        if (y <= 0)
        {
            return (y, currentPostion.x);
        }
        y -= 1;
    }

    return currentPostion;
}
public (int y, int x) GetDownMovePosition(string[] board, (int y, int x) currentPostion)
{
    for (int y = currentPostion.y; y < board.Length;)
    {
        if (board[y][currentPostion.x] == 'D')
        {
            return (y - 1, currentPostion.x);
        }

        if (y >= board.Length - 1)
        {
            return (y, currentPostion.x);
        }
        y += 1;
    }

    return currentPostion;
}
}