namespace HeapDataStructureAndProblems;

public class MedianFinder {
    private PriorityQueue<int, int> minHeap; // Right Partition
    private PriorityQueue<int, int> maxHeap; // Left partition 
    // If odd number of elements then left will have 1 greater element than right, else both will have equal number of  elements

    public MedianFinder() {
        minHeap = new PriorityQueue<int, int>();
        maxHeap = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        // First element should go in left partition that is max heap
        if(minHeap.Count+maxHeap.Count == 0){
            maxHeap.Enqueue(num, -num); // -num as priority here because bydefault Priority queue in .NET is minHeap
            return;
        }
        
        // Similar to median of two soretd array, where when left partition is empty
        // then consider -INF for left side and when right partition is empty
        // consider +INF on right side
        var leftMax = maxHeap.Count == 0 ? Int32.MinValue : maxHeap.Peek();
        var rightMin = minHeap.Count == 0 ? Int32.MaxValue : minHeap.Peek();
        
        if(minHeap.Count == maxHeap.Count){
            // num <= greatestLeft side element
            if(num <= leftMax || (num > leftMax && num <= rightMin)){
                maxHeap.Enqueue(num, -num); // insert curr num in left
            }
            else{
                var ele = minHeap.Dequeue();
                maxHeap.Enqueue(ele, -ele);

                minHeap.Enqueue(num, num);// insert current num in right
            }
        }
        else if(maxHeap.Count > minHeap.Count){
            if(num >= rightMin || (num < rightMin && num >= leftMax)){
                minHeap.Enqueue(num, num); // insert in right
            }
            else{
                var ele = maxHeap.Dequeue(); // pop from left and insert in right
                minHeap.Enqueue(ele, ele);

                maxHeap.Enqueue(num, -num); // insert in left
            }
        }
        else{
            if(num <= leftMax || (num > leftMax && num <=  rightMin)){
                maxHeap.Enqueue(num, -num); // insert in left
            }
            else{
                var ele = minHeap.Dequeue();
                maxHeap.Enqueue(ele, -ele);

                minHeap.Enqueue(num, num);
            }
        }
    }
    
    public double FindMedian() {
        if((minHeap.Count + maxHeap.Count)%2 == 0){
            return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
        }
        else{
            return maxHeap.Peek();
        }

    }

    public static void InvokeMedianFinderAndPrintOutput(){
            string[] nums = ["1", "2", "", "3", "4", "", "8", "", "6", "5", ""];

            Console.WriteLine($"Input is.... {Environment.NewLine}");
            foreach(var num in nums){
                Console.Write(num+" ");
            }
            Console.WriteLine();
            Console.WriteLine("Output is ..");

            MedianFinder medianFinder = new();
            foreach(var num in nums){
                if(!string.IsNullOrEmpty(num)){
                    medianFinder.AddNum(int.Parse(num));
                }
                else{
                    var res = medianFinder.FindMedian();
                    Console.Write(res+" ");
                }
            }
            
            
    }

}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */