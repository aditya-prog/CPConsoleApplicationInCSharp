namespace StackAndQueue{
    public class ImplementQueueUsingArray{
        private readonly int capacity;
        private readonly int[] arr;
        private int front;
        private int rear;
        public ImplementQueueUsingArray(int capacity){
            front = -1;
            rear = -1;
            this.capacity = capacity;
            arr = new int[capacity];
        }

        public void Enqueue(int num){

            if(IsFull()){
                throw new Exception("Queue overflow...");
            }
            // If queue is empty , insert directly but increment front and rear both
            if(IsEmpty()){
                front = 0;
                rear = 0;
                arr[rear] = num;
                return;
            }
            
            rear = (rear+1)%capacity;
            arr[rear] = num;
        }

        public int Peek(){
            if(IsEmpty()){
                return -1;
            }
            return arr[front];
        }

        public int Dequeue(){
            if(IsEmpty()){
                throw new Exception("queue is empty.."); // Nothing to return
            }
            int res = arr[front];

            // if only one element , set to -1 to mark queue empty
            if(front == rear){
                front = rear = -1;
            }
            else{
                front = (front+1)%capacity;
            }
            return res;
        }

        public bool IsEmpty(){
            return (front == -1 && rear == -1);
        }

        public bool IsFull(){
            return (rear+1)%capacity == front;
        }
    }
}