namespace StackAndQueue
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class LFUCache
    {
        private readonly int capacity;
        private int minFreq;
        private readonly Dictionary<int, Tuple<int, int>> keyToValueAndFreq;
        private readonly Dictionary<int, LinkedList<int>> freqToKeys;
        private readonly Dictionary<int, LinkedListNode<int>> keyToNodeRef;

        public LFUCache(int capacity)
        {
            this.capacity = capacity;
            minFreq = 0;
            keyToValueAndFreq = new Dictionary<int, Tuple<int, int>>();
            freqToKeys = new Dictionary<int, LinkedList<int>>();
            keyToNodeRef = new Dictionary<int, LinkedListNode<int>>();
        }

        public int Get(int key)
        {
            if (!keyToValueAndFreq.ContainsKey(key)) return -1;

            int value = keyToValueAndFreq[key].Item1;
            IncreaseFrequency(key);
            return value;
        }

        public void Put(int key, int value)
        {
            if (capacity <= 0) return;

            if (keyToValueAndFreq.ContainsKey(key))
            {
                // Increse freq
                IncreaseFrequency(key);
                // Now update value
                keyToValueAndFreq[key] = Tuple.Create(value, keyToValueAndFreq[key].Item2);
                return;
            }

            // If cache is full, first evict one element
            if (keyToValueAndFreq.Count == capacity){
                EvictLeastFrequent();
            }
             
            // Now insert a new upcoming key into cache
            keyToValueAndFreq[key] = Tuple.Create(value, 1);
            if(!freqToKeys.TryGetValue(1, out LinkedList<int> keysList)){
                freqToKeys[1] = new LinkedList<int>();
            }
            freqToKeys[1].AddLast(key);
            keyToNodeRef[key] = freqToKeys[1].Last;
            minFreq = 1;
        }

        private void IncreaseFrequency(int key)
        {
            int val = keyToValueAndFreq[key].Item1;
            int freq = keyToValueAndFreq[key].Item2;

            // First remove the key, because its freq is changes
            freqToKeys[freq].Remove(keyToNodeRef[key]); // O(1)

            // Reinsert same key with incremented freq
            if(!freqToKeys.ContainsKey(freq+1)){
                freqToKeys[freq+1] = new LinkedList<int>();
            }
            freqToKeys[freq+1].AddLast(key);

            // Update node ref
            keyToNodeRef[key] = freqToKeys[freq+1].Last;
            //update freq in cache 
            keyToValueAndFreq[key] = Tuple.Create(val, freq+1);

            // if no keys for minFreq, then increment by 1
            if (!freqToKeys.ContainsKey(minFreq) || freqToKeys[minFreq].Count == 0){
                minFreq++;
            } 
        }

        private void EvictLeastFrequent()
        {
            var keysList = freqToKeys[minFreq];
            int keyToRemove = keysList.First.Value;
            keysList.RemoveFirst();
            keyToValueAndFreq.Remove(keyToRemove);
            keyToNodeRef.Remove(keyToRemove);
        }
    }


}

/*
###################
# ALGO DETAILS ####
###################

To implement a Least Frequently Used (LFU) cache in C++, we can use a combination of data structures
 to achieve the desired time complexity for the get and put operations.

Hash Map: We can use a hash map to store key-value pairs. This will allow us to quickly access
 values associated with keys.

Doubly Linked List: We can use a doubly linked list to maintain the frequency of access for
 each key. Each node of this linked list will represent a frequency, and within each node,
  we'll maintain a list of keys that have been accessed with that frequency.

Additional Hash Map for Key Lookup: Along with the doubly linked list, we'll use an additional 
hash map to keep track of where each key is present in the linked list. This will allow us 
to quickly locate and update the frequency of a key.

Here's a brief explanation of the algorithm:

For get operation:

If the key exists in the cache, we retrieve its value from the hash map and increment its frequency by 1.
If the key doesn't exist, we return -1.
For put operation:

If the key already exists in the cache, we update its value and increment its frequency by 1.
If the key doesn't exist:
If the cache has reached its capacity, we remove the least frequently used key(s) first. If there
is a tie, we remove the least recently used key.
We insert the new key-value pair, setting its frequency to 1.



*/