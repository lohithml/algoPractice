using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class prisonCells
    {
        //Medium
    //957. Prison Cells After N Days
    //There are 8 prison cells in a row, and each cell is either occupied or vacant
    //Each day, whether the cell is occupied or vacant changes according to the following rules
    //If a cell has two adjacent neighbors that are both occupied or both vacant, then the cell becomes occupied.
    //Otherwise, it becomes vacant.
    //(Note that because the prison is a row, the first and the last cells in the row can't have two adjacent neighbors.)
    //We describe the current state of the prison in the following way: cells[i] == 1 if the i-th cell is occupied, else cells[i] == 0.
    //Given the initial state of the prison, return the state of the prison after N days (and N such changes described above.)
    //Example 1:
    //Input: cells = [0,1,0,1,1,0,0,1], N = 7
    //Output: [0,0,1,1,0,0,0,0]
    //Explanation: 
    //The following table summarizes the state of the prison on each day:
    //Day 0: [0, 1, 0, 1, 1, 0, 0, 1]
    //Day 1: [0, 1, 1, 0, 0, 0, 0, 0]
    //Day 2: [0, 0, 0, 0, 1, 1, 1, 0]
    //Day 3: [0, 1, 1, 0, 0, 1, 0, 0]
    //Day 4: [0, 0, 0, 0, 0, 1, 0, 0]
    //Day 5: [0, 1, 1, 1, 0, 1, 0, 0]
    //Day 6: [0, 0, 1, 0, 1, 1, 0, 0]
    //Day 7: [0, 0, 1, 1, 0, 0, 0, 0]

    //Example 2:
    //Input: cells = [1,0,0,1,0,0,1,0], N = 1000000000
    //Output: [0,0,1,1,1,1,1,0] 

    //Note:
    //cells.length == 8
    //cells[i] is in {0, 1}
    //1 <= N <= 10^9
        public int[] PrisonAfterNDays(int[] cells, int N)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            int prev = 0;
            int j = 0;
            while (j < N)
            {
                for (int i = 0; i < cells.Length; i++)
                {
                    if (i == 0 || i == cells.Length - 1)
                    {
                        prev = cells[i];
                        cells[i] = 0;
                    }
                    else
                    {
                        int sum = prev + cells[i + 1];
                        prev = cells[i];
                        cells[i] = sum == 1 ? 0 : 1;
                    }
                }
                 string state = string.Join(",", cells);
                if (map.ContainsKey(state))
                {
                    // A cycle was seen! since we know this cycle exists, we can safely fastforward for the number of days that have
                    // passed from the beginning of the cycle to the current.
                    // For example:
                    // Day 999 = [0,1,1,0,0,0,0,0]
                    // Day 986 = [0,1,1,0,0,0,0,0]
                    // When we go to process day 985 we notice the previous day, 986, was already seen on day 999. This
                    // means we can skip ahead by however many days were between the first day this sequence was found and the 
                    // last day, because we know it will continue to repeat.
                    // N = 985 % (999 - 985) = 985 % 14 = 5
                    // Note: the cycle always appears to happen at 14 days:

                    int cycle = j - map[state];
                    N = (N - 1) % cycle;
                    j = -1; // We are doing j++ at the end so resetting it to 0
                    map.Clear();
                }
                else
                    map.Add(state, j);
                j++;
            }
            return cells;
        }

        //Time: O(K * min(N,2^K)) K- # of cells, N # of steps
        //O(K) each simulation
        //2^K steps in the worst case without fast forwarding
        //Space: O(K*2^K) 
    }
}