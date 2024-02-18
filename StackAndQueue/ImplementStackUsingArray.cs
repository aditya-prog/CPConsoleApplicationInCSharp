namespace StackAndQueue{

    // While implementing stack and queue using array, ensure you initialize the array with fixed size
    // and use indexes like top, front, rear to get or set value in array rather than using add() or remove() methods
    public class ImplementStackUsingArray{
        private readonly int size;
        private readonly int[] arr;
        private int top;
        public ImplementStackUsingArray(int size){
            this.size = size;
            top = -1;
            arr = new int[size];
        }

        public void Push(int num){
            if(IsFull()){
                throw new Exception("Stack overflow exception...");
            }
            top++;
            arr[top] = num;
        }

        public int Peek(){
            if(IsEmpty()){
                return -1; // Nothing to return
            }

            return arr[top];
        }

        public int Pop(){
            if(IsEmpty()){
                throw new Exception("Stack is empty.."); // Nothing to return
            }

            return arr[top--];
        }

        public bool IsEmpty(){
            return top == -1;
        }

        public bool IsFull(){
            return top+1 == size;
        }
    }
}