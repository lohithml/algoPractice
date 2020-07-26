
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class targetSum
    {
        //given the target value 
        //output the 2 indeces of array that gives that target value

        public void mainTwo()
        {
            //int[] n = { 0, 2, 2, 8 };
            int[] n={230,863,916,585,981,404,316,785,88,12,70,435,384,778,887,755,740,337,86,92,325,422,815,650,920,125,277,336,221,847,168,23,677,61,400,136,874,363,394,199,863,997,794,587,124,321,212,957,764,173,314,422,927,783,930,282,306,506,44,926,691,568,68,730,933,737,531,180,414,751,28,546,60,371,493,370,527,387,43,541,13,457,328,227,652,365,430,803,59,858,538,427,583,368,375,173,809,896,370,789};

            int[] o = new int[2];
            //o = twoSum(n, 4);
            o = twoSumDict(n, 542);
            if (o[0] == o[1])
                Console.WriteLine("Target sum is not possible");
            else
            {
                Console.WriteLine(o[0].ToString());
                Console.WriteLine(o[1].ToString());
            }
            Console.ReadKey();
        }
        public int[] twoSum(int[] nums, int target)
        {
            int[] res = new int[2] { 0, 0 };
            for (int i = 0; i < nums.Length; i++)
            {
                int j = nums[i];
                for (int m = i + 1; m < nums.Length; m++)
                {
                    int k = nums[m];
                    if (j + k == target)
                    {
                        res[0] = i;
                        res[1] = m;
                        return res;
                    }
                }
            }
            return res;
        }

        public int[] twoSumDict(int[] nums,int target)
        {
            int[] res = new int[2];
            Dictionary<int, int > dict = new Dictionary<int,int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                
                if (dict.ContainsKey(complement))
                    return new int[] { dict[complement],i};
                dict.Add(nums[i],i);
            }
           return res;
        }
    }
}