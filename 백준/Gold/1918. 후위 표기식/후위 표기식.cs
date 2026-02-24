using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();

    static void Main()
    {
        Stack<char> stack = new Stack<char>();

        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                {
                    sb.Append(stack.Pop());
                }
                stack.Pop();
            }
            else if (input[i] == '(')
            {
                stack.Push(input[i]);
            }
            else if ('A' <= input[i] && input[i] <= 'Z')
            {
                sb.Append(input[i]);
            }
            else
            {
                //먼저 처리해야할 것을 꺼내준다.
                while (stack.Count > 0 && Priority(stack.Peek()) >= Priority(input[i]))
                {
                    sb.Append(stack.Pop());
                }
                stack.Push(input[i]);
            }
        }

        while (stack.Count > 0)
        {
            char c = stack.Pop();

            sb.Append(c);
        }


        Console.WriteLine(sb.ToString());
    }

    static int Priority(char c)
    {
        if (c == '*' || c == '/') return 2;
        if (c == '+' || c == '-') return 1;
        
        return 0;
    }
}
