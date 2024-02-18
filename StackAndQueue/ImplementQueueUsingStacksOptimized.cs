namespace StackAndQueue
{
    public class QueueUsingStacksOptimized
    {
        private Stack<int> st1;
        private Stack<int> st2;
        public QueueUsingStacksOptimized()
        {
            st1 = new Stack<int>();
            st2 = new Stack<int>();
        }

        public void Push(int x)
        {
            // Insert into stack1
            st1.Push(x);

        }

        public int Pop()
        {
            // Pop from stack2, if stack2 is empty then move all data from stack1 to stack2 and then Pop from stack2

            if (st2.Count != 0)
            {
                int res = st2.Peek();
                st2.Pop();
                return res;
            }
            else
            {
                while (st1.Count != 0)
                {
                    st2.Push(st1.Peek());
                    st1.Pop();
                }

                int res = st2.Peek();
                st2.Pop();
                return res;
            }

        }

        public int Peek()
        {
            // peek from stack2, if stack2 is empty then move all data from stack1 to stack2 and then peek from stack2

            if (st2.Count != 0)
            {
                return st2.Peek();

            }
            else
            {
                while (st1.Count != 0)
                {
                    st2.Push(st1.Peek());
                    st1.Pop();
                }

                return st2.Peek();
            }
        }

        public bool Empty()
        {
            return st2.Count == 0 && st1.Count == 0;
        }
    }
}