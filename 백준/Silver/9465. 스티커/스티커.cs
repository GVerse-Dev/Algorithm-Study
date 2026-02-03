using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();
    

    static void Main()
    {
        int inputT = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputT; i++)
        {
            int inputN = int.Parse(Console.ReadLine());

            int[,] inputArr = new int[2,inputN];

            for (int j = 0; j < 2; ++j)
            {
                string[] input = Console.ReadLine().Split(" ");

                for (int k = 0; k < inputN; k++)
                {
                    inputArr[j,k] = int.Parse(input[k]);;
                }
            }

            if (inputN == 1)
            {
                sb.AppendLine(inputArr[0, inputN - 1] > inputArr[1, inputN - 1] ? inputArr[0, inputN - 1].ToString() : inputArr[1, inputN - 1].ToString());
                continue;
            }

            inputArr[0, 1] += inputArr[1, 0];
            inputArr[1, 1] += inputArr[0, 0];

            for (int k = 2; k < inputN; k++)
            {
                inputArr[0, k] += inputArr[1, k - 1] > inputArr[1, k - 2] ? inputArr[1, k - 1] : inputArr[1, k - 2];
                inputArr[1, k] += inputArr[0, k - 1] > inputArr[0, k - 2] ? inputArr[0, k - 1] : inputArr[0, k - 2];
            }


            sb.AppendLine(inputArr[0, inputN - 1] > inputArr[1, inputN - 1] ? inputArr[0, inputN - 1].ToString() : inputArr[1, inputN - 1].ToString());

        }



        Console.WriteLine(sb.ToString());
    }
}
