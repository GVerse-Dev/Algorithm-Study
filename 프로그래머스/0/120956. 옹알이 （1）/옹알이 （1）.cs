using System;

public class Solution {
  
        string[] target = { "aya", "ye", "woo", "ma" };

        public int solution(string[] babbling)
        {
            int answer = 0;
            
            foreach (var item in babbling)
            {
                if (Check(item))
                    answer++;
            }

            return answer;
        }

        public bool Check(string str)
        {
            var strTemp = str;
            
            while (true) 
            {
                bool remove = false;

                foreach (var item in target)
                {
                    if (strTemp.Length < item.Length)
                    {
                        continue;
                    }

                    var temp = strTemp.Substring(0, item.Length);
                     
                    if (temp.Equals(item)) 
                    {
                        strTemp = strTemp.Remove(0, item.Length);
                        remove = true;
                    }
                }

                if (remove)
                    continue;

                if (strTemp.Length <= 0)
                    return true;

                return false;
            }

            return false;
        }
}