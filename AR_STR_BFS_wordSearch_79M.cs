using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_BFS_wordSearch
    {
        //Medium
        //79. Word Search
        //Given a 2D board and a word, find if the word exists in the grid.
        //The word can be constructed from letters of sequentially adjacent cell, 
        //where "adjacent" cells are those horizontally or vertically neighboring.The same letter cell may not be used more than once.

        //Example:
        //board =
        //[
        //  ['A', 'B', 'C', 'E'],
        //  ['S','F','C','S'],
        //  ['A','D','E','E']
        //]

        //Given word = "ABCCED", return true.
        //Given word = "SEE", return true.
        //Given word = "ABCB", return false.

        //Constraints:
        //board and word consists only of lowercase and uppercase English letters.
        //1 <= board.length <= 200
        //1 <= board[i].length <= 200
        //1 <= word.length <= 10^3

        int r = 0, c = 0;
        public bool Exist(char[][] board, string word)
        {
            r = board.Length;
            if (r == 0) return false;
            c = board[0].Length;

            bool[,] visited = new bool[r, c];
            bool res;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    res = checkExist(board, word, i, j, visited, 0);
                    if (res) return true;
                }
            }
            return false;
        }

        bool checkExist(char[][] board, string word, int x, int y, bool[,] visited, int index)
        {
            if (index == word.Length) return true;
            if (x < 0 || y < 0 || x >= r || y >= c || visited[x, y] || word[index] != board[x][y]) return false;

            visited[x, y] = true;

            bool result = checkExist(board, word, x + 1, y, visited, index + 1) ||
                        checkExist(board, word, x - 1, y, visited, index + 1) ||
                    checkExist(board, word, x, y + 1, visited, index + 1) ||
                checkExist(board, word, x, y - 1, visited, index + 1);

            visited[x, y] = false;

            return result;

        }

        //Time: O(M * N*(4^S) We potentially branch out four time for each recursion, for each of our elements in the array we might visit.Say M is number of rows, N is number of columns, S is the length of our word like you said, I think the upper bounds runtime should be: O(M * N*(4^S))
        //Space: O(S) 
    }
}