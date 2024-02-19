namespace SlidingWindow;

public class SlidingWindowsDriver
{
    public static void Drive()
    {
        // Test Slding window maximum
        int[] arr = [1,3,-1,-3,5,3,6,7];
        var slidemax = new SlidingWindowMaximum();
        Console.WriteLine("UsingMaxHeap... "+String.Join(" ", slidemax.MaxSlidingWindowUsingMaxHeap(arr, 3)));
        Console.WriteLine("UsingDeque....  "+String.Join(" ", slidemax.MaxSlidingWindowUsingDeque(arr, 3)));
    }
}
