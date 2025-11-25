using System;
using System.Text;
class BOJ
{
    static void Main()
    {

        while(true) 
        {
            string[] inputArr = Console.ReadLine().Split(' ');
            int[] numArr = new int[inputArr.Length];

            if (inputArr[0] == "0" && inputArr[1] == "0" && inputArr[2] == "0")
            {
                break;
            }

            for (int i = 0; i < inputArr.Length; i++)
            {
                numArr[i] = int.Parse(inputArr[i]);
            }
            
            Array.Sort(numArr);
           

            if (numArr[2] * numArr[2] == ((numArr[1] * numArr[1]) + (numArr[0] * numArr[0])))
                Console.WriteLine("right");
            else
                Console.WriteLine("wrong");

        }
    }
}