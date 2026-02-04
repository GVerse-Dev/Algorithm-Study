using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static void Main()
    {
        string[] inputNM = Console.ReadLine().Split(" ");
        int n = int.Parse(inputNM[0]);
        int m = int.Parse(inputNM[1]);
        
        int[,] board = new int[n,n];
        for (int row = 0; row < n; row++)
        {
            string[] input = Console.ReadLine().Split(" ");
            for (int col = 0; col < input.Length; col++)
            {
                int value = int.Parse(input[col]);
                board[row, col] = value;
                int leftRightSquare = 0;
                if (row - 1 >= 0)
                    leftRightSquare = board[row - 1, col];

                int topBottomSquare = 0;
                if (col - 1 >= 0)
                    topBottomSquare = board[row, col - 1];

                int duplicateSquare = 0;
                if (row - 1 >= 0 && col - 1 >= 0)
                    duplicateSquare = board[row - 1, col - 1];

                board[row, col] += leftRightSquare + topBottomSquare - duplicateSquare;
            }
        }

        for (int i = 0; i < m; i++)
        {
            string[] position = Console.ReadLine().Split(" ");
            int col1 = int.Parse(position[1]) - 1;
            int row1 = int.Parse(position[0]) - 1;
            int col2 = int.Parse(position[3]) - 1;
            int row2 = int.Parse(position[2]) - 1;

            int leftRightSquare = 0;
            if (row1 - 1 >= 0)
                leftRightSquare = board[row1 - 1, col2];

            int topBottomSquare = 0;
            if (col1 - 1 >= 0)
                topBottomSquare = board[row2, col1 - 1];

            int duplicateSquare = 0;
            if (col1 - 1 >= 0 && row1 - 1 >= 0)
                duplicateSquare = board[row1 - 1, col1 - 1];

            int result = board[row2,col2] - leftRightSquare - topBottomSquare + duplicateSquare;

            sb.AppendLine(result.ToString());
        }




        Console.WriteLine(sb.ToString());
    }
}
