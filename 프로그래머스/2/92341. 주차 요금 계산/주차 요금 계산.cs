using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int[] solution(int[] fees, string[] records)
    {
        int[] answer = new int[] { };

        List<int> result = new List<int>();

        int nTime = fees[0];
        int nFee = fees[1];
        int pTime = fees[2];
        int pFee = fees[3];

        Dictionary<string, List<int>> inCars = new Dictionary<string, List<int>>();
        Dictionary<string, List<int>> outCars = new Dictionary<string, List<int>>();

        for(int i = 0; i < records.Length; ++i)
        {
            var time = records[i].Split(' ')[0];
            var carNumber = records[i].Split(' ')[1];
            var inOut = records[i].Split(' ')[2];

            if(inOut == "IN")
            {
                if(inCars.ContainsKey(carNumber) == false)
                    inCars.Add(carNumber, new List<int>());

                inCars[carNumber].Add(TimeToMin(time));
            }
            else
            {
                if (outCars.ContainsKey(carNumber) == false)
                    outCars.Add(carNumber, new List<int>());
                
                outCars[carNumber].Add(TimeToMin(time));
            }
        }


        foreach(var car in inCars.OrderBy(o=>int.Parse(o.Key)))
        {
            int carTotalFee = 0;
            int carTotleUseTime = 0;
            for (int i = 0; i< car.Value.Count; ++i)
            {
                 if (outCars.ContainsKey(car.Key) == false )
 {
     outCars.Add(car.Key, new List<int>());
 }
 if(outCars[car.Key].Count - 1 < i)
 {
     outCars[car.Key].Add(TimeToMin("23:59"));
 }
                    

                int inCarTTM = car.Value[i];
                int outCarTTM = outCars[car.Key][i];
                carTotleUseTime += outCarTTM - inCarTTM;

            }
            float overTTM = carTotleUseTime - nTime;
            float perPtime =  MathF.Ceiling(overTTM / (float)pTime);

            carTotalFee += (carTotleUseTime <= nTime) ? nFee : nFee + ((int)perPtime * pFee);

            Console.WriteLine(carTotalFee);

            result.Add(carTotalFee);
        }
        
        answer = result.ToArray();

        return answer;
    }

    public int TimeToMin(string time)
    {
        int hour = int.Parse(time.Split(':')[0]);
        int min = int.Parse(time.Split(':')[1]);

        return (hour * 60) + min;
    }
}