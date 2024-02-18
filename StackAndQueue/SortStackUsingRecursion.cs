namespace StackAndQueue
{
    public class SortAStack
    {
        public void SortStack(Stack<int> stack)
        {
            if (stack.Count <= 1)
            {
                return;
            }

            int temp = stack.Pop();
            SortStack(stack);
            Insert(stack, temp);
        }
        private void Insert(Stack<int> stack, int val)
        {
            // if incoming element is greater than stack top() or stack itself is empty, the directly insert
            if (stack.Count == 0 || val >= stack.Peek())
            {
                stack.Push(val);
                return;
            }

            // pop top eleemnt from stack and save in a variable
            int temp = stack.Pop();
            // call insert with rest of stack and val to insert
            Insert(stack, val);

            // finally push the popped element
            stack.Push(temp);
        }

        public void PrintStack(Stack<int> st){
            foreach(var item in st){
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
    }
}