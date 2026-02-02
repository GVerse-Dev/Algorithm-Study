using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();
    static string[] input;

    static ulong DFS(ulong a, ulong b, ulong c)
    {
        if (b == 0)
            return 1 % c;

        if (b == 1)
            return a % c;

        ulong result = 0;

        ulong temp = 0;
        if(b > 1)
            temp = DFS(a, b / 2, c);

        if (b % 2 == 0)
            result = (temp * temp) % c;
        else
            result = (((temp * temp) % c) * a) % c;

        return result;
    }

    static void Main()
    {
        input = Console.ReadLine().Split(" ");

        ulong a = ulong.Parse(input[0]);
        ulong b = ulong.Parse(input[1]);
        ulong c = ulong.Parse(input[2]);

        ulong result = DFS(a, b, c);

        Console.WriteLine(result.ToString());
    }
}
