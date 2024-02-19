namespace SlidingWindow
{
    public class SlidingWindowMaximum
    {
        // Worst Time complexity O(NLogN)
        public int[] MaxSlidingWindowUsingMaxHeap(int[] nums, int k)
        {
            int n = nums.Length;
             // Total number of windows will be n-k+1;
            var res = new List<int>(n - k + 1);

            // index will be the TElement and nums[index] will be the TPriority
            var maxHeap = new PriorityQueue<int, int>();
           
            for (int i = 0; i < k; i++)
            {
                // Priority is prefixed with -1, because we want a maxheap
                maxHeap.Enqueue(i, -nums[i]);
            }

            res.Add(nums[maxHeap.Peek()]);

            //start with index k now
            for (int i = k; i < n; i++)
            {
                maxHeap.Enqueue(i, -nums[i]);
                // if topmost element is out of the range of curr sliding window, remove it.
                //Note: i-k+1 is the start index of curr window
                while (maxHeap.Peek() < i - k + 1)
                {
                    maxHeap.Dequeue();
                }
                // Add topmost element of queue which is within range of curr sliding window
                res.Add(nums[maxHeap.Peek()]);

            }
            return [.. res];
        }

        // Worst time complexity O(N);
        public int[] MaxSlidingWindowUsingDeque(int[] nums, int k){
            int n = nums.Length;
            var res= new List<int>(n-k+1);
            // Maintain a linked list of index and value
            var deque = new LinkedList<Tuple<int, int>>();

            // For first window alone simply add firt k elements in descending order
            for(int i=0; i<k; i++){
                RemoveAllEqualOrSmallerElementsFromRearOfQueue(deque, nums[i]);
                deque.AddLast(Tuple.Create(i, nums[i]));
            }
            // Add max of first sliding window
            res.Add(deque.First.Value.Item2); // Item2 is value , Item1 is index

            for(int i = k; i<n; i++){
                // Check if front elemnt of deque is out of range of curr window, if yes remove it.
                // Note: i-k+1 is start index of curr window
                if(deque.First.Value.Item1 < i-k+1){
                    deque.RemoveFirst();
                }

                // Insert elemnts of array at the end of the queue in desc order
                RemoveAllEqualOrSmallerElementsFromRearOfQueue(deque, nums[i]);
                deque.AddLast(Tuple.Create(i, nums[i]));

                // Front eleemnt is our result for curr window
                res.Add(deque.First.Value.Item2);
            }

            return [..res];
        }

        private void RemoveAllEqualOrSmallerElementsFromRearOfQueue(LinkedList<Tuple<int, int>> deque, int val)
        {
            while(deque.Count != 0 && deque.Last.Value.Item2 <= val){
                deque.RemoveLast();
            }
        }
    }
}

/*
    Dequeue Logic:
    Note: Maintain both index and value as a pair in the dequeue, because we need to know if fronmt
    1) Maintain a deque/DLL in desc order so that front element of queue is always the largest element
    2) Pop front of the queue if the front element is out of range of curr window
    3) Insert elemnts of array at the end of the queue but ensure that the queue still remains in desc order, so pop all
       elements from the end of queue(right of queue) which are less than or equal to curr incoming element
    3) Peek front element and add in res as front is the max element for curr window

*/