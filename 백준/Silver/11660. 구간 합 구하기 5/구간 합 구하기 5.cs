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
        int[,] prefixSum = new int[n, n];
        for (int col = 0; col < n; col++)
        {
            string[] input = Console.ReadLine().Split(" ");
            for (int row = 0; row < input.Length; row++)
            {
                int value = int.Parse(input[row]);
                board[col, row] = value;
                int leftRightSquare = 0;
                if (col - 1 >= 0)
                    leftRightSquare = board[col - 1, row];

                int topBottomSquare = 0;
                if (row - 1 >= 0)
                    topBottomSquare = board[col, row - 1];

                int duplicateSquare = 0;
                if (col - 1 >= 0 && row - 1 >= 0)
                    duplicateSquare = board[col - 1, row - 1];

                board[col, row] += leftRightSquare + topBottomSquare - duplicateSquare;
            }
        }

        for (int i = 0; i < m; i++)
        {
            string[] position = Console.ReadLine().Split(" ");
            int col1 = int.Parse(position[0]) - 1;
            int row1 = int.Parse(position[1]) - 1;
            int col2 = int.Parse(position[2]) - 1;
            int row2 = int.Parse(position[3]) - 1;

            int leftRightSquare = 0;
            if (col1 - 1 >= 0)
                leftRightSquare = board[col1 - 1, row2];

            int topBottomSquare = 0;
            if (row1 - 1 >= 0)
                topBottomSquare = board[col2, row1 - 1];

            int duplicateSquare = 0;
            if (col1 - 1 >= 0 && row1 - 1 >= 0)
                duplicateSquare = board[col1 - 1, row1 - 1];

            int result = board[col2, row2] - leftRightSquare - topBottomSquare + duplicateSquare;

            sb.AppendLine(result.ToString());
        }




        Console.WriteLine(sb.ToString());
    }
}
