using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    class SpiralMatrix
    {
        //Medium
        //54. Spiral Matrix
        //Given a matrix of m x n elements(m rows, n columns), return all elements of the matrix in spiral order.
        //Example 1:
        //Input:
        //[
        // [ 1, 2, 3 ],
        //[ 4, 5, 6 ],
        //[ 7, 8, 9 ]
        //]
        //Output: [1,2,3,6,9,8,7,4,5]

        //        Example 2:
        //Input:
        //[
        //  [1, 2, 3, 4],
        //  [5, 6, 7, 8],
        //  [9,10,11,12]
        //]
        //Output: [1,2,3,4,8,12,11,10,9,5,6,7]

        public IList<int> SpiralOrder(int[][] matrix)
        {
            var res = new List<int>();
            if (matrix.Length == 0) return res;
            int m = matrix.Length, n = matrix[0].Length, r = 0, c = 0, di = 0, i = 0;
            var seen = new bool[m, n];
            var dr = new int[4] { 0, 1, 0, -1 };
            var dc = new int[4] { 1, 0, -1, 0 };
            while (i < m * n)
            {
                i++;
                res.Add(matrix[r][c]);
                seen[r, c] = true;
                int nr = r + dr[di];
                int nc = c + dc[di];
                if (nr >= 0 && nc >= 0 && nr < m && nc < n && !seen[nr, nc])
                {
                    r = nr;
                    c = nc;
                }
                else
                {
                    di = (di + 1) % 4;
                    r += dr[di];
                    c += dc[di];
                }
            }
            return res;
        }

        //Time:O(N)
        //Space:O(N)
    }
}
