using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    class slidingWindow
    {
        //Hard
        //239
        //Sliding Window Maximum
        //Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right.You can only see the k numbers in the window. Each time the sliding window moves right by one position. Return the max sliding window.

        //Follow up:
        //Could you solve it in linear time?

        //Example:
        //Input: nums = [1, 3, -1, -3, 5, 3, 6, 7], and k = 3
        //Output: [3,3,5,5,6,7]
        //Explanation: 

        //Window position                Max
        //---------------               -----
        //[1  3  -1] -3  5  3  6  7       3
        // 1 [3  -1  -3] 5  3  6  7       3
        // 1  3 [-1  -3  5] 3  6  7       5
        // 1  3  -1 [-3  5  3] 6  7       5
        // 1  3  -1  -3 [5  3  6] 7       6
        // 1  3  -1  -3  5 [3  6  7]      7

        //Constraints:
        //1 <= nums.length <= 10^5
        //-10^4 <= nums[i] <= 10^4
        //1 <= k <= nums.length

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;
            if (n * k == 0) return new int[0];

            int[] output = new int[n - k + 1];
            for (int i = 0; i < n - k + 1; i++)
            {
                int max = int.MinValue;
                for (int j = i; j < i + k; j++)
                    max = Math.Max(max, nums[j]);
                output[i] = max;
            }
            return output;
        }
        //Time complexity : O(N*(N-k+1)*K), where N is number of elements in the array.
        //Space complexity :O(N−k+1) for an output array.

        public int[] MaxSlidingWindow2(int[] nums, int k)
        {
            var res = new int[nums.Length - k + 1];

            if (nums.Length == 0 || nums == null || k == 0) return res;

            var window = new LinkedList<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                //remove element from head until first number within window
                if (window.Count > 0 && window.First.Value < i - (k - 1))
                    window.RemoveFirst();
                //remove from the tail list items with smaller value they nums[i]
                while (window.Count > 0 && nums[i] > nums[window.Last.Value])
                    window.RemoveLast();

                window.AddLast(i);

                //set the max value in the window always the top number
                if (i >= k - 1) res[i - (k - 1)] = nums[window.First.Value];
            }

            return res;
        }

        //Time: O(N), N is the length of the array
        //Space: O(N) O(N-K+1) is used for output   
        //https://leetcode.com/problems/sliding-window-maximum/discuss/66038/C-O(n)-time-and-space-with-doubly-linked-list

    }

}

