using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_minCostSticks
    {
        //Medium
        //1167
        //Minimum Cost to Connect Sticks
        //You have some sticks with positive integer lengths.
        //You can connect any two sticks of lengths X and Y into one stick by paying a cost of X + Y.  
        //You perform this action until there is one stick remaining.
        //Return the minimum cost of connecting all the given sticks into one stick in this way.

        //Example 1:
        //Input: sticks = [2,4,3]
        //Output: 14

        //Example 2:
        //Input: sticks = [1,8,3,5]
        //Output: 30 

        //Constraints:
        //1 <= sticks.length <= 10^4
        //1 <= sticks[i] <= 10^4

        public int ConnectSticks(int[] sticks)
        {
            Array.Sort(sticks);
            var rawQ = new Queue<int>(sticks);
            var sumQ = new Queue<int>();
            int res = 0;

            while (rawQ.Count + sumQ.Count > 1)
            {
                int curCost = getMinPrice(rawQ, sumQ) + getMinPrice(rawQ, sumQ);
                sumQ.Enqueue(curCost);
                res += curCost;
            }
            return res;
        }

        int getMinPrice(Queue<int> rQ, Queue<int> sQ)
        {
            if (rQ.Count == 0) return sQ.Dequeue();
            if (sQ.Count == 0) return rQ.Dequeue();
            if (rQ.Peek() < sQ.Peek())
                return rQ.Dequeue();
            else
                return sQ.Dequeue();
        }

        //Time:O(N) for traversing the array... O(N^2) for sorting worst case
        //Space:O(N) storing the Queue
    }

}