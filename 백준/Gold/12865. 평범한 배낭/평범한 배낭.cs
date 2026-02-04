using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();


    static void Main()
    {
        string[] inputNK = Console.ReadLine().Split(" ");
        ulong n = ulong.Parse(inputNK[0]);
        ulong k = ulong.Parse(inputNK[1]);

        Dictionary<ulong, ulong> dic = new Dictionary<ulong,ulong>();

        for (ulong i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" ");

            ulong weight = ulong.Parse(input[0]);
            ulong value = ulong.Parse(input[1]);

            if (weight > k)
                continue;

            var list = dic.ToList();

            foreach (var item in list)
            {
                ulong newWeight = item.Key + weight;
                ulong newValue = item.Value + value;

                if (newWeight > k)
                    continue;

                if (dic.ContainsKey(newWeight) == false)
                {
                    dic[newWeight] = newValue;
                }
                else
                {
                    if (dic[newWeight] < newValue)
                    {
                        dic[newWeight] = newValue;
                    }
                }
            }

            if (dic.ContainsKey(weight) == false)
            {
                dic[weight] = value;
            }
            else
            {
                if (dic[weight] < value)
                {
                    dic[weight] = value;
                }
            }
        }

        ulong result = 0;
        foreach (var item in dic)
        {
            if (item.Key <= k)
            {
                if (result < item.Value)
                    result = item.Value;
            }
        }

        Console.WriteLine(result.ToString());
    }
}
