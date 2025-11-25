using System;
using System.Linq;

public class Solution {
    public int solution(int[,] board) {
        int answer = 0;
        
        bool[,] safety = new bool[100,100];
        
        int[] dx = {0, 1, 1, 1, 0, -1, -1, -1};
        int[] dy = {-1,-1,0, 1, 1, 1, 0, -1};
        
        for(int y = 0; y<board.GetLength(1); ++y)
        {
            for(int x = 0; x<board.GetLength(0); ++x)
            {
                if(board[y,x] == 1)
                {
                    for(int i=0; i<8; ++i)
                    {
                        if(y + dy[i] < 0 || y + dy[i] > board.GetLength(1) - 1)
                            continue;
                        if(x + dx[i] < 0 || x + dx[i] > board.GetLength(0) - 1)
                            continue;
                        
                        if(board[y + dy[i], x + dx[i]] == 1)
                            continue;
                        
                        board[y + dy[i], x + dx[i]] = -1;
                    }
                }
            }
        }
        
        
         for(int y = 0; y<board.GetLength(1); ++y)
        {
            for(int x = 0; x<board.GetLength(0); ++x)
            {
                if(board[y,x] == 0)
                {
                    answer++; 
                }
            }
        }
        
        return answer;
    }
    
   

}