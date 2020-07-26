using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    class Search2DMatrix
    {
        //Medium
        //240.Search a 2D Matrix II

        //Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
        //Integers in each row are sorted in ascending from left to right.
        //Integers in each column are sorted in ascending from top to bottom.

        //Example:
        //Consider the following matrix:
        //[
        //  [1,   4,  7, 11, 15],
        //  [2,   5,  8, 12, 19],
        //  [3,   6,  9, 16, 22],
        //  [10, 13, 14, 17, 24],
        //  [18, 21, 23, 26, 30]
        //]
        //Given target = 5, return true.
        //Given target = 20, return false.

        public bool SearchMatrix(int[,] matrix, int target)
        {
            var rowLength = matrix.GetLength(0);
            var colLength = matrix.GetLength(1);
            var row = rowLength - 1;
            var col = 0;

            while (row >= 0 && col < colLength)
            {
                if (matrix[row, col] > target)
                    row--;
                else if (matrix[row, col] < target)
                    col++;
                else
                    return true;
            }
            return false;
        }

        //Time: O(M+N)
        //Space: O(1)
    }
}
