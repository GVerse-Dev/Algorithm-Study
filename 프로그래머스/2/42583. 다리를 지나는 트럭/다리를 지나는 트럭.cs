using System;
using System.Collections.Generic;
using System.Linq;

 public class Solution
 {
   public int solution(int bridge_length, int weight, int[] truck_weights)
{
    int time = 0;
    int truckIndex = 0;
    int currentWeight = 0; // 현재 다리 위 트럭들의 총 무게

    Queue<(int weight, int enterTime)> bridgeQueue = new Queue<(int, int)>();



    while (truckIndex < truck_weights.Count() || bridgeQueue.Count > 0) 
    {
        time++;

        if (bridgeQueue.Count > 0 && time >= bridgeQueue.Peek().enterTime + bridge_length)
        {
            currentWeight -= bridgeQueue.Dequeue().weight;
        }

        if (truckIndex < truck_weights.Length && weight >= currentWeight + truck_weights[truckIndex])
        {
            currentWeight += truck_weights[truckIndex];
            bridgeQueue.Enqueue((truck_weights[truckIndex], time));
            truckIndex++;
        }

       
    }

    Console.WriteLine(time);

    return time;
}

 }