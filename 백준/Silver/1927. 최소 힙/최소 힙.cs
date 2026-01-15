using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;

class BOJ
{

    static void HeapifyDown(List<int> heap, int curIdx)
    {
        if (heap.Count <= 1)
            return;

        int leftChild = (curIdx * 2) + 1;
        int rightChild = (curIdx * 2) + 2;

        int smallest = curIdx;

        if (leftChild < heap.Count&& heap[leftChild] < heap[smallest])
            smallest = leftChild;

        if (rightChild < heap.Count&& heap[rightChild] < heap[smallest])
            smallest = rightChild;

        if (heap[smallest] < heap[curIdx])
        {
            int temp = heap[smallest];
            heap[smallest] = heap[curIdx];
            heap[curIdx] = temp;

            HeapifyDown(heap, smallest);
        }

    }

    static void HeapifyUp(List<int> heap, int curIdx)
    {
        if (heap.Count <= 1)
            return;

        int parent = curIdx <= 1 ? 0 : (curIdx - 1) / 2 ;

        if (parent >= 0 && heap[parent] > heap[curIdx])
        {
            int temp = heap[curIdx];
            heap[curIdx] = heap[parent];
            heap[parent] = temp;

            HeapifyUp(heap, parent);
        }
       
    }


    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        int inputT = int.Parse(Console.ReadLine());

        var heap = new List<int>();

        for (int i = 0; i < inputT; i++)
        {
            int value = int.Parse(Console.ReadLine());

            if (value > 0)
            {
                heap.Add(value);
                HeapifyUp(heap, heap.Count - 1);
            }
            else
            {
                if (heap.Count > 0)
                {
                    sb.Append(heap[0] + "\n");
                    heap[0] = heap.Last();
                    heap.RemoveAt(heap.Count - 1);
                    HeapifyDown(heap, 0);
                }
                else
                    sb.Append(0 + "\n");
               
            }
        }

        Console.WriteLine(sb.ToString());
    }
}

