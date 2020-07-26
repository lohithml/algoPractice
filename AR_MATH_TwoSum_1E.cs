using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_MATH_TwoSum_1E
    {
//Easy
//1.Given an array of integers, return indices of the two numbers such that they add up to a specific target
//You may assume that each input would have exactly one solution, and you may not use the same element twice.

//Example:
//Given nums = [2, 7, 11, 15], target = 9,
//Because nums[0] + nums[1] = 2 + 7 = 9,
//return [0, 1].

        public int[] TwoSum(int[] nums, int target)
        {
            int[] res = new int[2];
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    res[0] = dict[complement];
                    res[1] = i;
                    return res;
                }

                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], i);
            }
            return res;
        }

        //Time: O(N)
        //Space: O(N)

        public List<int[]> TwoSumDup(int[] nums, int target)
        {
            List<int[]> res = new List<int[]>();

            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (dict.ContainsKey(complement))
                    res.Add(new int[] { dict[complement], i });

                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], i);
            }
            return res;
        }

        //if you want to print sum numbers, you can use below function...not for indeces- after sorting the indeces wioll change
        //public int[] TwoSumFunctionCTCI(int[] nums, int target)
        //{
        //    int[] res = new int[2];

        //    Array.Sort(nums);
        //    int first = 0, last = nums.Length-1;
        //    while (first < last)
        //    {
        //        int sum = nums[first] + nums[last];
        //        if (sum == target)
        //            return new int[]{first,last+1};
        //        else
        //        {
        //            if (sum < target)
        //                first++;
        //            else
        //                last--;
        //        }
        //    }

        //    return res;
        //}

        //Notes:
        //      usage of Dictionary
        //Dictionary<int,int>

        //Dictionary[complement] ==> is an integer and it is index of the array	
        //i is the index

        //nums[i] is also an integer. Its the value of the array

        //Checking whether some key is present.
        //                            if(!dict.ContainsKey(nums[i]))
        //                dict.Add(nums[i], i);

        //since this is exactly one solution, we can return the value

        //if there are duplicates, then create a list/dictionary and add the values to that list as in CTCI book problem 16.24
    }
}