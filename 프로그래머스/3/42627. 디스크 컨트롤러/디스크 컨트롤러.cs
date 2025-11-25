using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;


public class Solution {
    
     int currentTime = 0;
     int processTime = 0;
     int totalProcessTime = 0;
    
    public int solution(int[,] jobs)
    {
        int answer = 0;


     //작업의 소요시간이 짧은 것, 작업의 요청 시각이 빠른 것, 작업의 번호가 작은 것 순으로 우선순위가 높습니다.
     // 0초에 3초소요되는거,  1초에 9초 소요되는거 ,  3초에 5초 소요되는거 들어옴

     List<Temp> test = new List<Temp>();

     for(int i =0; i < jobs.GetLength(0); i++) 
     {
         test.Add(new Temp(i,jobs[i,0], jobs[i,1]));
     }

     List<Temp> orderedByRequestTimeList = test.OrderBy(o=>o.requestTime).ToList();
     List<Temp> bufferList = new List<Temp>();
     List<Temp> processList = new List<Temp>();


     while (true)
     {
         if (orderedByRequestTimeList.Count <= 0 && bufferList.Count <= 0 && processList.Count <= 0)
         {
             break;
         }
         
          //불필요한 시간 체크 
         if (processList.Count > 0)
{
    if (processList.First().processTime > processTime)
    {
        float gapProcess = processList.First().processTime - processTime;
        processTime += (int)gapProcess;
        currentTime += (int)gapProcess;
        continue;
    }
}


         AddBufferList(orderedByRequestTimeList, bufferList);
         AddProcessList(bufferList, processList);


         if (processList.Count > 0)
         {
             if (processList[0].processTime == processTime)
             {
                 totalProcessTime += (currentTime - processList[0].requestTime);

                 Console.WriteLine($"process done ##### {currentTime} - {processList[0].requestTime} = {currentTime - processList[0].requestTime}" );
                 processList.RemoveAt(0);


                 AddBufferList(orderedByRequestTimeList, bufferList);
                 AddProcessList(bufferList, processList);

             }
         }

         ++processTime;
         ++currentTime;
     }

     Console.WriteLine($"{totalProcessTime} /  {test.Count} = {totalProcessTime / test.Count}" );

     answer = totalProcessTime / test.Count;
     return answer;
    }
    
     void AddBufferList(List<Temp> orderedByRequestTimeList, List<Temp> bufferList)
{
    if (orderedByRequestTimeList.Count > 0)
    {
        for (int i = orderedByRequestTimeList.Count - 1; i >= 0; i--)
{
    if (orderedByRequestTimeList[i].requestTime <= currentTime)
    {
        bufferList.Add(orderedByRequestTimeList[i]);
        Console.WriteLine($"request [{orderedByRequestTimeList[i].number}] : {orderedByRequestTimeList[i].requestTime} : {orderedByRequestTimeList[i].processTime}");
        orderedByRequestTimeList.RemoveAt(i);
    }
    //else if (orderedByRequestTimeList[i].requestTime > currentTime)
    //    break;
}
    }
}

 void AddProcessList(List<Temp> bufferList, List<Temp> processList)
{
    if (processList.Count == 0)
    {
        processTime = 0;
        if (bufferList.Count > 0)
        {
            //현재 요청 리스트중 우선순위 재정렬
            var first = bufferList.OrderBy(a => a.processTime).ThenBy(b => b.requestTime).ThenBy(c => c.number).ToList().First();
            processList.Add(first);
            bufferList.Remove(first);
            Console.WriteLine($"------------ Start [{processList[0].number}] : {processList[0].requestTime} : {processList[0].processTime}");
        }
    }
}
    
    
    
}
public class Temp
{
    public int number;
    public int requestTime;
    public int processTime;

    public Temp(int a, int b, int c)
    {
        this.number = a;
        this.requestTime = b;
        this.processTime = c;
    }
}
