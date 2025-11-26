using System;
using System.Text;
class BOJ
{
    static void Main()
    {
        int inputN = int.Parse(Console.ReadLine());
        string[] inputShirtArr = Console.ReadLine().Split(' ');
        string[] inputBundleArr = Console.ReadLine().Split(' ');

        int[] shirtArr = new int[inputShirtArr.Length];
        int[] bundleArr = new int[inputBundleArr.Length];

        int t, p;
        int resultT = 0;

        for (int i = 0; i < inputShirtArr.Length; i++)
        {
            shirtArr[i] = int.Parse(inputShirtArr[i]);
        }
        for (int i = 0; i < inputBundleArr.Length; i++)
        {
            bundleArr[i] = int.Parse(inputBundleArr[i]);
        }

        t = bundleArr[0];
        p = bundleArr[1];

        for (int i = 0; i < shirtArr.Length; i++)
        {
            resultT += (shirtArr[i] / t);
            resultT += ((shirtArr[i] % t) > 0) ? 1 : 0;
        }


        Console.WriteLine(resultT);
        Console.WriteLine($"{inputN / p} {inputN % p}");
    }
}