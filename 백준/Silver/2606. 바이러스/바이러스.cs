using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static int BFS(Dictionary<int, HashSet<int>> map)
    {
        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[101];

        int result = 0;
        queue.Enqueue(1);
        
        while (queue.Count > 0)
        {
            int value = queue.Dequeue();

            if (visited[value])
                continue;

            visited[value] = true;
            result++;

            foreach (int i in map[value])
            {
                queue.Enqueue(i);
            }
        }
        return result - 1;
    }

    static void Main()
    {
        int inputA = int.Parse(Console.ReadLine());
        int inputB = int.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();

        Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();


        for (int i = 0; i < inputB; i++)
        {
            string[] str = Console.ReadLine().Split();
            int key = int.Parse(str[0]);
            int value = int.Parse(str[1]);

            if (map.ContainsKey(key) == false)
                map[key] = new HashSet<int>();

            if (map.ContainsKey(value) == false)
                map[value] = new HashSet<int>();

            map[key].Add(value);
            map[value].Add(key);
        }

        if (map.ContainsKey(1))
            Console.WriteLine(BFS(map));
        else
            Console.WriteLine(0);
    }
}

