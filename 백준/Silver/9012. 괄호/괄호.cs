using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;

class BOJ
{

    static void Main()
    {
        int inputCnt = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < inputCnt; i++)
        {
            string inputStr = Console.ReadLine();
            Stack<char> chrs = new Stack<char>();

            bool check = true;
            for (int j = 0;  j < inputStr.Length; ++j)
            {
                if (inputStr[j] == '(')
                    chrs.Push(inputStr[j]);
                else
                {
                    if (chrs.Count < 1)
                    {
                        check = false;
                        break;
                    }

                    chrs.Pop();
                }
            }

            if (chrs.Count > 0)
            {
                check = false;
            }

            if(check)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }

        

    }

}

