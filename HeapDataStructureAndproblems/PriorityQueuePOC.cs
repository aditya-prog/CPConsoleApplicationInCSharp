using System;
using System.Collections.Generic;

namespace HeapDataStructureAndProblems
{
    public class PriorityQueuePOC
    {
        class IntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x > y)
                { // max heap
                    return -1;
                }
                return 1;
            }
        }

        public void MinHeapPQ()
        {
            // Creating a new priority queue with integer elements and integer priorities, by default min heap
            var pq = new PriorityQueue<int, int>();

            // Enqueueing elements with their priorities
            pq.Enqueue(3, 3);
            pq.Enqueue(1, 1);
            pq.Enqueue(4, 4);
            pq.Enqueue(2, 2);

            // Dequeueing elements
            while (pq.Count > 0)
            {
                // pq.Peek();
                var item = pq.Dequeue();
                Console.WriteLine($"Item: {item}");
            }
        }

        public void MaxHeapPQ()
        {
            // Creating a new priority queue with integer elements and integer priorities, by default min heap
            var pq = new PriorityQueue<int, int>(new IntComparer());

            // Enqueueing elements with their priorities
            pq.Enqueue(3, 3);
            pq.Enqueue(1, 1);
            pq.Enqueue(4, 4);
            pq.Enqueue(2, 2);

            // Dequeueing elements
            while (pq.Count > 0)
            {
                var item = pq.Dequeue();
                Console.WriteLine($"Item: {item}");
            }
        }
    }
}

