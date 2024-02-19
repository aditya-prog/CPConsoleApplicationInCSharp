namespace StackAndQueue
{
    public class LargestRectangleInHistogram
    {
        public int LargestRectangleArea(int[] heights)
        {
            int maxArea = 0;
            var nxtSmaller = GetNextSmaller(heights);
            var prevSmaller = GetPrevSmaller(heights);

            int n = heights.Length;
            // By observation , Final res will always contain atleast one block which is taken 
            // in full, so for each block we consider it full at once and compute area. And update 
            // max area which is our result
            for (int i = 0; i < n; i++)
            { 
                // ith block in consideration, so we need to ignore heights greeater than ith height for our
                // left and right area computation
                int leftArea = heights[i] * (i - prevSmaller[i] - 1);
                int midArea = heights[i];
                int rightArea = heights[i] * (nxtSmaller[i] - i - 1);

                maxArea = Math.Max(maxArea, leftArea + midArea + rightArea);
            }
            return maxArea;
        }

        private int[] GetNextSmaller(int[] heights)
        {
            int n = heights.Length;
            int[] res = new int[n]; // if no next smaller, then set nth index as next smaller element index
            for (int i = 0; i < n; i++)
            {
                res[i] = n;
            }

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                while (stack.Count != 0 && heights[i] < heights[stack.Peek()])
                {
                    int idx = stack.Pop();
                    res[idx] = i;
                }

                stack.Push(i);
            }

            return res;
        }

        private int[] GetPrevSmaller(int[] heights)
        {
            int n = heights.Length;
            int[] res = new int[n]; // if no prev smaller, then set -1 index as prev smaller element index
            for (int i = 0; i < n; i++)
            {
                res[i] = -1;
            }

            var stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count != 0 && heights[i] < heights[stack.Peek()])
                {
                    int idx = stack.Pop();
                    res[idx] = i;
                }

                stack.Push(i);
            }

            return res;
        }
    }
}