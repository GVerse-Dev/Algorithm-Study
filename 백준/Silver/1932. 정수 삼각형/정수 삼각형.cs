using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();
    static int inputN;
    static string[] input;

    
    static void Main()
    {
        inputN = int.Parse(Console.ReadLine());

        List<int>[] list = new List<int>[inputN];


        for (int i = 0; i < list.Length; i++)
        {
            list[i] = new List<int>();
        }

        for (int i = 0; i < inputN; ++i)
        {
            input = Console.ReadLine().Split(" ");

            for (int j = 0; j < input.Length; ++j) 
            {
                int cur = int.Parse(input[j]);

                if (i == 0)
                {
                    list[i].Add(cur);
                    continue;
                }
                    

                int leftParent = -1;
                int rightParent = -1;

                if (0 == j)
                {
                    rightParent = list[i - 1][j];
                }
                else if (input.Length - 1 == j)
                {
                    leftParent = list[i - 1][j - 1];
                }
                else
                {
                    leftParent = list[i - 1][j - 1];
                    rightParent = list[i - 1][j];
                }

                int value = 0;

                if (rightParent > -1 && leftParent > -1)
                {
                    value = leftParent > rightParent ?  leftParent : rightParent;
                }
                else if (rightParent > -1)
                {
                    value = rightParent;
                }
                else
                {
                    value = leftParent;
                }

                list[i].Add(value + cur);

            }
        }

        int result = 0;
        foreach (int i in list[list.Length - 1])
        {
            if (result < i)
            {
                result = i;
            }
        }

        Console.WriteLine(result.ToString());
    }
}
