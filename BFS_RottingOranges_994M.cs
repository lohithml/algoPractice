using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    class BFS_RottingOranges
    {
        //Medium
        //994
        //In a given grid, each cell can have one of three values:

        //the value 0 representing an empty cell;
        //the value 1 representing a fresh orange;
        //the value 2 representing a rotten orange.
        //Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.

        //Return the minimum number of minutes that must elapse until no cell has a fresh orange.  
        //If this is impossible, return -1 instead.
        //Input: [[2,1,1],[1,1,0],[0,1,1]]
        //Output: 4

        //Input: [[0,2]]
        //Output: 0
        //Explanation:  Since there are already no fresh oranges at minute 0, the answer is just 0.

        public int OrangesRotting(int[][] grid)
        {
            int minute = -1, freshCnt = 0;
            int m = grid.Length, n = grid[0].Length;
            bool[,] visited = new bool[m, n];
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 2 && !visited[i, j])
                    {
                        queue.Enqueue(new int[] { i, j });
                        visited[i, j] = true;
                    }
                    else if (grid[i][j] == 1)
                        freshCnt++;
                }
            }

            if (freshCnt == 0)  return 0;

            int[,] dir = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            while (queue.Count > 0)
            {
                minute++;
                int size = queue.Count; //important to copy the value because queue.Count will change in below
                //for (int j = 0; j < size; j++)
               // {
                    var curr = queue.Dequeue();
                    for (int i = 0; i < 4; i++)
                    {
                        int nextRow = curr[0] + dir[i, 0];
                        int nextCol = curr[1] + dir[i, 1];

                        if (nextRow >= 0 && nextRow < m && nextCol >= 0 && nextCol < n && grid[nextRow][nextCol] == 1 && !visited[nextRow, nextCol])
                        {
                            grid[nextRow][nextCol] = 2;
                            queue.Enqueue(new int[] { nextRow, nextCol });
                            freshCnt--;                            
                            visited[nextRow, nextCol] = true;
                        }
                    }
               // }
            }
            return freshCnt == 0 ? minute : -1;
        }

        //Time: O(N) size of the grid.. worst case O(N) for BFS..O(N)+O(N)=O(N)
        //Space=O(N) worst case entire grid filled with rotten oranges

    }

}