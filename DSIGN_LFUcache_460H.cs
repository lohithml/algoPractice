using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    //Hard
    //460
    //LFU Cache

    //Design and implement a data structure for Least Frequently Used(LFU) cache.
    //It should support the following operations: get and put.

    //get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    //put(key, value) - Set or insert the value if the key is not already present.When the cache reaches its capacity, it should invalidate the least frequently used item before inserting a new item.For the purpose of this problem, when there is a tie (i.e., two or more keys that have the same frequency), the least recently used key would be evicted.

    //Note that the number of times an item is used is the number of calls to the get and put functions for that item since it was inserted.This number is set to zero when the item is removed.

    //Follow up:
    //Could you do both operations in O(1) time complexity?

    public class LFUCache
    {
        int cap;
        int min;
        Dictionary<int, int> values;
        Dictionary<int, int> counts;
        Dictionary<int, LinkedList<int>> nodes;

        public LFUCache(int capacity)
        {
            cap = capacity;
            min = -1;
            values = new Dictionary<int, int>();
            counts = new Dictionary<int, int>();
            nodes = new Dictionary<int, LinkedList<int>>();
        }

        public int Get(int key)
        {
            if (!values.ContainsKey(key))
                return -1;

            //increment count
            int cur = counts[key];
            nodes[cur].Remove(key);

            //update freq
            if (min == cur && nodes[cur].Count == 0)
                min++;

            //update nodes
            counts[key] = cur + 1;
            if (!nodes.ContainsKey(cur + 1))
                nodes.Add(cur + 1, new LinkedList<int>());
            nodes[cur + 1].AddLast(key);

            return values[key];
        }

        public void Put(int key, int value)
        {
            if (cap <= 0) return;

            if (!values.ContainsKey(key))
            {
                //new            
                if (values.Count >= cap)
                {
                    //remove lfu
                    int lfuKey = nodes[min].First.Value;
                    nodes[min].RemoveFirst();
                    values.Remove(lfuKey);
                }
                min = 1;
                if (!nodes.ContainsKey(1))
                    nodes.Add(1, new LinkedList<int>());
                nodes[1].AddLast(key);
                counts[key] = 1;
            }
            else
            {
                //update
                //increment count
                int cur = counts[key];
                nodes[cur].Remove(key);

                //update freq
                if (min == cur && nodes[cur].Count == 0)
                    min++;

                //update nodes
                counts[key] = cur + 1;
                if (!nodes.ContainsKey(cur + 1))
                    nodes.Add(cur + 1, new LinkedList<int>());
                nodes[cur + 1].AddLast(key);
            }
            values[key] = value;
        }
    
    }

    //Time:O(1)
}