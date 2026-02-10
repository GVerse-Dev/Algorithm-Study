using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();


    static void Main()
    {
        
        string inputA = Console.ReadLine();
        string inputB = Console.ReadLine();

        //4MB ?
        int[,] lcs = new int[1001, 1001];
        int result = 0;
        for (int i = 1; i <= inputA.Length; i++)
        {
            for (int j = 1; j <= inputB.Length; j++)
            {
                if (inputA[i - 1] == inputB[j - 1])
                {
                    lcs[i, j] = lcs[i - 1, j - 1] + 1;
                }
                else
                {
                    lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                }

                result = lcs[i, j];
            }
        }


        Console.WriteLine(result.ToString());
    }
}
