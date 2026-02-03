using System.ComponentModel;
using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static Dictionary<string, (string leftChild, string RightChild)> keyValuePairs = new Dictionary<string, (string leftChild, string RightChild)>();

    static string FrontDFS(string node)
    {
        string result = "";

        if ((keyValuePairs.ContainsKey(node) == false))
            return string.Empty;

        result += node;
        result += FrontDFS(keyValuePairs[node].leftChild);
        result += FrontDFS(keyValuePairs[node].RightChild);

        return result;
    }

    static string MidDFS(string node)
    {
        string result = "";

        if ((keyValuePairs.ContainsKey(node) == false))
            return string.Empty;

        result += MidDFS(keyValuePairs[node].leftChild);
        result += node;
        result += MidDFS(keyValuePairs[node].RightChild);

        return result;
    }


    static string BackDFS(string node)
    {
        string result = "";

        if ((keyValuePairs.ContainsKey(node) == false))
            return string.Empty;

        result += BackDFS(keyValuePairs[node].leftChild);
        result += BackDFS(keyValuePairs[node].RightChild);
        result += node;


        return result;
    }

    static void Main()
    {
        int inputN = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputN; i++)
        {
            string[] input = Console.ReadLine().Split(" ");

            keyValuePairs[input[0]] = (input[1], input[2]);
        }

        sb.AppendLine(FrontDFS("A"));
        sb.AppendLine(MidDFS("A"));
        sb.AppendLine(BackDFS("A"));



        Console.WriteLine(sb.ToString());
    }
}
