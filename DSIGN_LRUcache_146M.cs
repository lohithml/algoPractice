using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    //Medium
    //146.LRU Cache
    //Design and implement a data structure for Least Recently Used(LRU) cache.It should support the following operations: get and put.

    //get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    //put(key, value) - Set or insert the value if the key is not already present.When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

    //The cache is initialized with a positive capacity.

    //Follow up:
    //Could you do both operations in O(1) time complexity?

    //Example:
    //LRUCache cache = new LRUCache(2 /* capacity */ );

    //cache.put(1, 1);
    //cache.put(2, 2);
    //cache.get(1);       // returns 1
    //cache.put(3, 3);    // evicts key 2
    //cache.get(2);       // returns -1 (not found)
    //cache.put(4, 4);    // evicts key 1
    //cache.get(1);       // returns -1 (not found)
    //cache.get(3);       // returns 3
    //cache.get(4);       // returns 4

    public class DSIGN_LRUcache_146M
    {
        //Dictionary- O(1) operation for Get and Put
        //Linked List- O(1) operation for remove first occurance, add, addfirst, removelast

        //HashSet, List- O(N) operation for Add to the end
        //List- O(N) operation for remove first occurance
        //HashSet- O(1) operation for remove; O(N) operation for removewhere

        Dictionary<int, int> keyAndValue = new Dictionary<int, int>();
        Dictionary<int, LinkedListNode<int>> keyAndNode = new Dictionary<int, LinkedListNode<int>>();
        LinkedList<int> linkedList = new LinkedList<int>();
        int capacity;

        public DSIGN_LRUcache_146M(int capacity)
        {
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (!keyAndValue.ContainsKey(key))
            {
                return -1;
            }

            var result = keyAndValue[key];

            var node = keyAndNode[key];
            linkedList.Remove(node);
            linkedList.AddFirst(node);

            return result;
        }

        public void Put(int key, int value)
        {
            if (!keyAndValue.ContainsKey(key))
            {
                // new
                if (capacity == linkedList.Count)
                {
                    var last = linkedList.Last;
                    linkedList.RemoveLast();
                    keyAndValue.Remove(last.Value);
                    keyAndNode.Remove(last.Value);
                }

                linkedList.AddFirst(key);
                keyAndNode[key] = linkedList.First;
                keyAndValue[key] = value;
            }
            else
            {
                // update
                keyAndValue[key] = value;
                var node = keyAndNode[key];
                linkedList.Remove(node);
                linkedList.AddFirst(node);
            }
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}