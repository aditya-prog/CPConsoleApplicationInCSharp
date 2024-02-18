
namespace StackAndQueue
{
    public class Next_Prev_Greater_Smaller
    {
        // Note in general when it is next greater / next smaller , then tarverse from left to right
        // if prev greater / prev smaller the traverse from right to left
        public int[] NextGreaterElement(List<int> arr)
        {
            int n = arr.Count;
            var res = new int[n];
            for(int i=0; i<n; i++){
                res[i] = -1;
            }
            var st = new Stack<int>();

            // start from left side
            for (int i = 0; i < n; i++)
            {
                // If curr incoming eleemnt is smaller or equal to stack top, saimply insert in stack
                // else curr element arr[i] is greter element for st.top() , so store curr ele in res
                while (st.Count != 0 && arr[i] > arr[st.Peek()])
                {
                    res[st.Peek()] = arr[i];
                    st.Pop();
                }

                st.Push(i);
            }

            return res;
        }

        public int[] PrevSmallerElement(List<int> arr)
        {
            int n = arr.Count;
            var res = new int[n];
            for(int i=0; i<n; i++){
                res[i] = -1;
            }
            var st = new Stack<int>();

            // start from right side
            for (int i = n - 1; i >= 0; i--)
            {
                // If curr incoming eleemnt is gretare or equal to stack top, saimply insert in stack
                // else curr element arr[i] is smaller element for st.top() , so store curr ele in res
                while (st.Count != 0 && arr[i] < arr[st.Peek()])
                {
                    res[st.Peek()] = arr[i];
                    st.Pop();
                }

                st.Push(i);
            }

            return res;
        }

        internal void Print(IEnumerable<int> arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item+" ");
            }

            Console.WriteLine();
        }
    }
}