namespace StackAndQueue
{
    public class QueueUsingStacks
    {
        private Stack<int> st1;
        private Stack<int> st2;
        public QueueUsingStacks()
        {
            st1 = new Stack<int>();
            st2 = new Stack<int>();
        }

        public void Push(int x)
        {
            // First make stack1  empty and then insert incoming elemnt to stack1
            while (st1.Count != 0)
            {
                st2.Push(st1.Peek());
                st1.Pop();
            }

            st1.Push(x);

            // Now reinsert all the elements from stack2 to stack1

            while (st2.Count != 0)
            {
                st1.Push(st2.Pop());
                
            }
        }

        public int Pop()
        {
            // pop from stack1 because other stack is just used for support role
           return st1.Pop();
        }

        public int Peek()
        {
            return st1.Peek();
        }

        public bool Empty()
        {
            return st1.Count == 0;
        }
    }
}