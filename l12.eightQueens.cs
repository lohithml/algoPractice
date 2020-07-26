using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    class eightQueeens
    {

//Write an algorithm to print all ways of arranging eight queens on an 8x8 chess board
//so that none of them share the same row, column, or diagonal. In this case, "diagonal" means all
//diagonals, not just the two that bisect the board.

        public const int N = 8;

        static void MainQueens()
        {

            int row = 0;
            int[] col = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            List<int[]> results = new List<int[]>();

            placeQueens(row, col, results);

            foreach (int[] n in results)
            {
                for (int h = 0; h < n.Length; h++)
                {
                    Console.Write(n[h]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void placeQueens(int r, int[] c, List<int[]> res)
        {
            if (r == N) res.Add(c.ToArray()); //found valid placement
            else
            {
                for (int co = 0; co < N; co++)
                {
                    if (checkValid(c, r, co))
                    {
                        c[r] = co; //place queen
                        placeQueens(r + 1, c, res);
                    }
                }
            }
        }

// Check if (rowl, column!) is a valid spot for a queen by checking if there is a
//queen in the same column or diagonal. We don't need to check it for queens in
//the same row because the calling placeQueen only attempts to place one queen at
//a time. We know this row is empty. 

        static bool checkValid(int[] cols, int r1, int c1)
        {
            for (int r2 = 0; r2 < r1; r2++)
            {
                int c2 = cols[r2];

                if (c1 == c2) return false;

//Check diagonals: if the distance between the columns equals the distance
//between the rows, then they're in the same diagonal. 

                int colDist = Math.Abs(c1 - c2);
                int rowDist = r1 - r2;

                if (colDist == rowDist) return false;

            }
            return true;
        }

//Observe that since each row can only have one queen, we don't need to store our board as a full 8x8 matrix.
//We only need a single array where column [ r] = c indicates that row r has a queen at column c.

        //////public static bool Solve()
        //////{
        //////    int[,] board = {
        //////                    { 0, 0, 0, 0 },
        //////                    { 0, 0, 0, 0 },
        //////                    { 0, 0, 0, 0 },
        //////                    { 0, 0, 0, 0 }
        //////                    };

        //////    if (SolveNQ(board, 0) == false)
        //////        return false;

        //////    PrintSolution(board);
        //////    return true;
        //////}

        //////private static bool SolveNQ(int[,] board, int col)
        //////{
        //////    if (col >= N)
        //////        return true;

        //////    for (int i = 0; i < N; ++i)
        //////    {
        //////        if (IsSafe(board, i, col))
        //////        {
        //////            board[i, col] = 1;

        //////            if (SolveNQ(board, col + 1))
        //////                return true;

        //////            board[i, col] = 0;
        //////        }
        //////    }

        //////    return false;
        //////}

        //////private static void PrintSolution(int[,] board)
        //////{
        //////    for (int i = 0; i < N; ++i)
        //////    {
        //////        for (int j = 0; j < N; ++j)
        //////            Console.Write(" {0} ", board[i, j]);

        //////        Console.WriteLine();
        //////    }
        //////}

        //////private static bool IsSafe(int[,] board, int row, int col)
        //////{
        //////    int i, j;

        //////    for (i = 0; i < col; ++i)
        //////        if (Convert.ToBoolean(board[row, i]))
        //////            return false;

        //////    for (i = row, j = col; i >= 0 && j >= 0; --i, --j)
        //////        if (Convert.ToBoolean(board[i, j]))
        //////            return false;

        //////    for (i = row, j = col; j >= 0 && i < N; ++i, --j)
        //////        if (Convert.ToBoolean(board[i, j]))
        //////            return false;

        //////    return true;
        //////}

    }
}
