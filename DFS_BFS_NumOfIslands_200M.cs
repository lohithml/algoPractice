using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class DFS_BFS_NumOfIslands_200M
    {
        //Medium
        //200
        //Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
        //An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
        //You may assume all four edges of the grid are all surrounded by water.
        //Example 1:
        //Input:
        //11110
        //11010
        //11000
        //00000
        //Output: 1

        //Example 2:
        //Input:
        //11000
        //11000
        //00100
        //00011
        //Output: 3

        //DFS
        public int numIslandsDFS(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int nr = grid.Length;
            int nc = grid[0].Length;
            int num_islands = 0;
            for (int r = 0; r < nr; ++r)
            {
                for (int c = 0; c < nc; ++c)
                {
                    if (grid[r][c] == '1')
                    {
                        ++num_islands;
                        dfs(grid, r, c);
                    }
                }
            }

            return num_islands;
        }
        void dfs(char[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;

            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == '0')
            {
                return;
            }

            grid[r][c] = '0'; 
            dfs(grid, r - 1, c);
            dfs(grid, r + 1, c);
            dfs(grid, r, c - 1);
            dfs(grid, r, c + 1);
        }

        //DFS
        //Time: O(MxN)
        //Space: O(MxN)

        //BFS
        public int numIslandsBFS(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            bool[,] visited = new bool[grid.Length, grid[0].Length];
            int count = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1' && !visited[i, j])
                    {
                        BFS(grid, i, j, visited);
                        count++;
                    }
                }
            }
            return count;
        }
        public void BFS(char[][] grid, int row, int col, bool[,] visited)
        {
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((row, col));
            visited[row, col] = true;

            int[,] dir = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                for (int i = 0; i < dir.GetLength(0); i++)
                {
                    int nextRow = curr.Item1 + dir[i, 0];
                    int nextCol = curr.Item2 + dir[i, 1];

                    if (nextRow >= 0 && nextRow < grid.Length && nextCol >= 0 && nextCol < grid[0].Length && !visited[nextRow, nextCol] && grid[nextRow][nextCol] == '1')
                    {
                        queue.Enqueue((nextRow, nextCol));
                        visited[nextRow, nextCol] = true;
                    }
                }
            }
        }

        //BFS
        //Time: O(MxN)
        //Space: O(min(M,N))
    }
}