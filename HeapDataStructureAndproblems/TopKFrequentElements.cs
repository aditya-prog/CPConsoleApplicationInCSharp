namespace HeapDataStructureAndProblems;
public class TopKFrequentElements
{
    private int[] _res;
    private int[] _nums;
    private int k;

    public void TopKFrequent(int[] nums, int k)
    {
        _nums = nums;
        this.k = k;
        var dict = new Dictionary<int, int>();
        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                dict[nums[i]]++;
            }
            else
            {
                dict[nums[i]] = 1;
            }
        }

        // Minheap whose priority will be decided by freq of eleemnt
        var minHeap = new PriorityQueue<List<int>, int>();

        foreach (var item in dict)
        {

            // Insert first k element directly into queue
            if (minHeap.Count < k)
            {
                // / Key is the TElement and Value/freq is the TPriority
                minHeap.Enqueue([item.Key, item.Value], item.Value);
            }
            else
            {
                // Check if freq of top element of minHeap is less than incoming element freq
                if (minHeap.Peek()[1] < item.Value)
                {
                    minHeap.Dequeue();
                    minHeap.Enqueue([item.Key, item.Value], item.Value);
                }
            }

        }

        var res = new int[k];
        for (int i = 0; i < k; i++)
        {
            res[i] = minHeap.Dequeue()[0]; // we need to return the eleemnt and not freq
        }

        _res =  res;
    }

    public void PrintInputOutput(){
        Console.WriteLine("Input array is : ");
        // Print the list of lists
        foreach (var item in _nums)
        {
           Console.Write(item + " ");
        }
        Console.WriteLine($"{Environment.NewLine} K is : {k}");

        Console.WriteLine("Output is: ");

        foreach(var item in _res){
            Console.Write(item + " ");
        }
    }
}