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

            int check = 0;
            for (int j = 0;  j < inputStr.Length; ++j)
            {
                if (inputStr[j] == '(')
                    check++;
                else
                {
                    
                    check--;

                    if (check < 0)
                        break;
                }
            }

            if (check == 0)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }

    }

}

