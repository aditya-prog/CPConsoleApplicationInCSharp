namespace StackAndQueue
{
    //Here also Time complexity is O(1) and O(n) for Dequeue and Enqueue respectively and cannot be optimized further
    public class StackUsing1Queue
    {
        private Queue<int> queue;

        public StackUsing1Queue()
        {
            queue = new Queue<int>();
        }

        public void Push(int x)
        {
            // push in the queue
            queue.Enqueue(x);

            //pop all elements fron the queue which are infront of curr eleemnt x, and insert them again
            int numberOfElementsToPop = queue.Count - 1;

            //pop and reinsert all the elements next to x
            while (numberOfElementsToPop > 0)
            {
                int temp = queue.Dequeue();
                queue.Enqueue(temp);
                numberOfElementsToPop--;

            }

        }

        public int Pop()
        {
            // always pull from q2 because queue is always empty
            return queue.Dequeue();
        }

        public int Top()
        {
            return queue.Peek();
        }

        public bool Empty()
        {
            return queue.Count == 0;
        }
    }
}