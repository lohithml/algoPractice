using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    class TrappingRainWater
    {
        //Hard
        //42
        //Given n non-negative integers representing an elevation map where the width of each bar is 1, 
        //compute how much water it is able to trap after raining.

        //The above elevation map is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped. Thanks Marcos for contributing this image!

        //Example:
        //Input: [0,1,0,2,1,0,1,3,2,1,2,1]
        //Output: 6

            //LC way
        public int TrapLC(int[] height)
        {
            int ans = 0,left=0,right=height.Length-1,leftMax=0,rightMax=0;

            while(left<right)
            {
                if(height[left]<height[right])
                {
                    if (height[left] >= leftMax)
                        leftMax = height[left];
                    else
                        ans += leftMax - height[left];
                    left++;                    
                }
                else
                {
                    if (height[right] >= rightMax)
                        rightMax = height[right];
                    else
                        ans += rightMax - height[right];
                    right--;
                }
            }

            return ans;
        }

        
        //Time : O(N). Single iteration of O(n).
        //Space : O(1) extra space.Only constant space required for left, right, left_max and right_max.
    }
}
