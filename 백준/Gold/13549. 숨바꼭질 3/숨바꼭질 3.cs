using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();


    static void Main()
    {
        string[] inputNK = Console.ReadLine().Split(" ");
        int n = int.Parse(inputNK[0]);
        int k = int.Parse(inputNK[1]);
        int result = 100000;
        Queue<(int x, int sec)> q = new Queue<(int, int)>();
        Dictionary<int , int> keyValuePairs = new Dictionary<int, int>();

        q.Enqueue((n, 0));

        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            
            if (cur.x == k)
            {
                result = cur.sec;
                break;
            }

            int newX = cur.x;
            int newSec = cur.sec;
            int[] dirX = { cur.x, 1, -1 };
            int[] dirSec = {0, 1, 1 };

            for (int i = 0; i < dirX.Length; i++)
            {
                newX = cur.x + dirX[i];
                newSec = cur.sec + dirSec[i];

                if (newX == k)
                {
                    if (result > newSec)
                        result = newSec;
                }
                else
                {
                    if (newX >= 0 && newX <= 100001)
                    {
                        if (keyValuePairs.ContainsKey(newX))
                        {
                            if (keyValuePairs[newX] > newSec)
                            {
                                q.Enqueue((newX, newSec));
                                keyValuePairs[newX] = newSec;
                            }
                        }
                        else
                        {
                            q.Enqueue((newX, newSec));
                            keyValuePairs[newX] = newSec;
                        }
                    }
                }
            }
        }

        Console.WriteLine(result.ToString());
    }
}
