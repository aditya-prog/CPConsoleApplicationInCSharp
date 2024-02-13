namespace HeapDataStructureAndProblems;

public class MergeKSortedArrays
{
    private List<int> _res;
    private List<List<int>> _input;
    public void MergeKSortedArraysProb(List<List<int>> kArrays)
    {
        _input = kArrays;
        int k = kArrays.Count;
        // By default it is max heap, but use it as min heap
        var pq = new PriorityQueue<List<int>, int>();


        for (int i = 0; i < k; i++)
        {
            pq.Enqueue([kArrays[i][0], i, 0], kArrays[i][0]); // Element value, ith array, and 0th index
        }

        List<int> res = [];

        while (pq.Count != 0)
        {
            var temp = pq.Peek();
            res.Add(temp[0]); // push element in res
            pq.Dequeue();

            // Add next element in heap from the same array from where above temp element was popped
            int kthArray = temp[1];
            int idx = temp[2];

            // If next element exists then push in heap
            if (idx + 1 < kArrays[kthArray].Count)
            {
                pq.Enqueue([kArrays[kthArray][idx + 1], kthArray, idx + 1], kArrays[kthArray][idx + 1]);
            }

        }

        _res = res;
    }

    public List<List<int>> InitializeProblem()
    {
        // Initialize a list to hold the sorted arrays
        List<List<int>> listOfLists = new List<List<int>>();

        // Create a random number generator
        Random rand = new Random();

        // Generate 5 sorted arrays
        for (int i = 0; i < 3; i++)
        {
            // Generate a random length between 5 and 10
            int length = rand.Next(5, 6);

            // Generate a sorted array of random integers
            List<int> sortedArray = new List<int>();
            for (int j = 0; j < length; j++)
            {
                sortedArray.Add(rand.Next(100));
            }
            sortedArray.Sort();

            // Append the sorted array to the list of lists
            listOfLists.Add(sortedArray);
        }
        return listOfLists;
    }

    public void PrintInputOutput(){
        Console.WriteLine("Input : ");
        // Print the list of lists
        foreach (var array in _input)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Output is: ");

        foreach(var item in _res){
            Console.Write(item + " ");
        }
    }
}