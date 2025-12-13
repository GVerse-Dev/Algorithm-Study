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

        Stack<int> stack = new Stack<int>();



        for (int i = 0; i < inputNCnt; i++)
        {
            string[] inputNStr = Console.ReadLine().Split(' ');

            StringBuilder stringBuilder = new StringBuilder();

            switch (inputNStr[0])
            {
                case "push":
                    stack.Push(int.Parse(inputNStr[1]));
                    break;
                case "pop":
                    stringBuilder.Append((stack.Count > 0 ? stack.Pop() : -1));
                    break;
                case "size":
                    stringBuilder.Append(stack.Count);
                    break;
                case "empty":
                    stringBuilder.Append((stack.Count > 0 ? 0 : 1));
                    break;
                case "top":
                    stringBuilder.Append((stack.Count > 0 ? stack.Peek() : -1));
                    break;


                default:
                    break;
            }

            if(stringBuilder.Length > 0)
                Console.WriteLine(stringBuilder.ToString());
        }
     

    }

}

