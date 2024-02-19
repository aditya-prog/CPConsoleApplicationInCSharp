namespace StackAndQueue;

public class StackAndQueueDriver
{
    public static void Drive()
    {
        // 1.

        // var myStack = new ImplementStackUsingArray(5);
        // myStack.Push(3);
        // myStack.Push(2);
        // myStack.Push(4);   
        // Console.WriteLine(myStack.Peek()); 
        // Console.WriteLine(myStack.Pop());   
        // Console.WriteLine(myStack.Pop());   
        // myStack.Push(9);      
        // Console.WriteLine(myStack.Peek());  

        // 2.

        // var myQueue = new ImplementQueueUsingArray(6); 
        // myQueue.Enqueue(3);
        // myQueue.Enqueue(2);
        // myQueue.Enqueue(4);   
        // Console.WriteLine(myQueue.Peek()); 
        // Console.WriteLine(myQueue.Dequeue());   
        // Console.WriteLine(myQueue.Dequeue());   
        // myQueue.Enqueue(9);      
        // Console.WriteLine(myQueue.Peek());  

        //3.
        // int[] arr = [4,7, 2, 1, 87, 45, 23, 59, 65, 61];
        // var st = new Stack<int>(arr);
        // var stack = new SortAStack();
        // Console.WriteLine($"Stack Before Sorting {Environment.NewLine}");
        // stack.PrintStack(st);

        // stack.SortStack(st);

        // Console.WriteLine($"Stack After Sorting {Environment.NewLine}");
        // stack.PrintStack(st);

        // 4.
        // Console.WriteLine();
        // int[] arr = [4,7, 2, 1, 87, 45, 23, 59, 65, 61];
        // var prevNext = new Next_Prev_Greater_Smaller();
        // Console.WriteLine($"Given Input array.... ");
        // prevNext.Print(arr);

        // Console.WriteLine($"NextGreter element.... ");
        // prevNext.Print(prevNext.NextGreaterElement([..arr]));

        // Console.WriteLine($"PrevSmaller element....");
        // prevNext.Print(prevNext.PrevSmallerElement([..arr]));

        //Test LRUCache
        // int x = 0;
        // var lruCache = new LRUCache(2);
        // lruCache.Put(1,1);
        // lruCache.Put(2, 2);
        // x = lruCache.Get(1);
        // lruCache.Put(3, 3);
        // x = lruCache.Get(2);
        // lruCache.Put(4,4);
        // x = lruCache.Get(1);
        // x = lruCache.Get(3);
        // x = lruCache.Get(4);


        // Test LFUCache
        LFUCache cache = new LFUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        Console.WriteLine(cache.Get(1)); // Output: 1
        cache.Put(3, 3);
        Console.WriteLine(cache.Get(2)); // Output: -1 (Key 2 not found)
        Console.WriteLine(cache.Get(3)); // Output: 3
        cache.Put(4, 4);
        Console.WriteLine(cache.Get(1)); // Output: -1 (Key 1 not found)
        Console.WriteLine(cache.Get(3)); // Output: 3
        Console.WriteLine(cache.Get(4)); // Output: 4

        // Test LargestRectangleInHistogram
        var area = new LargestRectangleInHistogram();
        int[] heights = [2,1,5,6,2,3]; 
        area.LargestRectangleArea(heights);
    }
}
