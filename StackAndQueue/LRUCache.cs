
namespace StackAndQueue
{
    // Maintain a dictionary of <int, Node> and a custom DLL with each node having key and value both
    public class LRUCache
    {
        private readonly int capacity;

        // Maintain a doubly Linked list(represented by head and tail) where node contains
        // key and value both
        private Node head = null;
        private Node tail = null;

        //Maintain a dict to store key and corresponding node of doubly LL
        private Dictionary<int, Node> dictionary; 
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            dictionary = new Dictionary<int, Node>();
        }

        public int Get(int key)
        {
            Node node;
            // If key doesn't exists return -1;
            if (!dictionary.TryGetValue(key, out node))
            {
                return -1;
            }

            // Get the value from node to return
            int res = node.val;

            // Before returning, update LRU eviction policy
            RemoveNodeFromDLL(node);
            AddNodeAtDLLEnd(node);
            return res;

        }

        public void Put(int key, int value)
        {
            Node node;
            // If key exists, update its value
            if (dictionary.TryGetValue(key, out node))
            {
                // update node value if node exists
                node.val = value; 

                // Also update LRU eviction policy
                RemoveNodeFromDLL(node);
                //same node is added back
                AddNodeAtDLLEnd(node);
            }
            else{
                // if key doesn't exists then add the key in dictionary as well as DLL

                var nodeToInsert = new Node(key, value);

                // if capacity available, directly insert at end of DLL
                if(dictionary.Count < capacity){
                    AddNodeAtDLLEnd(nodeToInsert);
                    AddInDictionary(key, nodeToInsert);
                }
                else{
                    // If no capacity, first evict one element from cache and then add new incoming element
                    int keyToRemove = RemoveNodeFromDLL(head);
                    RemoveFromDictionary(keyToRemove);

                    // Now add the incoming element to both dict and DLL
                    AddNodeAtDLLEnd(nodeToInsert);
                    AddInDictionary(key, nodeToInsert);
                }
            }
        }

        private void RemoveFromDictionary(int keyToRemove)
        {
            dictionary.Remove(keyToRemove);
        }

        private void AddInDictionary(int key, Node nodeToInsert)
        {
            dictionary[key] = nodeToInsert;
        }

        private int RemoveNodeFromDLL(Node node)
        { 
            int res = node.key;
            if(node.next == null && node.prev == null){
                head = tail = null;
            }
            else if(node == head){
                head.next.prev = null;
                head = head.next;
            }
            else if(node == tail){
                tail.prev.next = null;
                tail = tail.prev;
            }
            else{
                // if middle element
                node.next.prev = node.prev;
                node.prev.next = node.next;
            }

            return res;
        }

        private void AddNodeAtDLLEnd(Node nodeToInsert)
        {
            nodeToInsert.next = null;
            nodeToInsert.prev = null;
            // If empty 
            if(head == null){
                head = nodeToInsert;
                tail = nodeToInsert;
            }
            else{
                tail.next = nodeToInsert;
                nodeToInsert.prev = tail;
                tail = nodeToInsert;
            }
        }
    }

    public class Node
    {
        // Need to store both key and value, key is required because when we are deleteing a node from LL
        // we need to delete the corresaponding key from dictionary as well
        public int key;
        public int val;
        public Node next = null;
        public Node prev = null;
        public Node(int key, int val){
            this.key = key;
            this.val = val;
        }
    }
}