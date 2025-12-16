using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int inputNCnt = int.Parse(input[0]);
        int inputMCnt = int.Parse(input[1]);

        Dictionary<string, int> map = new Dictionary<string, int>();
        List<string> list = new List<string>();

        for (int i = 0; i < inputNCnt + inputMCnt; ++i)
        {
            string inputName = Console.ReadLine();
            if (map.ContainsKey(inputName))
                list.Add(inputName);

            map[inputName] = i;
        }

        StringBuilder sb = new StringBuilder();
        
        list.Sort();

        sb.Insert(0, list.Count + "\n");
        foreach (var item in list)
        {
            sb.Append(item + "\n");
        }
        Console.WriteLine(sb.ToString());

    }
}

