namespace StackAndQueue
{
    // Time complexity is O(1) and O(n) for Dequeue and Enqueue respectively and cannot be optimized further
    public class StackUsing2Queue
    {
        private Queue<int> q1;
        private Queue<int> q2;

        public StackUsing2Queue()
        {
            q1 = new Queue<int>();
            q2 = new Queue<int>();
        }

        public void Push(int x)
        {
            // push in the empty queue i.e q1
            q1.Enqueue(x);

            // move all eleemnts from q2 to q1
            while (q2.Count != 0)
            {
                q1.Enqueue(q2.Peek());
                q2.Dequeue();
            }

            // swap q1 and q2
            var temp = new Queue<int>();
            temp = q1;
            q1 = q2;
            q2 = temp;

        }

        public int Pop()
        {
            // always pull from q2 because q1 is always empty
            int res = q2.Peek();
            q2.Dequeue();
            return res;
        }

        public int Top()
        {
            return q2.Peek();
        }

        public bool Empty()
        {
            return q2.Count == 0;
        }
    }
}