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

        for (int i = 0; i < inputNCnt + inputMCnt; ++i)
        {
            string inputName = Console.ReadLine();
            if (map.ContainsKey(inputName))
                map[inputName] = 2;
            else
                map[inputName] = 1;
        }

        StringBuilder sb = new StringBuilder();

        int cnt = 0;
        List<string> list = new List<string>();
        foreach(var item in map) 
        {
            if (item.Value == 2)
            {
                cnt++;
                list.Add(item.Key);
            }
        }
        list.Sort();
        sb.Insert(0, cnt + "\n");
        foreach (var item in list)
        {
            sb.Append(item + "\n");
        }
        Console.WriteLine(sb.ToString());

    }
}

