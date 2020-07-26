using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_MATH_MaxSubArray_53E
    {
        //Easy
        //53
        //Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum.
        //Example:
        //Input: [-2,1,-3,4,-1,2,1,-5,4],
        //Output: 6
        //Explanation: [4,-1,2,1] has the largest sum = 6.
        //Follow up:
        //If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.


        public int MaxSubArray(int[] nums)
        {
            int curSum = nums[0], maxSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                curSum = Math.Max(nums[i], curSum + nums[i]);
                maxSum = Math.Max(maxSum, curSum);

            }
            return maxSum;

        }
        

        //Time: O(N)
        //Space: O(1)

        public int MaxSubArrayFollowUp(int[] nums)
        {
            return FindMaxSubArray(nums, 0, nums.Length - 1);
        }

        private int FindMaxSubArray(int[] nums, int l, int r)
        {
            if (l == r)
            {
                return nums[l];
            }

            int pivot = (l + r) / 2;

            int leftSum = FindMaxSubArray(nums, l, pivot);
            int rightSum = FindMaxSubArray(nums, pivot + 1, r);
            int crossSum = CalculateCrossSum(nums, l, r, pivot);

            return Math.Max(leftSum, Math.Max(rightSum, crossSum));
        }

        private int CalculateCrossSum(int[] nums, int l, int r, int pivot)
        {
            if (l == r)
            {
                return nums[l];
            }

            int leftSumMax = int.MinValue;
            int leftSum = 0;
            for (int i = pivot; i >= l; i--)
            {
                leftSum += nums[i];
                leftSumMax = Math.Max(leftSumMax, leftSum);
            }

            int rightSumMax = int.MinValue;
            int rightSum = 0;
            for (int i = pivot + 1; i <= r; i++)
            {
                rightSum += nums[i];
                rightSumMax = Math.Max(rightSumMax, rightSum);
            }

            return leftSumMax + rightSumMax;
        }
   
        //Time: O(NlogN)
        //Space: O(logN)
    
    }
}