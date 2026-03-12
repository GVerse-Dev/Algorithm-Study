using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;

class BOJ
{
    static StringBuilder sb = new StringBuilder();


    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        string[] str = Console.ReadLine().Split(" ");
        int[] ints = new int[n];
        
        List<int> numlist = new List<int>();
        List<int> numIndexlist = new List<int>();
        

        //입력값 세팅
        for (int i = 0; i < n; i++)
        {
            ints[i] = int.Parse(str[i]);
        }

        //이진 탐색으로 수열에 들어갈 위치 찾기
        for (int i = 0; i < n; ++i)
        {
            //BinarySearch 함수는 동일한 값의 인덱스를 반환하지만
            //없을 경우 들어갈 위치를 찾는다. (당연히 정렬이 기본상태라고 가정)
            int idx = numlist.BinarySearch(ints[i]);
            if (idx < 0)
                idx = ~idx;

            if(idx == numlist.Count)
                numlist.Add(ints[i]);
            else
                numlist[idx] = ints[i];


            numIndexlist.Add(idx);

        }

        //string result = "";
        List<int> list = new List<int>();

        int target = numlist.Count - 1;
        for (int i = numIndexlist.Count - 1; i >= 0;  --i)
        {
            if (numIndexlist[i] == target)
            {
                //이렇게 매번 새 문자열을 생성해서 붙이는건 비효율
                //result = ints[i].ToString() + " " + result;

                list.Add(ints[i]);
                target--;
            }
        }

        list.Reverse();
        for (int i = 0; i < list.Count; ++i)
        {
            sb.Append(list[i] + " ");
        }


        Console.WriteLine(numlist.Count.ToString());
        Console.WriteLine(sb.ToString());
    }
}