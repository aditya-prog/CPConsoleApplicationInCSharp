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
        Console.WriteLine();
        int[] arr = [4,7, 2, 1, 87, 45, 23, 59, 65, 61];
        var prevNext = new Next_Prev_Greater_Smaller();
        Console.WriteLine($"Given Input array.... ");
        prevNext.Print(arr);

        Console.WriteLine($"NextGreter element.... ");
        prevNext.Print(prevNext.NextGreaterElement([..arr]));

        Console.WriteLine($"PrevSmaller element....");
        prevNext.Print(prevNext.PrevSmallerElement([..arr]));

        //5
        var lruCache = new LRUCache(5);
    }
}
