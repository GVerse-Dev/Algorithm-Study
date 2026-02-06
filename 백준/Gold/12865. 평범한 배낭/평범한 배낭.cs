using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();


    static void Main()
    {
        string[] inputNK = Console.ReadLine().Split(" ");
        int n = int.Parse(inputNK[0]);
        int k = int.Parse(inputNK[1]);

        int[] dp = new int[k + 1];

        for (int i = 1; i < n + 1; i++)
        {
            string[] input = Console.ReadLine().Split(" ");

            int weight = int.Parse(input[0]);
            int value = int.Parse(input[1]);

            //내 배낭의 최대 허용 무게 k가 입력으로 들어온 물건의 무게 weight 보다 커야지만 의미가있으니 
            //for문은 k 가 weight 보다 크거나 같아야한다.

            //기존의 방식대로 입력이 들어올 때마다 가능한 모든 경우의 무게들과 계산하면 불필요한 메모리와 연산이 추가되기 때문에
            //아래와 같은 계산을 적용하면 효율적으로 가능하다.
            //지금 물건의 무게를 제외한 무게의 가치 + 지금 물건의 무게의 가치 = > 지금 물건을 넣었을 때의 가치

            //역순으로 접근해야 앞에 있는 무게들의 가치를 중복으로 더하지 않는다
            //배낭의 무게는 7이고, 물건은 무게가 3인 하나만 있다고 가정해보자.
            //역방향으로 하지 않고 정방향으로 한다면, 무게가 6일 때를 본다면 dp[3] + dp[3] 이 되기 때문에 같은 물건이 2번 들어가게 된다.
            for (int j = k; j >= weight; j--)
            {
                if (dp[j - weight] + value > dp[j])
                {
                    dp[j] = dp[j - weight] + value;
                }
            }

           
        }

        int result = 0;
        foreach (var item in dp)
        {
            if (result < item)
                result = item;
        }

        Console.WriteLine(result.ToString());
    }
}
