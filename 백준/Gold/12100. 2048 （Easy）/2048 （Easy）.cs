using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.Arm;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static long[,] LeftMove(long[,] board)
    {
        long[,] newBoard = new long[board.GetLength(0),board.GetLength(1)];
        Array.Copy(board, newBoard, board.Length);
        

        //좌 이동
        for (long i = 0; i < newBoard.GetLength(0); ++i)
        {
            //추출
            List<long> numbers = new List<long>();
            for (long j = 0; j < board.GetLength(1); ++j)
            {
                if(board[i,j] != 0)
                    numbers.Add(board[i, j]);
            }

            //합치기
            List<long> merge = new List<long>();
            for (int j = 0; j < numbers.Count;)
            {
                if (j + 1 < numbers.Count && numbers[j] == numbers[j + 1])
                {
                    merge.Add(numbers[j] + numbers[j + 1]);
                    j += 2;
                }
                else
                {
                    merge.Add(numbers[j]);
                    j++;
                }
            }

            //삽입
            for (int j = 0; j < board.GetLength(0); ++j)
            {
                newBoard[i,j] = j < merge.Count ? merge[j] : 0;
            }
        }

        return newBoard;
    }
    static long[,] RightMove(long[,] board)
    {
        long[,] newBoard = new long[board.GetLength(0), board.GetLength(1)];
        Array.Copy(board, newBoard, board.Length);

        //우 이동
        for (long i = 0; i < newBoard.GetLength(0); ++i)
        {
            //추출
            List<long> numbers = new List<long>();
            for (long j = 0; j < board.GetLength(1); ++j)
            {
                if (board[i, j] != 0)
                    numbers.Add(board[i, j]);
            }

            //합치기 역순
            List<long> merge = new List<long>();
            for (int j = numbers.Count - 1; j >= 0;)
            {
                if (j - 1 >= 0 && numbers[j] == numbers[j - 1])
                {
                    merge.Add(numbers[j] + numbers[j - 1]);
                    j -= 2;
                }
                else
                {
                    merge.Add(numbers[j]);
                    j--;
                }
            }

            //삽입 역순
            for (int j = 0; j < board.GetLength(0); ++j)
            {
                newBoard[i, board.GetLength(0) - j - 1] = j < merge.Count ? merge[j] : 0;
            }
        }

        return newBoard;
    }

    static long[,] UpMove(long[,] board)
    {
        long[,] newBoard = new long[board.GetLength(0), board.GetLength(1)];
        Array.Copy(board, newBoard, board.Length);
        //위 이동
        for (int i = 0; i < newBoard.GetLength(0); ++i)
        {
            //추출
            List<long> numbers = new List<long>();
            for (long j = 0; j < board.GetLength(1); ++j)
            {
                if (board[j, i] != 0)
                    numbers.Add(board[j, i]);
            }

            //합치기
            List<long> merge = new List<long>();
            for (int j = 0; j < numbers.Count;)
            {
                if (j + 1 < numbers.Count && numbers[j] == numbers[j + 1])
                {
                    merge.Add(numbers[j] + numbers[j + 1]);
                    j += 2;
                }
                else
                {
                    merge.Add(numbers[j]);
                    j++;
                }
            }

            //삽입
            for (int j = 0; j < board.GetLength(0); ++j)
            {
                newBoard[j, i] = j < merge.Count ? merge[j] : 0;
            }
        }
        return newBoard;
    }

    static long[,] DownMove(long[,] board)
    {
        long[,] newBoard = new long[board.GetLength(0), board.GetLength(1)];
        Array.Copy(board, newBoard, board.Length);
        //아래 이동
        for (int i = 0; i < newBoard.GetLength(0); ++i)
        {
            //추출
            List<long> numbers = new List<long>();
            for (long j = 0; j < board.GetLength(1); ++j)
            {
                if (board[j, i] != 0)
                    numbers.Add(board[j, i]);
            }

            //합치기 역순
            List<long> merge = new List<long>();
            for (int j = numbers.Count - 1; j >= 0;)
            {
                if (j - 1 >= 0 && numbers[j] == numbers[j - 1])
                {
                    merge.Add(numbers[j] + numbers[j - 1]);
                    j -= 2;
                }
                else
                {
                    merge.Add(numbers[j]);
                    j--;
                }
                    
            }

            //삽입 역순
            for (int j = 0; j < board.GetLength(0); ++j)
            {
                newBoard[board.GetLength(0) - j - 1, i] = j < merge.Count ? merge[j] : 0;
            }
        }
        return newBoard;
    }

    static long FindMax(long[,] board)
    {
        long max = 0;
        foreach (long i in board)
        {
            max = Math.Max(max, i);
        }

        return max;
    }

    static bool AreEqual(long[,] a, long[,] b)
    {
        if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            return false;

        for (long i = 0; i < a.GetLength(0); i++)
            for (long j = 0; j < a.GetLength(1); j++)
                if (a[i, j] != b[i, j])
                    return false;

        return true;
    }


    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[,] board = new long[n, n];
        long result = 0;
        for (int i = 0; i < n; ++i)
        {
            string[] input = Console.ReadLine().Split(" ");

            for (int j = 0; j < n; ++j)
            {
                board[i, j] = int.Parse(input[j]);
            }
        }

        Queue<(long[,], int)> queue = new Queue<(long[,], int)>();
        queue.Enqueue((board, 0));
        result = FindMax(board);
        while (queue.Count > 0)
        {
            (long[,], int level) curBoard = queue.Dequeue();

            if (curBoard.level >= 5)
                continue;

            long[,] newBoard = new long[board.GetLength(0), board.GetLength(1)];
            Array.Copy(curBoard.Item1, newBoard, curBoard.Item1.Length);

            //sb.AppendLine("CurBoard");
            //for (int i = 0; i < n; ++i)
            //{
            //    for (int j = 0; j < n; ++j)
            //    {
            //        sb.Append(newBoard[i, j] + " ");
            //    }
            //    sb.AppendLine();
            //}

            newBoard = LeftMove(curBoard.Item1);
            if (AreEqual(curBoard.Item1, newBoard) == false)
            {
                //sb.AppendLine("Left");
                //for (int i = 0; i < n; ++i)
                //{
                //    for (int j = 0; j < n; ++j)
                //    {
                //        sb.Append(newBoard[i, j] + " ");
                //    }
                //    sb.AppendLine();
                //}
                queue.Enqueue((newBoard, curBoard.level + 1));
                result = Math.Max(result, FindMax(newBoard));
            }

            newBoard = RightMove(curBoard.Item1);
            if (AreEqual(curBoard.Item1, newBoard) == false)
            {
                //sb.AppendLine("Right");
                //for (int i = 0; i < n; ++i)
                //{
                //    for (int j = 0; j < n; ++j)
                //    {
                //        sb.Append(newBoard[i, j] + " ");
                //    }
                //    sb.AppendLine();
                //}
                queue.Enqueue((newBoard, curBoard.level + 1));
                result = Math.Max(result, FindMax(newBoard));
            }


            newBoard = UpMove(curBoard.Item1);
            if (AreEqual(curBoard.Item1, newBoard) == false)
            {
                //sb.AppendLine("Up");
                //for (int i = 0; i < n; ++i)
                //{
                //    for (int j = 0; j < n; ++j)
                //    {
                //        sb.Append(newBoard[i, j] + " ");
                //    }
                //    sb.AppendLine();
                //}
                queue.Enqueue((newBoard, curBoard.level + 1));
                result = Math.Max(result, FindMax(newBoard));
            }


            newBoard = DownMove(curBoard.Item1);
            if (AreEqual(curBoard.Item1, newBoard) == false)
            {
                //sb.AppendLine("Down");
                //for (int i = 0; i < n; ++i)
                //{
                //    for (int j = 0; j < n; ++j)
                //    {
                //        sb.Append(newBoard[i, j] + " ");
                //    }
                //    sb.AppendLine();
                //}
                queue.Enqueue((newBoard, curBoard.level + 1));
                result = Math.Max(result, FindMax(newBoard));
            }
              

            //Console.WriteLine(sb.ToString());
            //sb.Clear();
        }
       

        Console.WriteLine(result.ToString());
        
    }

 
}
