namespace StackAndQueue
{
    // O(1) time and O(n) space
    public class MinStack
    {
        private Stack<int> stack;
        private Stack<int> minStack;
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            stack.Push(val);
            if (minStack.Count == 0 || minStack.Peek() >= val)
            {
                minStack.Push(val);
            }
            else
            {
                minStack.Push(minStack.Peek());
            }
        }

        public void Pop()
        {
            stack.Pop();
            minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }

    public class MinStackOptimized
    {
        private Stack<int> stack;
        private int min;
        public MinStackOptimized()
        {
            stack = new Stack<int>();
        }

        public void Push(int val)
        {
            if (stack.Count == 0)
            {
                min = val;
                stack.Push(val);
            }
            else if (val >= min)
            {
                stack.Push(val);
            }
            else
            {
                // if val is less than min, modfiy val to store in stack and update min
                stack.Push(2 * val - min); // Trick
                min = val;
            }
        }

        public void Pop()
        {
            //if min is greater than stack top then update the min and then pop
            if (stack.Peek() < min)
            {
                min = 2 * min - stack.Peek();
            }

            stack.Pop();

        }

        public int Top()
        {
            //if min is greater than stack top then min itself is the top
            if (stack.Peek() < min)
            {
                return min;
            }
            else
            {
                return stack.Peek();
            }
        }

        public int GetMin()
        {
            return min;
        }
    }
}