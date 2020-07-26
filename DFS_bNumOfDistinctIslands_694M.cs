using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class DFS_NumOfDistinctIslands
    {
        //Medium
        //694. Number of Distinct Islands
        //Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.
        //Count the number of distinct islands.An island is considered to be the same as another if and only if one island can be translated (and not rotated or reflected) to equal the other.

        //Example 1:
        //11000
        //11000
        //00011
        //00011
        //Given the above grid map, return 1.
        //Example 2:
        //11011
        //10000
        //00001
        //11011
        //Given the above grid map, return 3.
        //Notice that:
        //11
        //1
        //and
        // 1
        //11
        //are considered different island shapes, because we do not consider reflection / rotation.
        //Note: The length of each dimension in the given grid does not exceed 50.

        //BFS
        public int NumDistinctIslands(int[][] grid)
        {           
            var shapeSet = new HashSet<string>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        var sb = new StringBuilder();
                        explore(i, j, grid, sb, 0);
                        if (!shapeSet.Contains(sb.ToString()))
                        {
                            shapeSet.Add(sb.ToString());
                        }
                    }
                }
            }
            return shapeSet.Count;
        }

        void explore(int r, int c, int[][] grid, StringBuilder sb, int v)
        {
            if (r < 0 || r > grid.Length - 1 || c < 0 || c > grid[r].Length - 1 || grid[r][c] == 0) return;

            grid[r][c] = 0;
            sb.Append(v.ToString());
            explore(r + 1, c, grid, sb, 1);
            explore(r, c + 1, grid, sb, 2);
            explore(r - 1, c, grid, sb, 3);
            explore(r, c - 1, grid, sb, 4);

            sb.Append("0");
        }

        //Time and Space: O(R*C)
    }
}