using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class InsertDeleteGet
    {
        //Medium
        //380
        //Insert Delete GetRandom O(1)
        //Design a data structure that supports all following operations in average O(1) time.

        //insert(val): Inserts an item val to the set if not already present.
        //remove(val): Removes an item val from the set if present.
        //getRandom: Returns a random element from current set of elements.Each element must have the same probability of being returned.
        //Example:
        //// Init an empty set.
        //RandomizedSet randomSet = new RandomizedSet();

        //        // Inserts 1 to the set. Returns true as 1 was inserted successfully.
        //        randomSet.insert(1);

        //// Returns false as 2 does not exist in the set.
        //randomSet.remove(2);

        //// Inserts 2 to the set, returns true. Set now contains [1,2].
        //randomSet.insert(2);

        //// getRandom should return either 1 or 2 randomly.
        //randomSet.getRandom();

        //// Removes 1 from the set, returns true. Set now contains [2].
        //randomSet.remove(1);

        //// 2 was already in the set, so return false.
        //randomSet.insert(2);

        //// Since 2 is the only number in the set, getRandom always return 2.
        //randomSet.getRandom();
        public class RandomizedSet
        {
            Dictionary<int, int> dict;
            List<int> lst;
            Random rand;

            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                dict = new Dictionary<int, int>();
                lst = new List<int>();
                rand = new Random();
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (!dict.ContainsKey(val))
                {
                    dict.Add(val, lst.Count);
                    lst.Add(val);
                    return true;
                }
                else
                    return false;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (dict.ContainsKey(val))
                {
                    //cache last element, get index of val
                    int lastEleInLst = lst[lst.Count - 1];
                    int valIndexInDict = dict[val];

                    //cross connection- lst[valIndexInDict]=lastEleInLst
                    //swap last element
                    lst[valIndexInDict] = lastEleInLst;
                    dict[lastEleInLst] = valIndexInDict;

                    //remove
                    lst.RemoveAt(lst.Count - 1);
                    dict.Remove(val);

                    return true;
                }
                else
                    return false;
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                return lst[rand.Next(lst.Count)];
            }
        }

        //Time-O(1) List's RemoveAt method is O(n), if you remove from random location. To overcome that, we swap the values between (randomIndex, lastIndex) and always remove the entry from the end of the list.
        //Space-O(N)

        /**
         * Your RandomizedSet object will be instantiated and called as such:
         * RandomizedSet obj = new RandomizedSet();
         * bool param_1 = obj.Insert(val);
         * bool param_2 = obj.Remove(val);
         * int param_3 = obj.GetRandom();
         */
    }
}

