namespace SlidingWindow;

public class SlidingWindowsDriver
{
    public static void Drive()
    {
        // 1.
        // Note conventional way to initialize array in c++/c# is {} and not []
        int[] arr = [1,3,-1,-3,5,3,6,7];
        var slidemax = new SlidingWindowMaximum();
        slidemax.MaxSlidingWindow(arr, 3);
    }
}
