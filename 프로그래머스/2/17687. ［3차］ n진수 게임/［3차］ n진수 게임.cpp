#include <string>
#include <vector>

using namespace std;
  void change(int inType, int inNumber, string* str) ;

  string solution(int n, int t, int m, int p) {
      string answer = "";
      string str = "";
      string temp = "";
      int num = 0;
      while (num <= t * m) 
      {
          str.clear();
          if (num > 0)
              change(n, num, &str);
          else
              str += '0';
          ++num;

          temp += str;
      }

      int index = p - 1;
      while(answer.length() < t)
      {
          answer += temp[index];
          index += m;
      }
      return answer;
  }

   void change(int inType, int inNumber, string* str) 
 {
     if ((inNumber / inType) < inType) 
     {
         if ((inNumber / inType) > 0) 
         {
             if ((inNumber / inType) > 9) {
                 *str += (char)((inNumber / inType) + 55);
             }
             else {
                 *str += to_string(inNumber / inType);
             }
         }
           
         if ((inNumber % inType) > 9) {
             *str += (char)((inNumber % inType) + 55);
         }
         else {
             *str += to_string(inNumber % inType);
         }
         return;
     }

     if ((inNumber / inType) > 0) {
         change(inType, (inNumber / inType), str);
         if ((inNumber % inType) > 9) {
             *str += (char)((inNumber % inType) + 55);
         }
         else {
             *str += to_string(inNumber % inType);
         }
     }
 }