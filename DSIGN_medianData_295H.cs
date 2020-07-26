using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class DSIGN_medianData
    {
        //Hard
        //295
        //Find Median from Data Stream
        //Median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value. 
        //So the median is the mean of the two middle value.

        //For example,
        //[2,3,4], the median is 3
        //[2,3], the median is (2 + 3) / 2 = 2.5
        //Design a data structure that supports the following two operations:
        //void addNum(int num) - Add a integer number from the data stream to the data structure.
        //double findMedian() - Return the median of all elements so far.
        //Example:
        //addNum(1)
        //addNum(2)
        //findMedian() -> 1.5
        //addNum(3) 
        //findMedian() -> 2 

        //Follow up:
        //If all integer numbers from the stream are between 0 and 100, how would you optimize it?
        //If 99% of all integer numbers from the stream are between 0 and 100, how would you optimize it?

        public class MedianFinder
        {
            List<int> Numbers;

            public MedianFinder()
            {
                Numbers = new List<int>();
            }

            public void AddNum(int num)
            {
                // Find where to insert this num in Numbers using Binary Search
                // NOTE: Binary Search is logarithmic time complexity O(logn) 
                int position = Numbers.BinarySearch(num);

                // So if BinarySearch returns -1 it means we should insert at the first position
                if (position < 0)                
                    position = ~position; // Bitwise complement of -1 is 0               

                Numbers.Insert(position, num);
            }

            public double FindMedian()
            {
                int count = Numbers.Count;
                if (count % 2 == 0)                
                    // Even number of elements
                    return (Numbers[count / 2 - 1] + Numbers[count / 2]) * 0.5;                
                else                
                    // Odd number of elements
                    return Numbers[count / 2];                
            }
        }

        //Time: O(logN)+ O(N)~ O(N) (Binary search + Insert)
        //Space: O(N) to hold the list
    
    }
}