using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_MATH_meetingRoomII
    {
        //Medum
        //253
        //Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] 
        //(si < ei), 
        //find the minimum number of conference rooms required.

        //Example 1:
        //Input: [[0, 30],[5, 10],[15, 20]]
        //Output: 2

        //Example 2:
        //Input: [[7,10],[2,4]]
        //Output: 1

        public int MinMeetingRooms(int[][] intervals)
        {
            var arrStart = new int[intervals.Length];
            var arrEnd = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                arrStart[i] = intervals[i][0];
                arrEnd[i] = intervals[i][1];
            }

            Array.Sort(arrStart);
            Array.Sort(arrEnd);

            int st = 0, ed = 0, temp = 0, maxRoom = 0;

            while (st < arrStart.Length)
            {
                int cs = arrStart[st];
                int ce = arrEnd[ed];

                if (cs == ce)
                {
                    st++;
                    ed++;
                }
                else if (cs < ce)
                {
                    temp++;
                    st++;
                }
                else
                {
                    temp--;
                    ed++;
                }
                maxRoom = Math.Max(maxRoom, temp);
            }
            return maxRoom;
        }

        //Time: O(NlogN) for Array... O(N2) if we use List for sorting
        //Space: O(N)
    }
}
