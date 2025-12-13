using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static void Main()
    {
        int inputNCnt = int.Parse(Console.ReadLine());

        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < inputNCnt; i++)
        {
            string[] inputNStr = Console.ReadLine().Split(' ');

            StringBuilder stringBuilder = new StringBuilder();

            switch (inputNStr[0])
            {
                case "push":
                    queue.Enqueue(int.Parse(inputNStr[1]));
                    break;
                case "pop":
                    stringBuilder.Append((queue.Count > 0 ? queue.Dequeue() : -1));
                    break;
                case "size":
                    stringBuilder.Append(queue.Count);
                    break;
                case "empty":
                    stringBuilder.Append((queue.Count > 0 ? 0 : 1));
                    break;
                case "front":
                    stringBuilder.Append((queue.Count > 0 ? queue.Peek() : -1));
                    break;
                case "back":
                    stringBuilder.Append((queue.Count > 0 ? queue.Last() : -1));
                    break;


                default:
                    break;
            }

            if(stringBuilder.Length > 0)
                Console.WriteLine(stringBuilder.ToString());
        }
     

    }

}

